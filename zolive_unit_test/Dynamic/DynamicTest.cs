using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_api.Models.Dynamic;
using zolive_api.Models.User;
using zolive_api.Services.Dynamic;
using zolive_api.Services.Home;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Dynamic
{
    public class DynamicTest
    {
        public readonly newliveContext context = new newliveContext();
        //private readonly HomeService homeService;
        //private readonly DynamicSerivce dynamicService = new DynamicSerivce();
        public readonly CacheManager cacheManager = new CacheManager();
        private readonly ICommonService _commonService;
        Random rnd = new Random();
        public IConfiguration InitConfiguration()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [SetUp]
        public void Setup()
        {
            var config = InitConfiguration();
            ConfigNew.Configuration = config;
        }

        [Test]
        public async Task MainTest()
        {
            //await getRecommendDynamics("Nam", 45018, 1);
            //await getAttentionDynamic("Nam", 40219, 1);
            //await getNewDynamic("Nam", 40219, 1);
            // await getHomeDynamic("Nam", 40219, 40219, 1);
            // await getComments("Nam", 40219, 2, 1);
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
        #region setDynamic
        public async Task<int> setDynamic(ulong uid, string thumb, string video_thumb, string href)
        {
            var configpri = await _commonService.getConfigPri();
            var dynamic_auth = configpri.dynamic_auth;
            if (dynamic_auth.Value == "1")
            {
                var isauth = await isAuth(uid);
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
            var data = new CmfDynamic();
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

        public async Task<bool> isAuth(ulong uid)
        {
            var status = await context.CmfUserAuths.Where(x => x.Uid == uid).Select(x => x.Status).FirstOrDefaultAsync();

            return status;

        }
        #endregion
        public async Task<GetCommentModel> getComments(string lan, ulong uid, ulong dynamicid, int p)
        {
            if (p < 1) p = 1;
            var nums = 20;
            var start = (p - 1) * nums;
            var comments = await context.CmfDynamicComments.Where(x => x.Dynamicid == dynamicid && x.Parentid == 0).Skip(start).Take(nums).OrderByDescending(x => x.Addtime).ToListAsync();

            IList<GetCommentsModel> commentList = new List<GetCommentsModel>();
            foreach (var i in comments)
            {
                GetCommentsModel obj = new GetCommentsModel();
                obj.userinfo = await getUserInfo(lan, i.Uid);
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
                    touserinfo = await getUserInfo(lan, i.Touid);
                }
                if (touserinfo.id <= 0)
                {
                    obj.touid = 0;
                    touserinfo = new UserInfo();
                }
                obj.touserinfo = touserinfo;
                var count = await context.CmfDynamicComments.Where(x => x.Commentid == i.Id).CountAsync();
                obj.replys = count;
                var reply = await context.CmfDynamicComments.Where(x => x.Commentid == i.Id).Take(1).OrderByDescending(x => x.Addtime).ToListAsync();
                IList<ReplyModel> replys = new List<ReplyModel>();
                foreach (var v in reply)
                {
                    var model = new ReplyModel();
                    model.userinfo = await getUserInfo(lan, v.Uid);
                    model.datetime = Utils.datetime(lan, v.Addtime);
                    model.likes = Utils.NumberFormat(lan, v.Likes);
                    model.islike = await ifCommentLike(uid, v.Id);
                    if (v.Touid > 0)
                    {
                        touserinfo = await getUserInfo(lan, v.Touid);
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
                    model.tocommentinfo = tocommentinfo;
                    replys.Add(model);
                    obj.replylist = replys;
                }
                commentList.Add(obj);
            }
            var commentnum = await context.CmfDynamicComments.Where(x => x.Dynamicid == dynamicid).CountAsync();
            GetCommentModel rs = new GetCommentModel();
            rs.comments = commentnum;
            rs.commentlist = commentList;
            return rs;
        }

        public async Task<IList<DynamicModel>> getHomeDynamic(string lan, ulong uid, ulong touid, int p)
        {
            if (p < 1) p = 1;
            var nums = 20;
            var start = (p - 1) * nums;
            IList<CmfDynamic> dynamic = new List<CmfDynamic>();

            if (uid == touid)
            {
                dynamic = await context.CmfDynamics.Where(x => x.Uid == uid && !x.Isdel && x.Status).OrderByDescending(x => x.Addtime).Skip(start).Take(nums).ToListAsync();
            }
            else
            {
                dynamic = await context.CmfDynamics.Where(x => x.Uid == touid && !x.Isdel && x.Status).OrderByDescending(x => x.Addtime).Skip(start).Take(nums).ToListAsync();
            }

            IList<DynamicModel> dynamicList = new List<DynamicModel>();
            if (dynamic.Count == 0) return new List<DynamicModel>();
            foreach (var x in dynamic)
            {
                DynamicModel obj = new DynamicModel();
                obj.id = x.Id;
                obj.uid = x.Uid;
                obj.title = x.Title ?? "";
                obj.thumb = x.Thumb ?? "";
                obj.video_thumb = x.VideoThumb ?? "";
                obj.href = x.Href ?? "";
                obj.voice = x.Voice ?? "";
                obj.length = x.Length;
                obj.likes = Utils.NumberFormat(lan, x.Likes);
                obj.comments = Utils.NumberFormat(lan, x.Comments);
                obj.type = x.Type;
                obj.isdel = x.Isdel == true ? 1 : 0;
                obj.status = x.Status == true ? 1 : 0;
                obj.uptime = x.Uptime;
                obj.xiajia_reason = x.XiajiaReason ?? "";
                obj.lat = x.Lat ?? "";
                obj.lng = x.Lng ?? "";
                obj.city = x.City ?? "";
                obj.address = x.Address ?? "";
                obj.addtime = x.Addtime;
                obj.fail_reason = x.FailReason ?? "";
                obj.show_val = x.ShowVal;
                obj.recommend_val = x.RecommendVal;
                obj.thumb_ars = x.ThumbArs.Split(new char[] { ';' });
                obj.thumbs = (x.Thumb ?? "").Split(new char[] { ';' });
                obj = await handleDynamic(lan, obj, uid);
                dynamicList.Add(obj);
            }
            return dynamicList;
        }

        public async Task<sbyte> ifCommentLike(ulong uid, ulong commentid)
        {
            var like = await context.CmfDynamicCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
            if (like == null) return 0;

            return 1;
        }
        public async Task<List<DynamicModel>> getNewDynamic(string lan, ulong uid, int p)
        {
            List<DynamicModel> dynamicModels = new List<DynamicModel>();
            if (p < 1)
            {
                p = 1;
            }
            var nums = 20;
            List<CmfDynamic> rs = new List<CmfDynamic>();
            if (p != 1)
            {
                var endtime = cacheManager.GetCacheString("new_dstarttime");
                if (String.IsNullOrEmpty(endtime))
                {

                    rs = await context.CmfDynamics.Where(x => x.Isdel == false && x.Status == true && x.Addtime < int.Parse(endtime)).Take(nums).ToListAsync();
                }
            }
            else
            {
                rs = await context.CmfDynamics.Where(x => x.Isdel == false && x.Status == true).Take(nums).ToListAsync();
            }

            if (rs.Count == 0)
            {
                return dynamicModels;
            }
            else
            {
                foreach (var x in rs)
                {
                    DynamicModel obj = new DynamicModel();
                    obj.id = x.Id;
                    obj.uid = x.Uid;
                    obj.title = x.Title ?? "";
                    obj.thumb = x.Thumb ?? "";
                    obj.video_thumb = x.VideoThumb ?? "";
                    obj.href = x.Href ?? "";
                    obj.voice = x.Voice ?? "";
                    obj.length = x.Length;
                    obj.likes = Utils.NumberFormat(lan, x.Likes);
                    obj.comments = Utils.NumberFormat(lan, x.Comments);
                    obj.type = x.Type;
                    obj.isdel = x.Isdel == true ? 1 : 0;
                    obj.status = x.Status == true ? 1 : 0;
                    obj.uptime = x.Uptime;
                    obj.xiajia_reason = x.XiajiaReason ?? "";
                    obj.lat = x.Lat ?? "";
                    obj.lng = x.Lng ?? "";
                    obj.city = x.City ?? "";
                    obj.address = x.Address ?? "";
                    obj.addtime = x.Addtime;
                    obj.fail_reason = x.FailReason ?? "";
                    obj.show_val = x.ShowVal;
                    obj.recommend_val = x.RecommendVal;
                    obj.thumb_ars = x.ThumbArs.Split(new char[] { ';' });
                    obj.thumbs = (x.Thumb ?? "").Split(new char[] { ';' });
                    obj = await handleDynamic(lan, obj, uid);
                    dynamicModels.Add(obj);
                }
            }
            var json = JsonConvert.SerializeObject(dynamicModels);
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
                var dynamic = await context.CmfDynamics.Where(x => attention.Contains(x.Uid) && x.Isdel == false && x.Status == true).Skip(start).Take(nums).OrderByDescending(x => x.Addtime).ToListAsync();
                if (dynamic == null || dynamic.Count == 0)
                {
                    return dynamicModels;
                }
                else
                {
                    foreach (var x in dynamic)
                    {
                        DynamicModel obj = new DynamicModel();
                        obj.id = x.Id;
                        obj.uid = x.Uid;
                        obj.title = x.Title ?? "";
                        obj.thumb = x.Thumb ?? "";
                        obj.video_thumb = x.VideoThumb ?? "";
                        obj.href = x.Href ?? "";
                        obj.voice = x.Voice ?? "";
                        obj.length = x.Length;
                        obj.likes = Utils.NumberFormat(lan, x.Likes);
                        obj.comments = Utils.NumberFormat(lan, x.Comments);
                        obj.type = x.Type;
                        obj.isdel = x.Isdel == true ? 1 : 0;
                        obj.status = x.Status == true ? 1 : 0;
                        obj.uptime = x.Uptime;
                        obj.xiajia_reason = x.XiajiaReason ?? "";
                        obj.lat = x.Lat ?? "";
                        obj.lng = x.Lng ?? "";
                        obj.city = x.City ?? "";
                        obj.address = x.Address ?? "";
                        obj.addtime = x.Addtime;
                        obj.fail_reason = x.FailReason ?? "";
                        obj.show_val = x.ShowVal;
                        obj.recommend_val = x.RecommendVal;
                        obj.thumb_ars = x.ThumbArs.Split(new char[] { ';' });
                        obj.thumbs = (x.Thumb ?? "").Split(new char[] { ';' });
                        obj = await handleDynamic(lan, obj, uid);
                        dynamicModels.Add(obj);
                    }
                }
            }
            //var json =JsonConvert.SerializeObject(dynamicModels);
            return dynamicModels;

        }
        public async Task<List<DynamicModel>> getRecommendDynamics(string lan, ulong uid, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var pnums = 20;
            var start = (p - 1) * pnums;

            var configPri = await _commonService.getConfigPri();
            int comment_weight = configPri.comment_weight;
            int like_weight = configPri.like_weight;
            var info = await context.CmfDynamics.Where(x => x.Isdel == false && x.Status == true).Skip(start).Take(pnums).ToListAsync();

            List<DynamicModel> dynamicModels = new List<DynamicModel>();

            if (info == null)
            {
                return dynamicModels;
            }
            else
            {
                foreach (var x in info)
                {
                    DynamicModel obj = new DynamicModel();
                    obj.id = x.Id;
                    obj.uid = x.Uid;
                    obj.title = x.Title ?? "";
                    obj.thumb = x.Thumb ?? "";
                    obj.video_thumb = x.VideoThumb ?? "";
                    obj.href = x.Href ?? "";
                    obj.voice = x.Voice ?? "";
                    obj.length = x.Length;
                    obj.likes = Utils.NumberFormat(lan, x.Likes);
                    obj.comments = Utils.NumberFormat(lan, x.Comments);
                    obj.type = x.Type;
                    obj.isdel = x.Isdel == true ? 1 : 0;
                    obj.status = x.Status == true ? 1 : 0;
                    obj.uptime = x.Uptime;
                    obj.xiajia_reason = x.XiajiaReason ?? "";
                    obj.lat = x.Lat ?? "";
                    obj.lng = x.Lng ?? "";
                    obj.city = x.City ?? "";
                    obj.address = x.Address ?? "";
                    obj.addtime = x.Addtime;
                    obj.fail_reason = x.FailReason ?? "";
                    obj.show_val = x.ShowVal;
                    obj.recommend_val = x.RecommendVal;
                    obj.thumb_ars = x.ThumbArs.Split(new char[] { ';' });
                    obj.recomend = Math.Ceiling((decimal)(x.Comments * comment_weight + x.Likes * like_weight));
                    obj.thumbs = (x.Thumb ?? "").Split(new char[] { ';' });
                    obj = await handleDynamic(lan, obj, uid);
                    dynamicModels.Add(obj);
                }
            }
            return dynamicModels;
        }

        //[Test]
        //public void ChangeThumb()
        //{
        //    var rs = context.CmfDynamics.ToList();
        //    foreach(var r in rs)
        //    {
        //        //var str = r.ThumbArs.Replace("http://127.0.0.1", "https://zolive.m99.club");
        //        //r.ThumbArs = str;
        //    }
        //    context.SaveChanges();
        //}

        public async Task<DynamicModel> handleDynamic(string lan, DynamicModel v, ulong uid)
        {
            v.datetime = Utils.datetime(lan, v.addtime);
            if (v.uid == uid)
            {
                v.islike = 0;
            }
            else
            {
                v.islike = await isdynamiclike(uid, v.id);
            }
            var userinfo = await getUserInfo(lan, v.uid);
            v.userinfo = new UserinfoDynamic();
            v.userinfo.id = userinfo.id;
            v.userinfo.user_nicename = userinfo.user_nicename;
            v.userinfo.avatar = userinfo.avatar;
            v.userinfo.avatar_thumb = userinfo.avatar_thumb;
            v.userinfo.sex = userinfo.sex;
            v.userinfo.isAttention = await _commonService.isAttention(uid, v.uid);

            return v;
        }
        public async Task<UserInfo> getUserInfo(string? lan, ulong uid, int type = 0)
        {
            UserInfo info = new UserInfo();
            if (uid == 0)
            {
                if (uid == 0)//code base is string "goodsorder_admin"
                {
                    var configpub = await _commonService.getConfigPub();
                    info.user_nicename = "订单消息";
                    if (lan == "En")
                    {
                        info.user_nicename = "Order message";
                    }
                    else if (lan == "Nam")
                    {
                        info.user_nicename = "Thông tin đơn hàng";

                    }
                    info.avatar = Utils.get_upload_path("/orderMsg.png");
                    info.avatar_thumb = Utils.get_upload_path("/orderMsg.png");
                    info.id = 0;
                }
                info.coin = 0;
                info.sex = 1;
                info.signature = "";
                info.province = "";
                info.city = "";
                info.birthday = "";
                info.issuper = 0;
                info.votestotal = 0;
                info.consumption = 0;
                info.location = "";
                info.user_status = 1;

            }
            else
            {
                var user = cacheManager.GetCacheString("userinfos_" + uid);
                if (user == null)
                {
                    var rs = await context.CmfUsers1.Where(x => x.Id == uid && x.UserType == 2).FirstOrDefaultAsync();
                    if (rs != null)
                    {
                        info.id = uid;
                        info.user_nicename = rs.UserNicename;
                        info.avatar = rs.Avatar;
                        info.avatar_thumb = rs.AvatarThumb;
                        info.sex = rs.Sex;
                        info.signature = rs.Signature;
                        info.consumption = rs.Consumption;
                        info.votestotal = rs.Votestotal;
                        info.province = rs.Province;
                        info.city = rs.City;
                        var birthday = rs.Birthday ?? 0;
                        info.birthday = Utils.UnixTimeToDateTime(birthday).ToString("yyyy-MM-dd");
                        info.user_status = rs.UserStatus;
                        info.issuper = rs.Issuper ? 1 : 0;
                        info.location = rs.Location;

                        await cacheManager.SetCacheString("userinfo_" + uid, JsonConvert.SerializeObject(info));
                    }
                    if (type == 1)
                    {
                        return info;
                    }
                    if (rs == null)
                    {
                        info.id = uid;
                        info.user_nicename = "用户不存在";
                        info.avatar = "/default.jpg";
                        info.avatar_thumb = "/default_thumb.jpg";
                        info.sex = 0;
                        info.signature = "";
                        info.consumption = 0;
                        info.votestotal = 0;
                        info.province = "";
                        info.city = "";
                        info.birthday = "";
                        info.issuper = 0;
                    }
                    else
                    {
                        info.level = await _commonService.getLevel(info.consumption);
                        info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
                        info.avatar = info.avatar;
                        info.avatar_thumb = info.avatar_thumb;
                        info.vip = await _commonService.getUserVip(uid);
                        info.liang = await _commonService.getUserLiang(uid);
                        if (info.birthday == "" || info.birthday == "0")
                        {
                            info.birthday = "";
                        }
                    }
                }
                else
                {
                    info = JsonConvert.DeserializeObject<UserInfo>(user) ?? new UserInfo();
                    info.level = await _commonService.getLevel(info.consumption);
                    info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
                    info.avatar = info.avatar;
                    info.avatar_thumb = info.avatar_thumb;
                    info.vip = await _commonService.getUserVip(uid);
                    info.liang = await _commonService.getUserLiang(uid);
                    if (info.birthday == "" || info.birthday == "0")
                    {
                        info.birthday = "";
                    }
                }
            }
            return info;
        }

        public async Task<sbyte> isdynamiclike(ulong uid, ulong dynamicid)
        {
            var isexits = await context.CmfDynamicLikes.Where(x => x.Uid == uid && x.Dynamicid == dynamicid).FirstOrDefaultAsync();
            if (isexits != null)
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
