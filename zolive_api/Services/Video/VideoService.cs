using Microsoft.EntityFrameworkCore;
using zolive_api.Models.Dynamic;
using zolive_api.Models.User;
using zolive_api.Models.Video;
using zolive_api.Services.Home;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Video
{
    public class VideoService : IVideoService
    {
        public readonly newliveContext context = new newliveContext();
        public readonly CacheManager cacheManager = new CacheManager();
        public Random rnd = new Random();
        private IHomeService HomeService;
        private ICommonService _commonService;
        private readonly IDynamicSerivce DynamicSerivce;
        public VideoService(ICommonService commonService, IHomeService HomeService, IDynamicSerivce DynamicSerivce)
        {
            this._commonService = commonService;
            this.HomeService = HomeService;
            this.DynamicSerivce = DynamicSerivce;
        }
        public async Task<int> setVideo(CmfVideo data, int music_id)
        {
            var configPri = await _commonService.getConfigPri();
            if (configPri.video_audit_switch.Value == "0")
            {
                data.Status = false;
            }
            if (data.Classid > 0)
            {
                var isexitclass = await context.CmfVideoClasses.FirstOrDefaultAsync(x => x.Id == data.Classid);
                if (isexitclass == null)
                {
                    return 1007; // 1007
                }
            }
            await context.CmfVideos.AddAsync(data);
            if (music_id > 0)
            {
                var music = await context.CmfMusics.FirstOrDefaultAsync(x => x.Id == music_id);
                if (music != null)
                {
                    music.UseNums += 1;
                    context.CmfMusics.Update(music);
                }
            }
            await context.SaveChangesAsync();
            return 1;
        }
        public async Task<IList<CmfVideoReportClassify>?> getReportContentlist()
        {
            
            return await context.CmfVideoReportClassifies.OrderByDescending(x => x.ListOrder).ToListAsync();
        }
        public async Task<int> report(CmfVideoReport data)
        {
            var video = await context.CmfVideos.FirstOrDefaultAsync(x => x.Id == data.Videoid);
            if (video == null)
            {
                return 1000;
            }
            data.Uid = video.Uid;
            await context.CmfVideoReports.AddAsync(data);
            await context.SaveChangesAsync();
            return 0;
        }
        public async Task<SetCommentModel> setComment(CmfVideoComment data)
        {
            var videoid = data.Videoid;
            var comment = await context.CmfVideos.Where(x => x.Id == videoid).FirstOrDefaultAsync();
            var videoinfo = 0;
            if (comment != null)
            {
                comment.Comments++;
                context.CmfVideos.Update(comment);
                videoinfo = comment.Comments;
            }

            await context.CmfVideoComments.AddAsync(data);
            var count = await context.CmfVideoComments.Where(x => x.Commentid == data.Commentid).CountAsync();
            var rs = new SetCommentModel();
            rs.comments = videoinfo;
            rs.replys = count;

            return rs;
        }
        public async Task<LikeModel?> addCommentLike(string lan, ulong uid, ulong commentid)
        {
            var rs = new LikeModel()
            {
                islike = 0,
                likes = "0"
            };
            var commentinfo = await context.CmfVideoComments.Where(x => x.Id == commentid).FirstOrDefaultAsync();
            if (commentinfo == null)
            {
                return null;//1001
            }
            var like = await context.CmfVideoCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
            var videoComment = await context.CmfVideoComments.Where(x => x.Id == commentid).FirstOrDefaultAsync();
            if (like != null)
            {
                var VideoCommentLike = await context.CmfVideoCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
                if (VideoCommentLike != null) context.CmfVideoCommentsLikes.Remove(VideoCommentLike);
                videoComment = await context.CmfVideoComments.Where(x => x.Id == commentid && x.Likes > 0).FirstOrDefaultAsync();
                if (videoComment != null)
                {
                    videoComment.Likes--;
                    context.CmfVideoComments.Update(videoComment);
                    rs.islike = 0;
                }
            }
            else
            {
                var VideoCommentLike = new CmfVideoCommentsLike()
                {
                    Uid = uid,
                    Commentid = commentid,
                    Addtime = Utils.time(),
                    Touid = commentinfo.Uid,
                    Videoid = commentinfo.Videoid
                };
                await context.CmfVideoCommentsLikes.AddAsync(VideoCommentLike);
                if (videoComment != null)
                {
                    videoComment.Likes++;
                    context.CmfVideoComments.Update(videoComment);
                    rs.islike = 1;
                }
            }
            await context.SaveChangesAsync();
            var videolikes = await context.CmfVideoComments.Where(x => x.Id == commentid).Select(x => x.Likes).FirstOrDefaultAsync();

            rs.likes = Utils.NumberFormat(lan, videolikes);
            return rs;
        }
        public async Task<ResultComment> getComments(string lan, ulong uid, ulong videoid, int p)
        {
            if (p < 1) p = 1;
            var nums = 20;
            var start = (p - 1) * nums;
            var comments = await context.CmfVideoComments.Where(x => x.Videoid == videoid && x.Parentid == 0).Skip(start).Take(nums).OrderByDescending(x => x.Addtime).ToListAsync();
            var listComments = new List<VideoCommentModel>();
            foreach (var v in comments)
            {
                var comment = new VideoCommentModel();
                comment.content = v.Content;
                comment.id = v.Id;
                comment.uid = v.Uid;
                comment.videoid = v.Videoid;
                comment.commentid = v.Commentid;
                comment.parentid = v.Parentid;
                comment.addtime = v.Addtime;
                comment.at_info = v.AtInfo;
                comment.userinfo = await HomeService.getUserInfo(lan, v.Uid);
                comment.datetime = Utils.datetime(lan, v.Addtime);
                comment.likes = Utils.NumberFormat(lan, v.Likes);
                if (uid > 0)
                {
                    comment.islike = await DynamicSerivce.ifCommentLike(uid, v.Id);
                }
                else
                {
                    comment.islike = 0;
                }
                var touserinfo = new UserInfo();
                if (v.Touid > 0)
                {
                    touserinfo = await HomeService.getUserInfo(lan, v.Touid);
                }
                if (touserinfo == null)
                {
                    touserinfo = new UserInfo();
                    comment.touid = 0;
                }
                comment.touserinfo = touserinfo;
                var count = await context.CmfVideoComments.Where(x => x.Commentid == v.Id).CountAsync();
                comment.replys = count;
                var reply = await context.CmfVideoComments.Where(x => x.Commentid == v.Id).OrderByDescending(x => x.Addtime).Take(2).ToListAsync();
                var listReply = new List<CommentV1>();
                foreach (var v1 in reply)
                {
                    var obj = new CommentV1();
                    obj.id = v1.Id;
                    obj.uid = v1.Uid;
                    obj.touid = v1.Touid;
                    obj.addtime = Utils.datetime(lan, v1.Addtime);

                    obj.userinfo = await HomeService.getUserInfo(lan, v1.Uid);
                    obj.datetime = Utils.datetime(lan, v1.Addtime);
                    obj.likes = Utils.NumberFormat(lan, v1.Likes);
                    obj.islike = await DynamicSerivce.ifCommentLike(uid, v1.Id);

                    if (v1.Touid > 0)
                    {
                        obj.touserinfo = await HomeService.getUserInfo(lan, v1.Touid);
                    }
                    else
                    {
                        obj.touserinfo = new UserInfo();
                        obj.touid = 0;
                    }
                    if (v1.Parentid > 0 && v1.Parentid != v.Id)
                    {
                        obj.tocommentinfo = await context.CmfVideoComments.Where(x => x.Id == v1.Parentid).Select(x => new
                        {
                            content = x.Content ?? "",
                            at_info = x.AtInfo
                        }).FirstOrDefaultAsync();
                    }
                    else
                    {
                        obj.tocommentinfo = new
                        {
                            content = "",
                            at_info = ""
                        };
                        obj.touserinfo = new UserInfo();
                        obj.touid = 0;
                    }
                    listReply.Add(obj);
                }
                comment.replylist = listReply;
                listComments.Add(comment);
            }
            var commentnum = await context.CmfVideoComments.Where(x => x.Videoid == videoid).CountAsync();
            var rs = new ResultComment();
            rs.comments = commentnum;
            rs.commentlist = listComments;
            return rs;
        }
        public async Task<LikeModel?> addLike(string lan, ulong uid, ulong videoid)
        {
            var rs = new LikeModel()
            {
                islike = 0,
                likes = "0"
            };
            var video = await context.CmfVideos.Where(x => x.Uid == videoid).Select(x => new
            {
                likes = x.Likes,
                uid = x.Uid,
                thumb = x.Thumb
            }).FirstOrDefaultAsync();
            if (video == null)
            {
                return null;
            }
            if (video.uid == uid)
            {
                return null;
            }
            var like = await context.CmfVideoLikes.Where(x => x.Uid == uid && x.Videoid == videoid).FirstOrDefaultAsync();
            var videoLikess = await context.CmfVideos.Where(x => x.Id == videoid && x.Likes > 0).FirstOrDefaultAsync();
            if (like != null)
            {
                context.CmfVideoLikes.Remove(like);

                if (videoLikess != null)
                {
                    videoLikess.Likes--;
                    context.Update(videoLikess);
                }
                rs.islike = 0;
            }
            else
            {
                var objVideoLike = new CmfVideoLike()
                {
                    Uid = uid,
                    Videoid = videoid,
                    Addtime = Utils.time()
                };
                if (videoLikess != null)
                {
                    videoLikess.Likes++;
                    context.Update(videoLikess);
                }
                rs.islike = 1;
            }
            await context.SaveChangesAsync();
            video = await context.CmfVideos.Where(x => x.Id == videoid).Select(x => new
            {
                likes = x.Likes,
                uid = x.Uid,
                thumb = x.Thumb
            }).FirstOrDefaultAsync();
            if (video != null)
                rs.likes = Utils.NumberFormat(lan, video.likes);
            return rs;
        }
        public virtual async Task<IList<VideoModel>> getClassVideo(string? lan, int videoclassid, ulong uid, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var nums = 21;
            var start = (p - 1) * nums;
            var listvideos = await context.CmfVideos.Where(x => x.Isdel == false && x.Status == true && x.Classid == videoclassid).Skip(start).Take(nums)
                      .Select(v => new VideoModel
                      {
                          id = v.Id,
                          uid = v.Uid,
                          title = v.Title,
                          thumb = v.Thumb,
                          thumb_s = v.ThumbS,
                          href = v.Href,
                          href_w = v.HrefW,
                          likes = v.Likes.ToString(),
                          views = v.Views,
                          comments = v.Comments.ToString(),
                          steps = v.Steps.ToString(),
                          shares = v.Shares,
                          addtime = v.Addtime.ToString(),
                          lat = v.Lat,
                          lng = v.Lng,
                          city = v.City,
                          music_id = v.MusicId,
                          is_ad = v.IsAd,
                          ad_url = v.AdUrl,
                          type = v.Type,
                          goodsid = v.Goodsid,
                          classid = v.Classid,
                          ad_endtime = v.AdEndtime
                      })
                      .ToListAsync();

            for (var count = 0; count < listvideos.Count; count++)
            {

                listvideos[count] = await handleVideo(lan, uid, listvideos[count]);

            }

            return listvideos;
        }
        public async Task<bool> addView(ulong videoid)
        {
            var video = await context.CmfVideos.Where(x => x.Id == videoid).FirstOrDefaultAsync();
            if (video == null)
            {
                return false;
            }
            else
            {
                video.Views += 1;
                //context.CmfVideos.Update(video);
                await context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> setConversion(ulong videoid)
        {
            var video = await context.CmfVideos.FirstOrDefaultAsync(x => x.Id == videoid && x.Isdel == false && x.Status == true);
            if (video == null)
            {
                return false;
            }
            else
            {
                video.WatchOk += 1;
                await context.SaveChangesAsync();
                return true;
            }
        }
        public async Task<IList<VideoModel>> getVideoList(string? lan, ulong uid, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var nums = 20;
            var start = (p - 1) * nums;
            IList<VideoModel> video = await context.CmfVideos.Where(x => x.Isdel == false && x.Status == true && x.IsAd == false).Skip(start).Take(nums).OrderBy(_ => Guid.NewGuid()).Select(x => new VideoModel
            {
                id = x.Id,
                uid = x.Uid,
                title = x.Title,
                thumb = x.Thumb,
                thumb_s = x.ThumbS,
                href = x.Href,
                href_w = x.HrefW,
                likes = x.Likes.ToString(),
                views = x.Views,
                comments = x.Comments.ToString(),
                steps = x.Steps.ToString(),
                shares = x.Shares,
                addtime = x.Addtime.ToString(),
                lat = x.Lat,
                lng = x.Lng,
                city = x.City,
                music_id = x.MusicId,
                is_ad = x.IsAd,
                ad_url = x.AdUrl,
                type = x.Type,
                goodsid = x.Goodsid,
                classid = x.Classid,
                ad_endtime = x.AdEndtime
            }).ToListAsync();
            
            for (var count = 0;count< video.Count;count++)
            {
                video[count] =  handleVideo(lan, uid, video[count]).Result;
            }
            
            return video;
        }
        public virtual async Task<VideoModel> handleVideo(string? lan, ulong uid, VideoModel v)
        {
            
            v.datetime = Utils.datetime(lan, long.Parse(v.addtime));
            v.addtime = Utils.UnixTimeToDateTime(long.Parse(v.addtime)).ToString("yyyy-MM-dd HH-mm-ss");
            v.comments = Utils.NumberFormat(lan, decimal.Parse(v.comments));
            v.likes = Utils.NumberFormat(lan, decimal.Parse(v.likes));
            v.steps = Utils.NumberFormat(lan, decimal.Parse(v.steps));

            v.islike = 0;
            v.isstep = 0;
            v.isattent = 0;

            if (uid > 0)
            {
                v.islike =  _commonService.ifLike(uid, v.id).Result;
                v.isstep = _commonService.ifStep(uid, v.id).Result;
            }

            if (uid > 0 && uid != v.uid)
            {
                v.isattent =  _commonService.isAttention(uid, v.uid).Result;
            }

            if (v.ad_endtime < Utils.time())
            {
                v.ad_url = "";
            }

            v.goods_type = 0;
            if (v.type == 1)
            {
                v.goods_type = await context.CmfShopGoods.Where(x => x.Id == v.goodsid).Select(x => x.Type).FirstOrDefaultAsync();

            }
            v.userinfo  = await HomeService.getUserInfo(lan, v.uid);
            return v;

        }
    }
}
