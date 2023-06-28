using Microsoft.EntityFrameworkCore;
using zolive_api.Models.Dynamic;
using zolive_api.Models.User;
using zolive_api.Services.Home;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Dynamic
{
    public class DynamicSerivce : IDynamicSerivce
    {
        private readonly newliveContext context = new newliveContext();
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly Random rnd = new Random();
        private readonly IHomeService homeService;
        private readonly ILoginService loginService;
        private readonly ICommonService _commonService;
        public DynamicSerivce(ICommonService commonService, IHomeService homeService, ILoginService loginService)
        {
            this._commonService = commonService;
            this.homeService = homeService;
            this.loginService = loginService;
        }
        public async Task<int> report(CmfDynamicReport data)
        {
            try
            {
                var dynamic = await context.CmfDynamics.Where(x => x.Id == data.Dynamicid).Select(x => x.Uid).FirstOrDefaultAsync();
                if (dynamic < 1)
                {
                    return 1000;
                }
                data.Touid = dynamic;
                await context.CmfDynamicReports.AddAsync(data);
                await context.SaveChangesAsync();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public async Task<IList<CmfDynamicReportClassify>> getReportlist()
        {
            return await context.CmfDynamicReportClassifies.OrderBy(x => x.ListOrder).ToListAsync();
        }
        #region addCommentLike
        public async Task<LikeModel?> addCommentLike(string lan, ulong uid, ulong commentid)
        {
            var rs = new LikeModel()
            {
                islike = 0,
                likes = "0"
            };
            var commentinfo = await context.CmfDynamicComments.Where(x => x.Id == commentid).FirstOrDefaultAsync();
            if (commentinfo == null) return null;
            var islike = await isCommentlike(uid, commentid);
            var nums = 0;
            if (islike == 1)
            {
                await reduceCommentLike(uid, commentid);
                nums = commentinfo.Likes - 1;
            }
            else
            {
                await addtoCommentLike(uid, commentid, commentinfo.Uid, commentinfo.Dynamicid);
                nums = commentinfo.Likes + 1;
            }
            rs.islike = islike == 1 ? 0 : 1;
            rs.likes = Utils.NumberFormat(lan, (decimal)nums);
            return rs;
        }
        public async Task<int> addtoCommentLike(ulong uid, ulong commentid, ulong touid, ulong dynamicid)
        {
            try
            {

                var obj = new CmfDynamicCommentsLike()
                {
                    Uid = uid,
                    Commentid = commentid,
                    Touid = touid,
                    Dynamicid = dynamicid,
                    Addtime = Utils.time()
                };
                await context.CmfDynamicCommentsLikes.AddAsync(obj);
                var rs = await context.CmfDynamicComments.Where(x => x.Id == commentid).FirstOrDefaultAsync();
                if (rs != null)
                {
                    rs.Likes++;
                    context.Update(rs);
                }
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<int> reduceCommentLike(ulong uid, ulong commentid)
        {
            try
            {
                var dynamicComment = await context.CmfDynamicCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
                if (dynamicComment != null)
                {
                    context.Remove(dynamicComment);
                }
                var rs = await context.CmfDynamicComments.Where(x => x.Id == commentid && x.Likes > 0).FirstOrDefaultAsync();
                if (rs != null)
                {
                    rs.Likes--;
                    context.CmfDynamicComments.Update(rs);
                }
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public async Task<int> isCommentlike(ulong uid, ulong commentid)
        {
            var like = await context.CmfDynamicCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
            if (like == null) return 0;
            return 1;
        }
        #endregion
        public async Task<SetCommentModel> setComment(CmfDynamicComment data)
        {
            var dynamicid = data.Dynamicid;
            var dynamic = await context.CmfDynamics.Where(x => x.Id == dynamicid).FirstOrDefaultAsync();
            if (dynamic != null)
            {
                dynamic.Comments++;
                context.CmfDynamics.Update(dynamic);
            }

            var videoinfo = context.CmfDynamics.Where(x => x.Id == dynamicid).Select(x => x.Comments).FirstOrDefaultAsync().Result;

            await context.CmfDynamicComments.AddAsync(data);
            await context.SaveChangesAsync();
            var count = await context.CmfDynamicComments.CountAsync(x => x.Commentid == data.Commentid);
            var rs = new SetCommentModel()
            {
                comments = videoinfo,
                replys = count
            };

            return rs;
        }
        public async Task<LikeModel?> addLike(string lan, ulong uid, ulong dynamicid)
        {

            var rs = new LikeModel();
            var dyinfo = await getDynamic(lan, uid, dynamicid);
            if (dyinfo == null) return null;//1001
            if (dyinfo.uid == uid) return null;//1002       
            var islike = isdynamiclike(uid, dynamicid).Result;
            var nums = 0;
            if (islike == 1)
            {
                await reduceLike(uid, dynamicid);
                nums = int.Parse(dyinfo.likes) - 1;
            }
            else
            {
                await addtoLike(uid, dynamicid);
                nums = int.Parse(dyinfo.likes) + 1;
            }
            rs.islike = islike == 1 ? 0 : 1;
            rs.likes = Utils.NumberFormat(lan, (decimal)nums);
            return rs;
        }
        public async Task<int> addtoLike(ulong uid, ulong dynamicid)
        {
            try
            {
                var rs = await context.CmfDynamics.FirstOrDefaultAsync(x => x.Id == dynamicid);
                if (rs != null)
                {
                    rs.Likes++;
                    context.CmfDynamics.Update(rs);
                }
                var info = new CmfDynamicLike()
                {
                    Uid = uid,
                    Dynamicid = dynamicid,
                    Addtime = Utils.time()
                };
                await context.CmfDynamicLikes.AddAsync(info);
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<int> reduceLike(ulong uid, ulong dynamicid)
        {
            try
            {
                var rs = await context.CmfDynamics.FirstOrDefaultAsync(x => x.Id == dynamicid && x.Likes > 0);
                if (rs != null)
                {
                    rs.Likes--;

                    context.CmfDynamics.UpdateRange(rs);

                }
                var lst = await context.CmfDynamicLikes.Where(x => x.Uid == uid && x.Dynamicid == dynamicid).ToListAsync();
                context.RemoveRange(lst);
                await context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<DynamicModel?> getDynamic(string lan, ulong uid, ulong dynamicid)
        {
            var info = await context.CmfDynamics.Where(x => x.Id == dynamicid && x.Status == true).Select(x => new DynamicModel
            {
                id = x.Id,
                uid = x.Uid,
                title = x.Title ?? "",
                thumb = x.Thumb ?? "",
                video_thumb = x.VideoThumb ?? "",
                href = x.Href ?? "",
                voice = x.Voice ?? "",
                length = x.Length,
                likes = x.Likes.ToString(),
                comments = x.Comments.ToString(),
                type = x.Type
            }).FirstOrDefaultAsync();
            if (info != null)
            {

                info = await handleDynamic(lan, info, uid);
            }
            else
            {
                return null;
            }
            return info;
        }
        public async Task<int> setDynamic(CmfDynamic data)
        {

            var uid = data.Uid;
            var configpri = await _commonService.getConfigPri();
            var dynamic_auth = configpri.dynamic_auth;
            if (dynamic_auth.Value == "1")
            {
                var isauth = await loginService.isAuth(uid);
                if (!isauth)
                {
                    return 1003;
                }
            }
            var nowtime = Utils.time();
            var status = false;
            var dynamic_switch = configpri.dynamic_switch;
            if (dynamic_switch.Value == "0")
            {
                status = true;
            }
            data.Status = status;
            data.Addtime = nowtime;
            data.Uptime = nowtime;
            try
            {

                await context.CmfDynamics.AddAsync(data);
                await context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1004;
            }
            return 1;
        }
        public async Task<GetCommentModel> getComments(string lan, ulong uid, ulong dynamicid, int p)
        {
            if (p < 1) p = 1;
            var nums = 20;
            var start = (p - 1) * nums;
            var comments = await context.CmfDynamicComments.Where(x => x.Dynamicid == dynamicid && x.Parentid == 0).Skip(start).Take(nums).OrderByDescending(x => x.Addtime).ToListAsync();
            GetCommentModel rs = new GetCommentModel();
            rs.commentlist = new List<GetCommentsModel>();
            foreach (var i in comments)
            {
                var obj = new GetCommentsModel();
                obj.userinfo = homeService.getUserInfo(lan, i.Uid).Result;
                obj.datetime = Utils.datetime(lan, i.Addtime);
                obj.likes = Utils.NumberFormat(lan, i.Likes);
                if (uid > 0)
                {
                    var isCommentLike = await ifCommentLike(uid, i.Id);
                    obj.islike = isCommentLike.ToString();
                }
                else
                {
                    obj.islike = "0";
                }
                var touserinfo = new UserInfo();
                if (i.Touid > 0)
                {
                    touserinfo = await homeService.getUserInfo(lan, i.Touid);
                }
                if (touserinfo.id <= 0)
                {
                    obj.touid = 0;
                    touserinfo = new UserInfo();
                }
                obj.touserinfo = touserinfo;
                obj.replys = context.CmfDynamicComments.CountAsync(x => x.Commentid == i.Id).Result;
                 
                var reply = context.CmfDynamicComments.Where(x => x.Commentid == i.Id).Take(2).OrderByDescending(x => x.Addtime);
                obj.replylist = new List<ReplyModel>();
                foreach (var v in reply)
                {
                    ReplyModel model = new ReplyModel();
                    model.userinfo =  homeService.getUserInfo(lan, v.Uid).Result;
                    model.datetime = Utils.datetime(lan, v.Addtime);
                    model.likes = Utils.NumberFormat(lan, v.Likes);
                    model.islike = ifCommentLike(uid, v.Id).Result;
                    if (v.Touid > 0)
                    {
                        touserinfo =  homeService.getUserInfo(lan, v.Touid).Result;
                        model.touid = 0;
                    }
                    var tocommentinfo = "";
                    if (v.Parentid > 0 && v.Parentid != i.Parentid)
                    {
                        tocommentinfo = await context.CmfDynamicComments.Where(x => x.Id == v.Parentid).Select(x => x.Content).FirstOrDefaultAsync();
                    }
                    else
                    {
                        touserinfo = new UserInfo();
                        model.touid = 0;
                    }
                    model.touserinfo = touserinfo;
                    model.tocommentinfo = tocommentinfo ?? "";
                    obj.replylist.Add(model);
                }
                rs.commentlist.Add(obj);
            }
            rs.comments = await context.CmfDynamicComments.CountAsync(x => x.Dynamicid == dynamicid);
            return rs;
        }

        public async Task<sbyte> ifCommentLike(ulong uid, ulong commentid)
        {
            var like = await context.CmfDynamicCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
            if (like == null) return 0;

            return 1;
        }
        public async Task<IList<DynamicModel>> getHomeDynamic(string lan, ulong uid, ulong touid, int p)
        {
            if (p < 1) p = 1;
            var nums = 20;
            var start = (p - 1) * nums;
            List<DynamicModel> dynamicList = new List<DynamicModel>();
            char[] charss = { ';' };
            if (uid == touid)
            {

                dynamicList = await context.CmfDynamics.Where(x => x.Uid == uid && !x.Isdel && x.Status).OrderByDescending(x => x.Addtime).Skip(start).Take(nums)
                    .Select(x => new DynamicModel
                    {
                        id = x.Id,
                        uid = x.Uid,
                        title = x.Title ?? "",
                        thumb = x.Thumb ?? "",
                        video_thumb = x.VideoThumb ?? "",
                        href = x.Href ?? "",
                        voice = x.Voice ?? "",
                        length = x.Length,
                        likes = Utils.NumberFormat(lan, x.Likes),
                        comments = Utils.NumberFormat(lan, x.Comments),
                        type = x.Type,
                        isdel = x.Isdel == true ? 1 : 0,
                        status = x.Status == true ? 1 : 0,
                        uptime = x.Uptime,
                        xiajia_reason = x.XiajiaReason ?? "",
                        lat = x.Lat ?? "",
                        lng = x.Lng ?? "",
                        city = x.City ?? "",
                        address = x.Address ?? "",
                        addtime = x.Addtime,
                        fail_reason = x.FailReason ?? "",
                        show_val = x.ShowVal,
                        recommend_val = x.RecommendVal,
                        thumb_ars = x.ThumbArs.Split(charss),
                        thumbs = (x.Thumb ?? "").Split(charss),
                    })
                    .ToListAsync();
            }
            else
            {
                dynamicList = await context.CmfDynamics.Where(x => x.Uid == touid && !x.Isdel && x.Status).OrderByDescending(x => x.Addtime).Skip(start).Take(nums)
                      .Select(x => new DynamicModel
                      {
                          id = x.Id,
                          uid = x.Uid,
                          title = x.Title ?? "",
                          thumb = x.Thumb ?? "",
                          video_thumb = x.VideoThumb ?? "",
                          href = x.Href ?? "",
                          voice = x.Voice ?? "",
                          length = x.Length,
                          likes = Utils.NumberFormat(lan, x.Likes),
                          comments = Utils.NumberFormat(lan, x.Comments),
                          type = x.Type,
                          isdel = x.Isdel == true ? 1 : 0,
                          status = x.Status == true ? 1 : 0,
                          uptime = x.Uptime,
                          xiajia_reason = x.XiajiaReason ?? "",
                          lat = x.Lat ?? "",
                          lng = x.Lng ?? "",
                          city = x.City ?? "",
                          address = x.Address ?? "",
                          addtime = x.Addtime,
                          fail_reason = x.FailReason ?? "",
                          show_val = x.ShowVal,
                          recommend_val = x.RecommendVal,
                          thumb_ars = x.ThumbArs.Split(charss),
                          thumbs = (x.Thumb ?? "").Split(charss),
                      })
                    .ToListAsync();
            }


            if (dynamicList.Count == 0) return dynamicList;
            for (var count = 0; count < dynamicList.Count; count++)
            {
                dynamicList[count] = await handleDynamic(lan, dynamicList[count], uid);
            }
            return dynamicList;
        }
        public async Task<IList<DynamicModel>> getNewDynamic(string lan, ulong uid, int p)
        {
            List<DynamicModel> dynamicModels = new List<DynamicModel>();
            if (p < 1)
            {
                p = 1;
            }
            var nums = 20;
            if (p != 1)
            {
                var endtime = cacheManager.GetCacheString("new_dstarttime");
                if (String.IsNullOrEmpty(endtime))
                {

                    dynamicModels = await context.CmfDynamics.Where(x => x.Isdel == false && x.Status == true && x.Addtime < int.Parse(endtime)).Take(nums).Select(x => new DynamicModel
                    {
                        id = x.Id,
                        uid = x.Uid,
                        title = x.Title ?? "",
                        thumb = x.Thumb ?? "",
                        video_thumb = x.VideoThumb ?? "",
                        href = x.Href ?? "",
                        voice = x.Voice ?? "",
                        length = x.Length,
                        likes = Utils.NumberFormat(lan, x.Likes),
                        comments = Utils.NumberFormat(lan, x.Comments),
                        type = x.Type,
                        isdel = x.Isdel == true ? 1 : 0,
                        status = x.Status == true ? 1 : 0,
                        uptime = x.Uptime,
                        xiajia_reason = x.XiajiaReason ?? "",
                        lat = x.Lat ?? "",
                        lng = x.Lng ?? "",
                        city = x.City ?? "",
                        address = x.Address ?? "",
                        addtime = x.Addtime,
                        fail_reason = x.FailReason ?? "",
                        show_val = x.ShowVal,
                        recommend_val = x.RecommendVal,
                        thumb_ars = x.ThumbArs.Split(new char[] { ',' }),
                        thumbs = (x.Thumb ?? "").Split(new char[] { ',' }),
                    }).ToListAsync();
                }
            }
            else
            {
                dynamicModels = await context.CmfDynamics.Where(x => x.Isdel == false && x.Status == true).Take(nums).Select(x => new DynamicModel
                {
                    id = x.Id,
                    uid = x.Uid,
                    title = x.Title ?? "",
                    thumb = x.Thumb ?? "",
                    video_thumb = x.VideoThumb ?? "",
                    href = x.Href ?? "",
                    voice = x.Voice ?? "",
                    length = x.Length,
                    likes = Utils.NumberFormat(lan, x.Likes),
                    comments = Utils.NumberFormat(lan, x.Comments),
                    type = x.Type,
                    isdel = x.Isdel == true ? 1 : 0,
                    status = x.Status == true ? 1 : 0,
                    uptime = x.Uptime,
                    xiajia_reason = x.XiajiaReason ?? "",
                    lat = x.Lat ?? "",
                    lng = x.Lng ?? "",
                    city = x.City ?? "",
                    address = x.Address ?? "",
                    addtime = x.Addtime,
                    fail_reason = x.FailReason ?? "",
                    show_val = x.ShowVal,
                    recommend_val = x.RecommendVal,
                    thumb_ars = x.ThumbArs.Split(new char[] { ',' }),
                    thumbs = (x.Thumb ?? "").Split(new char[] { ',' }),
                }).ToListAsync();
            }

            if (dynamicModels.Count == 0)
            {
                return dynamicModels;
            }
            else
            {
                for (var count = 0; count < dynamicModels.Count; count++)
                {
                    dynamicModels[count] = await handleDynamic(lan, dynamicModels[count], uid);
                }
            }
            return dynamicModels;

        }
        public async Task<IList<DynamicModel>> getAttentionDynamic(string lan, ulong uid, int p)
        {
            if (p < 1)
            {
                p = 1;
            }

            var nums = 20;
            var start = (p - 1) * nums;
            var attention = await context.CmfUserAttentions.Where(x => x.Uid == uid).Select(x => x.Touid).ToArrayAsync();
            List<DynamicModel> dynamicModels = new List<DynamicModel>();

            if (attention != null)
            {
                dynamicModels = await context.CmfDynamics.Where(x => attention.Contains(x.Uid) && x.Isdel == false && x.Status == true).Skip(start).Take(nums).OrderByDescending(x => x.Addtime).Select(x => new DynamicModel
                {
                    id = x.Id,
                    uid = x.Uid,
                    title = x.Title ?? "",
                    thumb = x.Thumb ?? "",
                    video_thumb = x.VideoThumb ?? "",
                    href = x.Href ?? "",
                    voice = x.Voice ?? "",
                    length = x.Length,
                    likes = Utils.NumberFormat(lan, x.Likes),
                    comments = Utils.NumberFormat(lan, x.Comments),
                    type = x.Type,
                    isdel = x.Isdel == true ? 1 : 0,
                    status = x.Status == true ? 1 : 0,
                    uptime = x.Uptime,
                    xiajia_reason = x.XiajiaReason ?? "",
                    lat = x.Lat ?? "",
                    lng = x.Lng ?? "",
                    city = x.City ?? "",
                    address = x.Address ?? "",
                    addtime = x.Addtime,
                    fail_reason = x.FailReason ?? "",
                    show_val = x.ShowVal,
                    recommend_val = x.RecommendVal,
                    thumb_ars = x.ThumbArs.Split(new char[] { ',' }),
                    thumbs = (x.Thumb ?? "").Split(new char[] { ',' }),
                }).ToListAsync();
                if (dynamicModels == null || dynamicModels.Count == 0)
                {
                    return new List<DynamicModel>();
                }
                else
                {
                    for (var count = 0; count < dynamicModels.Count; count++)
                    {

                        dynamicModels[count] = await handleDynamic(lan, dynamicModels[count], uid);

                    }
                }
            }
            return dynamicModels;

        }
        public async Task<IList<DynamicModel>> getRecommendDynamics(string lan, ulong uid, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var pnums = 20;
            var start = (p - 1) * pnums;

            var configPri = _commonService.getConfigPri().Result;
            int comment_weight = configPri.comment_weight;
            int like_weight = configPri.like_weight;
            IList<DynamicModel> dynamicModels = new List<DynamicModel>();
            var chas = new char[] { ';' };
            dynamicModels = await context.CmfDynamics.Where(x => x.Isdel == false && x.Status == true).Skip(start).Take(pnums)
                .Select(x => new DynamicModel
                {
                    id = x.Id,
                    uid = x.Uid,
                    title = x.Title ?? "",
                    thumb = x.Thumb ?? "",
                    video_thumb = x.VideoThumb ?? "",
                    href = x.Href ?? "",
                    voice = x.Voice ?? "",
                    length = x.Length,
                    likes = Utils.NumberFormat(lan, x.Likes),
                    comments = Utils.NumberFormat(lan, x.Comments),
                    type = x.Type,
                    isdel = (x.Isdel) == true ? 1 : 0,
                    status = x.Status == true ? 1 : 0,
                    uptime = x.Uptime,
                    xiajia_reason = x.XiajiaReason ?? "",
                    lat = x.Lat ?? "",
                    lng = x.Lng ?? "",
                    city = x.City ?? "",
                    address = x.Address ?? "",
                    addtime = x.Addtime,
                    fail_reason = x.FailReason ?? "",
                    show_val = x.ShowVal,
                    recommend_val = x.RecommendVal,
                    thumb_ars = x.ThumbArs.Split(chas),
                    recomend = Math.Ceiling((decimal)(x.Comments * comment_weight + x.Likes * like_weight)),
                    thumbs = (x.Thumb ?? "").Split(chas),
                })
                .ToListAsync();



            if (dynamicModels == null)
            {
                return new List<DynamicModel>();
            }
            else
            {

                for (var count = 0; count < dynamicModels.Count; count++)
                {
                    dynamicModels[count] = await handleDynamic(lan, dynamicModels[count], uid);
                }
            }
            dynamicModels = dynamicModels.OrderByDescending(x => x.recommend_val).ThenByDescending(x => x.recomend).ThenByDescending(x => x.addtime).ToList();
            return dynamicModels;
        }
        public async Task<DynamicModel> handleDynamic(string lan, DynamicModel v, ulong uid)
        {
            v.datetime = Utils.datetime(lan, v.addtime);
            if (v.uid == uid)
            {
                v.islike = 0;
            }
            else
            {
                v.islike = isdynamiclike(uid, v.id).Result;
            }

            v.userinfo = new UserinfoDynamic();
            v.userinfo.isAttention = _commonService.isAttention(uid, v.uid).Result;
            var userinfo = await homeService.getUserInfo(lan, v.uid);
            v.userinfo.id = userinfo.id;
            v.userinfo.user_nicename = userinfo.user_nicename;
            v.userinfo.avatar = userinfo.avatar;
            v.userinfo.avatar_thumb = userinfo.avatar_thumb;
            v.userinfo.sex = userinfo.sex;


            return v;
        }
        public async Task<int> isdynamiclike(ulong uid, ulong dynamicid)
        {
            var isexits = await context.CmfDynamicLikes.AnyAsync(x => x.Uid == uid && x.Dynamicid == dynamicid);
            if (isexits)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
