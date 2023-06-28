using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using zolive_api.Models;
using zolive_api.Models.Dynamic;
using zolive_api.Models.Video;
using zolive_api.Services.Interface;
using zolive_api.Services.Video;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class VideoController : Controller
    {
        private readonly newliveContext context;
        private readonly IVideoService VideoService;
        private readonly IUserService UserService;
        private readonly IPaidprogram paidprogramService;
        private readonly ICommonService _commonService;
        public VideoController(IPaidprogram paidprogram, ICommonService commonService, newliveContext newlivecontext, IVideoService VideoService, IUserService userService)
        {
            this.paidprogramService = paidprogram;
            _commonService = commonService;
            this.context = newlivecontext;
            this.VideoService = VideoService;
            this.UserService = userService;
        }

        [ActionName("getHomeVideo")]
        [HttpGet]
        public async Task<ActionResult> getHomeVideo(string lan, ulong uid, ulong touid, int p)
        {
            BaseResult baseResult = new BaseResult();
            baseResult.msg = "";
            baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            baseResult.ret = 200;
            ResultBaseInfo data = new ResultBaseInfo();
            var isBan = await AfterLogin.isban(uid);
            if (isBan == 0)
            {
                return Json("");
            }
            var info = await UserService.getHomeVideo(lan, uid, touid, p);
            data.msg = "";
            data.code = 0;
            data.info = info;
            baseResult.data = new ResultBaseInfo();
            baseResult.data = data;


            return Json(baseResult);
        }
        [ActionName("GetVideoList")]
        [HttpGet]
        public async Task<ActionResult> GetVideoList(string? lan, ulong uid, string token, int p)
        {
            BaseResult result = new BaseResult()
            {
                msg = "",
                debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" },
                ret = 200
            };

            ResultBaseInfo data = new ResultBaseInfo() { code = 0,msg="Thành công",info = new List<VideoModel>() };
            var isBan = await AfterLogin.isban(uid);
            if (isBan == 0)
            {
                data.code = 700;
                if (lan == "Nam")
                {
                    data.msg = "Tài khoản đã bị vô hiệu hóa";
                }
                else
                {
                    data.msg = "The account has been disabled";
                }
                result.data = data;
                return Json(result);
            }
            
            CacheManager cacheManager = new CacheManager();
            var key = "videoHot_" + p;
            var cachvideos = cacheManager.GetCacheString(key);
            if (cachvideos == null)
            //if (true)
            {
                data.info = await VideoService.getVideoList(lan, uid, p);
                if (data.info.Count > 0)
                {
                    TimeSpan time = new TimeSpan(hours: 0, minutes: 30, seconds: 0);
                    await cacheManager.SetCacheStrings(key, JsonConvert.SerializeObject(data.info), time);
                }
            }
            else
            {
                data.info = JsonConvert.DeserializeObject<IList<VideoModel>>(cachvideos ?? "") ?? new List<VideoModel>();
            }

            result.data = data;


            return Json(result);
        }


        [ActionName("addView")]
        [HttpGet]
        public async Task<ActionResult> addView(string? lan, ulong uid, string token, ulong videoid, string random_str)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new ResultBaseInfo();
            ResultBaseInfo data = new ResultBaseInfo();
            data.info = new List<object>();
            var checkToken = await AfterLogin.CheckToken(uid, token);

            if (checkToken == 700)
            {
                data.code = 700;
                data.msg = "Thông tin đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            var rs = await VideoService.addView(videoid);
            if (rs)
            {
                data.code = 0;
                data.msg = "Thành công";
                result.data = data;
                return Json(result);
            }
            else
            {
                data.code = 700;
                data.msg = "Thông tin tài khoản không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            return Json("");
        }


        [ActionName("setConversion")]
        [HttpGet]
        public async Task<ActionResult> setConversion(string? lan, ulong uid, string token, ulong videoid, string random_str)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new ResultBaseInfo();
            ResultBaseInfo data = new ResultBaseInfo();
            data.info = new List<object>();
            var checkToken = await AfterLogin.CheckToken(uid, token);

            if (checkToken == 700)
            {
                data.code = 700;
                data.msg = "Thông tin đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            var rs = await VideoService.setConversion(videoid);
            if (rs)
            {
                data.code = 0;
                data.msg = "Thành công";
                result.data = data;
                return Json(result);
            }
            else
            {
                data.code = 700;
                data.msg = "Thông tin tài khoản không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            return Json("");
        }

        [ActionName("getClassVideo")]
        [HttpGet]
        public async Task<ActionResult> getClassVideo(string? lan, ulong uid, string token, int videoclassid, int p)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<VideoModel>();
            ResultBaseInfo data = new ResultBaseInfo();
            data.info = new List<VideoModel>();
            data.msg = "";
            if (videoclassid == 0)
            {
                data.code = 0;
                result.data = data;
                return Json(result);
            }
            var res = await VideoService.getClassVideo(lan, videoclassid, uid, p);
            data.info = res;
            result.data = data;
            return Json(result);
        }

        [ActionName("addLike")]
        [HttpGet]
        public async Task<ActionResult> addLike(string lan, ulong uid, string token, ulong videoid)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<VideoModel>();
            ResultBaseInfo data = new ResultBaseInfo()
            {
                code = 0,
                msg = "点赞成功",
                info = new List<LikeModel>()
            };
            if (lan == "En") data.msg = "Like success";
            if (lan == "Nam") data.msg = "Thành công";

            var isban = await AfterLogin.isban(uid);
            if (isban == 0)
            {
                data.code = 700;
                data.msg = "该账号已被禁用";
                if (lan == "En") data.msg = "The account has been banned";
                if (lan == "Nam") data.msg = "Tài khoản đã bị cấm";
                result.data = data;
                return Json(result);
            }
            var checktoken = await AfterLogin.CheckToken(uid, token);
            if (checktoken == 700)
            {
                data.code = 700;
                data.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") data.msg = "The information of login is invalid, please log in again!";
                if (lan == "Nam") data.msg = "Thông tin đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }

            var rslt = await VideoService.addLike(lan, uid, videoid);
            if (rslt == null)
            {
                data.code = 1001;
                data.msg = "视频已删除";
                if (lan == "En") data.msg = "The video has been deleted";
                if (lan == "Nam") data.msg = "Video đã bị xóa";
                result.data = data;
                return Json(result);
            }
            data.info.Add(rslt);
            result.data = data;
            return Json(result);
        }

        [ActionName("getComments")]
        [HttpGet]
        public async Task<ActionResult> getComments(string lan, ulong uid, string token, ulong videoid, int p)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<VideoModel>();
            ResultBaseInfo data = new ResultBaseInfo()
            {
                code = 0,
                msg = "",
                info = new List<ResultComment>()
            };
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                data.code = 700;
                data.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") data.msg = "The information of login is invalid, please log in again!";
                if (lan == "Nam") data.msg = "Thông tin đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            var isban = await AfterLogin.isban(uid);
            if (isban == 0)
            {
                data.code = 700;
                data.msg = "该账号已被禁用";
                if (lan == "En") data.msg = "The account has been banned";
                if (lan == "Nam") data.msg = "Tài khoản đã bị cấm";
                result.data = data;
                return Json(result);
            }
            var info = await VideoService.getComments(lan, uid, videoid, p);
            if (info != null) data.info.Add(info);
            result.data = data;

            return Json(result);
        }


        [ActionName("addCommentLike")]
        [HttpGet]
        public async Task<ActionResult> addCommentLike(string lan, ulong uid, string token, ulong commentid, int p)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<VideoModel>();
            ResultBaseInfo data = new ResultBaseInfo()
            {
                code = 0,
                msg = "点赞成功",
                info = new List<LikeModel>()
            };
            if (lan == "En") data.msg = "Like success";
            if (lan == "Nam") data.msg = "Thành công";
            var isban = await AfterLogin.isban(uid);
            if (isban == 0)
            {
                data.code = 700;
                data.msg = "该账号已被禁用";
                if (lan == "En") data.msg = "The account has been banned";
                if (lan == "Nam") data.msg = "Tài khoản đã bị cấm";
                result.data = data;
                return Json(result);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                data.code = 700;
                data.msg = "您的登陆状态失效，请重新登陆！";
                result.data = data;
                return Json(result);
            }

            var res = await VideoService.addCommentLike(lan, uid, commentid);
            if (res == null)
            {
                data.code = 1001;
                data.msg = "评论信息不存在";
                if (lan == "En") data.msg = "The comment information does not exist";
                if (lan == "Nam") data.msg = "Thông tin bình luận không tồn tại";
                result.data = data;
                return Json(result);
            }
            data.info.Add(res);
            result.data = data;
            return Json(result);
        }

        [ActionName("setComment")]
        [HttpGet]
        public async Task<ActionResult> setComment(string lan, ulong uid, string token, ulong touid, ulong videoid, ulong commentid, ulong parentid, string content, string? at_info)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<ResultBaseInfo>();
            ResultBaseInfo data = new ResultBaseInfo()
            {
                code = 0,
                msg = "评论成功",
                info = new List<SetComment>()
            };
            if (lan == "En") data.msg = "LikeComment successful";
            if (lan == "Nam") data.msg = "Thành công";
            if (string.IsNullOrEmpty(at_info))
            {
                at_info = "";
            }

            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                data.code = 700;
                data.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") data.msg = "The information of login is invalid, please log in again!";
                if (lan == "Nam") data.msg = "Thông tin đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            var sensitivewords = await UserService.sensitiveField(content);
            if (sensitivewords == 1001)
            {
                data.code = 10011;
                data.msg = "输入非法，请重新输入";
                if (lan == "En") data.msg = "Illegal input, please re-enter";
                if (lan == "Nam") data.msg = "Nhập không hợp lệ, vui lòng nhập lại";
                result.data = data;
                return Json(result);
            }
            if (commentid == 0 && commentid != parentid)
            {
                commentid = parentid;
            }
            var dataInfo = new CmfVideoComment()
            {
                Uid = uid,
                Touid = touid,
                Videoid = videoid,
                Commentid = commentid,
                Parentid = parentid,
                Content = content,
                Addtime = Utils.time(),
                AtInfo = at_info
            };
            var res = await VideoService.setComment(dataInfo);
            var info = new SetComment()
            {
                isattent = 0,
                u2t = 0,
                t2u = 0,
                comments = res.comments,
                replys = res.replys
            };
            if (touid > 0)
            {
                var isattent = await _commonService.isAttention(touid, uid);
                var u2t = await _commonService.isBlack(uid, touid);
                var t2u = await _commonService.isBlack(touid, uid);
                info.isattent = isattent;
                info.u2t = int.Parse(u2t);
                info.t2u = int.Parse(t2u);
            }
            data.info.Add(info);
            result.data = data;
            return Json(result);
        }

        [ActionName("getReportContentlist")]
        [HttpGet]
        public async Task<ActionResult> getReportContentlist(string lan)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<ResultBaseInfo>();
            ResultBaseInfo data = new ResultBaseInfo()
            {
                code = 0,
                msg = "",
                info = new List<CmfVideoReportClassify>()
            };
            var res = await VideoService.getReportContentlist();
            if (res != null)
            {
                foreach (var item in res)
                {
                    if (lan == "En") item.Name = item.NameEn;
                    if (lan == "Nam") item.Name = item.NameNam;
                }
            }
            else
            {
                data.code = 1001;
                data.msg = "暂无举报分类列表";
                if (lan == "En") data.msg = "No report category list";
                if (lan == "Nam") data.msg = "Không có danh mục báo cáo";
                result.data = data;
                return Json(result);
            }
            data.info = res;
            result.data = data;
            return Json(result);
        }


        [ActionName("report")]
        [HttpGet]
        public async Task<ActionResult> report(string lan, ulong uid, string token, ulong videoid, int type, string content)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<ResultBaseInfo>();
            ResultBaseInfo data = new ResultBaseInfo()
            {
                code = 0,
                msg = "",
                info = new List<CmfVideoReportClassify>()
            };
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                data.code = 700;
                data.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") data.msg = "The information of login is invalid, please log in again!";
                if (lan == "Nam") data.msg = "Thông tin đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            var infodata = new CmfVideoReport()
            {
                Uid = uid,
                Videoid = videoid,
                Content = content,
                Addtime = Utils.time(),
            };
            var info = await VideoService.report(infodata);
            if (info == 1000)
            {
                data.code = 1000;
                data.msg = "视频不存在";
                result.data = data;
                return Json(result);
            }
            result.data = data;
            return Json(result);
        }
        [ActionName("setVideo")]
        [HttpGet]
        public async Task<ActionResult> setVideo(string lan, ulong uid, string token, string title, string thumb, string href, string href_w, string lat, string lng, string? city, int music_id, int type, ulong goodsid, int classid)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.ret = 200;
            result.data = new List<ResultBaseInfo>();
            ResultBaseInfo data = new ResultBaseInfo()
            {
                code = 0,
                msg = "",
                info = new List<dynamic>()
            };
            if (classid < 1)
            {
                data.code = 10012;
                data.msg = "请选择分类";
                if (lan == "En") data.msg = "Please select the category";
                if (lan == "Nam") data.msg = "Vui lòng chọn danh mục";
                result.data = data;
                return Json(result);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                data.code = 700;
                data.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") data.msg = "The information of login is invalid, please log in again!";
                if (lan == "Nam") data.msg = "Thông tin đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = data;
                return Json(result);
            }
            var sensitivewords = await UserService.sensitiveField(title);
            if (sensitivewords == 1001)
            {
                data.code = 10011;
                data.msg = "输入非法，请重新输入";
                if (lan == "En") data.msg = "Illegal input, please re-enter";
                if (lan == "Nam") data.msg = "Nhập không hợp lệ, vui lòng nhập lại";
                result.data = data;
                return Json(result);
            }

            var thumb_s = "";
            if (!string.IsNullOrEmpty(thumb)) thumb_s = thumb + "?imageView2/2/w/200/h/200";
            var dataParam = new CmfVideo()
            {
                Uid = uid,
                Title = title,
                Thumb = thumb,
                ThumbS = thumb_s,
                Href = href,
                HrefW = href_w,
                Lat = lat,
                Lng = lng,
                City = city,
                Likes = 0,
                Views = 1,
                Comments = 0,
                Addtime = Utils.time(),
                MusicId = music_id,
                Classid = classid
            };

            if (type > 0)
            {
                if (type == 1 && goodsid > 0)
                {
                    var goodinfo = await context.CmfShopGoods.Where(x => x.Id == goodsid).FirstOrDefaultAsync();
                    if (goodinfo == null)
                    {
                        data.code = 1006;
                        data.msg = "商品不存在";
                        if (lan == "En") data.msg = "The goods does not exist";
                        if (lan == "Nam") data.msg = "Sản phẩm không tồn tại";
                        result.data = data;
                        return Json(result);
                    }
                    if (goodinfo.Uid != uid)
                    {
                        data.code = 1002;
                        data.msg = "非本人商品";
                        if (lan == "En") data.msg = "It is not your goods";
                        if (lan == "Nam") data.msg = "Không phải sản phẩm của bạn";
                        result.data = data;
                        return Json(result);
                    }
                    if (goodinfo.Status == -2)
                    {
                        data.code = 1003;
                        data.msg = "该商品已被下架";
                        if (lan == "En") data.msg = "This item has been removed";
                        if (lan == "Nam") data.msg = "Sản phẩm này đã bị xóa";
                        result.data = data;
                        return Json(result);
                    }
                    if (goodinfo.Status == -1)
                    {
                        data.code = 1004;
                        data.msg = "该商品已下架";
                        if (lan == "En") data.msg = "This item has been discontinued";
                        if (lan == "Nam") data.msg = "Sản phẩm này đã bị tạm ngưng";
                        result.data = data;
                        return Json(result);
                    }
                    if (goodinfo.Status != 1)
                    {
                        data.code = 1005;
                        data.msg = "该商品未通过审核";
                        if (lan == "En") data.msg = "This item has not been approved";
                        if (lan == "Nam") data.msg = "Sản phẩm này chưa được duyệt";
                        result.data = data;
                        return Json(result);
                    }

                    dataParam.Type = type;
                    dataParam.Goodsid = goodsid;
                }
                else if (type == 2 && goodsid > 0)
                {
                    var paidprogram_info = await context.CmfPaidprograms.Where(x => x.Id == (long)goodsid).FirstOrDefaultAsync();
                    if (paidprogram_info == null)
                    {
                        data.code = 1007;
                        data.msg = "付费内容不存在";
                        if (lan == "En") data.msg = "The paid content does not exist";
                        if (lan == "Nam") data.msg = "Nội dung đã mua không tồn tại";
                        result.data = data;
                        return Json(result);
                    }
                    if (paidprogram_info.Uid != (long)uid)
                    {
                        data.code = 1008;
                        data.msg = "非本人发布的付费内容";
                        if (lan == "En") data.msg = "It is not your paid content";
                        if (lan == "Nam") data.msg = "Nội dung đã mua không phải của bạn";
                        result.data = data;
                        return Json(result);
                    }
                    if (paidprogram_info.Status == false)
                    {
                        data.code = 1009;
                        data.msg = "该付费内容未通过审核";
                        if (lan == "En") data.msg = "This paid content has not been reviewed";
                        if (lan == "Nam") data.msg = "Nội dung đã mua chưa được duyệt";
                        result.data = data;
                        return Json(result);
                    }

                    dataParam.Type = type;
                    dataParam.Goodsid = goodsid;
                }
                var info = await VideoService.setVideo(dataParam, music_id);
                if (info == 1007)
                {
                    data.code = 1007;
                    data.msg = "视频分类不存在";
                    if (lan == "En") data.msg = "The video category does not exist";
                    if (lan == "Nam") data.msg = "Phân loại video không tồn tại";
                    result.data = data;
                    return Json(result);
                }
                else if (info != 1)
                {
                    data.code = 1001;
                    data.msg = "发布失败";
                    if (lan == "En") data.msg = "Publish failed";
                    if (lan == "Nam") data.msg = "Đăng bị lỗi";
                    result.data = data;
                    return Json(result);
                }
            }

            var body = new
            {
                id = dataParam.Id,
                thumb_s = Utils.get_upload_path(thumb_s),
                title = title
            };
            data.info.Add(body);
            result.data = data;

            return Json(result);
        }
        [ActionName("getCon")]
        [HttpGet]
        public async Task<ActionResult> getCon(string lan, ulong uid)
        {
            BaseResult result = new BaseResult();
            result.msg = "";
            result.ret = 200;
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.data = new ResultBaseInfo();
            ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };

            var isshop = 1;

            var is_shop = await _commonService.checkShopIsPass(uid);
            var is_paidprogram = await _commonService.checkPaidProgramIsPass(uid);
            if (is_shop == 0 && is_paidprogram == 0)
            {
                isshop = 0;
            }
            var body = new
            {
                isshop = isshop
            };
            rsdata.info.Add(body);
            result.data = rsdata;

            return Json(result);
        }

    }
}
