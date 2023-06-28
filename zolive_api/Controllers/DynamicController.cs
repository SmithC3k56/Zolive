using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using zolive_api.Models;
using zolive_api.Models.Dynamic;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class DynamicController : Controller
    {
        private readonly newliveContext context;
        private readonly IDynamicSerivce dynamicSerivce;
        private readonly IUserService userService;
        private readonly ICommonService _commonService;
        private readonly CacheManager cacheManager = new CacheManager();
        public DynamicController(ICommonService commonService, newliveContext _context, IDynamicSerivce dynamicSerivce, IUserService userService)
        {
            _commonService = commonService;
            this.context = _context;
            this.dynamicSerivce = dynamicSerivce;
            this.userService = userService;
        }
        [ActionName("getHomeDynamic")]
        [HttpGet]
        public async Task<ActionResult> getHomeDynamic(string lan, ulong uid, ulong touid, string token, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            rs.data = new ResultBaseInfo();
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "";
            dataDynamic.info = new List<DynamicModel>();

            var isban = await AfterLogin.isban(uid);
            if (isban == 0)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "Tài khoản đã bị vô hiệu hóa";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var checktoken = await AfterLogin.CheckToken(uid, token);
            if (checktoken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") dataDynamic.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var info = await dynamicSerivce.getHomeDynamic(lan, uid, touid, p);
            dataDynamic.info = info;
            rs.data = dataDynamic;
            return Json(rs);
        }

        [ActionName("getNewDynamic")]
        [HttpGet]
        public async Task<ActionResult> getNewDynamic(string lan, ulong uid, string token, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo() { code = 0, msg = "" };
            dataDynamic.code = 0;
            dataDynamic.msg = "";
            dataDynamic.info = new List<DynamicModel>();
            var checktoken = await AfterLogin.CheckToken(uid, token);
            if (checktoken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") dataDynamic.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var key = "getNewDynamic_" + p;
            var info = cacheManager.GetCacheString(key);

            if (info == null)
            {
                dataDynamic.info = await dynamicSerivce.getAttentionDynamic(lan, uid, p);
                var time = new TimeSpan(hours: 0, minutes: 60, seconds: 0);
                await cacheManager.SetCacheStrings(key, JsonConvert.SerializeObject(dataDynamic.info), time);
            }
            else
            {
                dataDynamic.info = JsonConvert.DeserializeObject<List<DynamicModel>>(info) ?? new List<DynamicModel>();
            }
            rs.data = dataDynamic;

            return Json(rs);
        }

        [ActionName("getAttentionDynamic")]
        [HttpGet]
        public async Task<ActionResult> getAttentionDynamic(string lan, ulong uid, string token, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            CacheManager cacheManager = new CacheManager();
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "";
            dataDynamic.info = new List<DynamicModel>();
            var checktoken = await AfterLogin.CheckToken(uid, token);
            if (checktoken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") dataDynamic.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var key = "attentionDynamic_" + p;
            var info = cacheManager.GetCacheString(key);

            if (info == null)
            {
                dataDynamic.info = await dynamicSerivce.getAttentionDynamic(lan, uid, p);
                var time = new TimeSpan(hours: 0, minutes: 60, seconds: 0);
                await cacheManager.SetCacheStrings(key, JsonConvert.SerializeObject(dataDynamic.info), time);
            }
            else
            {
                dataDynamic.info = JsonConvert.DeserializeObject<List<DynamicModel>>(info) ?? new List<DynamicModel>();
            }
            rs.data = dataDynamic;

            return Json(rs);
        }

        [ActionName("getRecommendDynamics")]
        [HttpGet]
        public async Task<ActionResult> getRecommendDynamics(string lan, ulong uid, string token, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "";
            dataDynamic.info = new List<DynamicModel>();
            var checktoken = await AfterLogin.CheckToken(uid, token);
            if (checktoken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") dataDynamic.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var key = "dynamicRecommend_" + p;
            var info = cacheManager.GetCacheString(key);

            if (info == null)
            {
                dataDynamic.info = await dynamicSerivce.getRecommendDynamics(lan, uid, p);
                var time = new TimeSpan(hours: 0, minutes: 60, seconds: 0);
                await cacheManager.SetCacheStrings(key, JsonConvert.SerializeObject(dataDynamic.info), time);
            }
            else
            {
                dataDynamic.info = JsonConvert.DeserializeObject<List<DynamicModel>>(info) ?? new List<DynamicModel>();
            }
            rs.data = dataDynamic;

            return Json(rs);
        }

        [ActionName("getComments")]
        [HttpGet]
        public async Task<ActionResult> getComments(string lan, ulong uid, string token, ulong dynamicid, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "";
            dataDynamic.info = new List<GetCommentModel>();
            var checktoken = await AfterLogin.CheckToken(uid, token);
            if (checktoken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") dataDynamic.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var isban = await AfterLogin.isban(uid);
            if (isban == 0)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "该账号已被禁用";
                if (lan == "En") dataDynamic.msg = "The account has been disabled";
                if (lan == "Nam") dataDynamic.msg = "Tài khoản đã bị cấm";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var infos = await dynamicSerivce.getComments(lan, uid, dynamicid, p);
            if (infos != null) dataDynamic.info.Add(infos);
            rs.data = dataDynamic;
            return Json(rs);
        }

        [ActionName("setDynamic")]
        [HttpGet]
        public async Task<ActionResult> setDynamic(string lan, ulong uid, string token, string? city, string? lat, string? lng, int type, string? title, string? thumb, string? video_thumb, string? href, string? address, string? voice, int length, string sign)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "发布成功";
            if (lan == "En") dataDynamic.msg = "Publish Success";
            if (lan == "Nam") dataDynamic.msg = "Đăng thành công";
            dataDynamic.info = new List<GetCommentModel>();
            if (uid <= 0)
            {
                dataDynamic.code = 1001;
                dataDynamic.msg = "信息错误";
                if (lan == "En") dataDynamic.msg = "Information error";
                if (lan == "Nam") dataDynamic.msg = "Thông tin không chính xác";
                rs.data = dataDynamic;
                return Json(rs);
            }
            string[] thumb_ars = { };
            string thumbString = "";
            List<string> thumb_arr = new List<string>();
            if (thumb != null)
            {
                thumb_ars = thumb.Split(";");

                foreach (var i in thumb_ars)
                {
                    string date = System.IO.File.ReadAllText(i);
                    var names = "/yasuo/" + Utils.time() + Utils.LongRandom(100000, 9999999999999) + ".jpeg";
                    await System.IO.File.WriteAllTextAsync("/www/wwwroot/newlive.zwrjkf.cn/web.zwrjkf.com/public" + names, date);

                    //SERVERNAME will set by host name

                    var SERVER_NAME = System.Net.Dns.GetHostName();
                    string vr = "http://" + SERVER_NAME + names;
                    thumb_arr.Add(vr);
                }
                thumbString = string.Join(";", thumb_arr);
            }
            string[] checkdata = { "uid=" + uid, "type=" + type };
            var issign = Utils.checkSign(checkdata, sign);
            if (!issign)
            {
                dataDynamic.code = 1002;
                dataDynamic.msg = "签名错误";
                if (lan == "En") dataDynamic.msg = "Signature error";
                if (lan == "Nam") dataDynamic.msg = "Chữ ký không chính xác";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var checktoken = await AfterLogin.CheckToken(uid, token);
            if (checktoken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") dataDynamic.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var sensitivewords = await userService.sensitiveField(title);
            if (sensitivewords == 1001)
            {
                dataDynamic.code = 10011;
                dataDynamic.msg = "动态标题输入非法，请重新输入";
                if (lan == "En") dataDynamic.msg = "The title of the dynamic input is illegal, please re-enter";
                if (lan == "Nam") dataDynamic.msg = "Tiêu đề của bạn nhập không hợp lệ, vui lòng nhập lại";
                rs.data = dataDynamic;
                return Json(rs);
            }
            CmfDynamic data = new CmfDynamic()
            {
                Uid = uid,
                Title = title,
                Thumb = thumb,
                VideoThumb = video_thumb,
                Href = href,
                Voice = voice,
                Length = length,
                Lat = lat,
                Lng = lng,
                City = city,
                Address = address,
                Type = type,
                Likes = 0,
                Comments = 0,
                ThumbArs = thumbString
            };
            var info = await dynamicSerivce.setDynamic(data);

            if (info == 1007)
            {
                dataDynamic.code = 1007;
                dataDynamic.msg = "视频分类不存在";
                if (lan == "En") dataDynamic.msg = "Video category does not exist";
                if (lan == "Nam") dataDynamic.msg = "Phân loại video không tồn tại";
                rs.data = dataDynamic;
                return Json(rs);
            }
            else if (info == 1003)
            {
                dataDynamic.code = 1003;
                dataDynamic.msg = "您还未认证或认证还未通过";
                if (lan == "En") dataDynamic.msg = "You have not certified or the certification has not been passed";
                if (lan == "Nam") dataDynamic.msg = "Bạn chưa được chứng nhận hoặc chứng nhận chưa được phê duyệt";
                rs.data = dataDynamic;
                return Json(rs);
            }
            else if (info == 1004)
            {
                dataDynamic.code = 1004;
                dataDynamic.msg = "发布失败，请重试";
                if (lan == "En") dataDynamic.msg = "Failed to publish, please try again";
                if (lan == "Nam") dataDynamic.msg = "Không xuất bản được, vui lòng thử lại";
                rs.data = dataDynamic;
                return Json(rs);
            }
            else if (info == 0)
            {
                dataDynamic.code = 1001;
                dataDynamic.msg = "发布失败";
                if (lan == "En") dataDynamic.msg = "Failed to publish";
                if (lan == "Nam") dataDynamic.msg = "Không xuất bản được";
                rs.data = dataDynamic;
                return Json(rs);
            }
            rs.data = dataDynamic;
            return Json(rs);
        }


        [ActionName("addLike")]
        [HttpGet]
        public async Task<ActionResult> addLike(string lan, ulong uid, string token, ulong dynamicid, string sign)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "操作成功";
            dataDynamic.info = new List<LikeModel>();
            if (lan == "En") dataDynamic.msg = "Successful operation";
            if (lan == "Nam") dataDynamic.msg = "Thao tác thành công";
            if (uid < 1 || string.IsNullOrEmpty(token) || dynamicid < 1)
            {
                dataDynamic.code = 1001;
                dataDynamic.msg = "信息错误";
                rs.data = dataDynamic;
                return Json(rs);
            }
            string[] checkdata ={
          "uid="+uid,
          "dynamicid="+dynamicid
      };
            var issign = Utils.checkSign(checkdata, sign);
            if (!issign)
            {
                dataDynamic.code = 1002;
                dataDynamic.msg = "签名错误";
                if (lan == "En") dataDynamic.msg = "Signature error";
                if (lan == "Nam") dataDynamic.msg = "Lỗi chữ ký";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please re-login!";
                if (lan == "Nam") dataDynamic.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }



            var result = await dynamicSerivce.addLike(lan, uid, dynamicid);
            if (result == null)
            {
                dataDynamic.code = 1002;
                dataDynamic.msg = "不能给自己点赞";
                if (lan == "En") dataDynamic.msg = "Can not like yourself";
                if (lan == "Nam") dataDynamic.msg = "Không thể thích bản thân";
                rs.data = dataDynamic;
                return Json(rs);
            }
            dataDynamic.info.Add(result);
            rs.data = dataDynamic;
            return Json(rs);
        }


        [ActionName("setComment")]
        [HttpGet]
        public async Task<ActionResult> setComment(string lan, ulong uid, string token, ulong touid, ulong dynamicid, ulong commentid, ulong parentid, string? content, int type, string? voice, int? length, string? sign)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "评论成功";
            dataDynamic.info = new List<SetComment>();
            if (lan == "En") dataDynamic.msg = "Successful comment";
            if (lan == "Nam") dataDynamic.msg = "Bình luận thành công";
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please re-login!";
                if (lan == "Nam") dataDynamic.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var info = new SetComment()
            {
                isattent = 0,
                u2t = 0,
                t2u = 0,
                comments = 0,
                replys = 0
            };
            if (touid > 0)
            {
                var isattent = await _commonService.isAttention(uid, touid);
                var u2t = await _commonService.isBlack(uid, touid);
                var t2u = await _commonService.isBlack(touid, uid);
                info.isattent = isattent;
                info.u2t = int.Parse(u2t);
                info.t2u = int.Parse(t2u);
                if (int.Parse(t2u) == 1)
                {
                    dataDynamic.code = 1000;
                    dataDynamic.msg = "对方拒绝接收你的消息";
                    if (lan == "En") dataDynamic.msg = "The other party refuses to accept your message";
                    if (lan == "Nam") dataDynamic.msg = "Người khác từ chối nhận tin nhắn của bạn";
                    rs.data = dataDynamic;
                    return Json(rs);
                }
            }
            if (type == 1)
            {
                if (string.IsNullOrEmpty(voice))
                {
                    dataDynamic.code = 1001;
                    dataDynamic.msg = "录音";
                    if (lan == "En") dataDynamic.msg = "Voice recording";
                    if (lan == "Nam") dataDynamic.msg = "Ghi âm";
                    rs.data = dataDynamic;
                    return Json(rs);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(content))
                {
                    dataDynamic.code = 1002;
                    dataDynamic.msg = "请输入内容";
                    if (lan == "En") dataDynamic.msg = "Please enter content";
                    if (lan == "Nam") dataDynamic.msg = "Vui lòng nhập nội dung";
                    rs.data = dataDynamic;
                    return Json(rs);
                }
            }
            var sensitivewords = await userService.sensitiveField(content ?? "");
            if (sensitivewords == 1001)
            {
                dataDynamic.code = 10011;
                dataDynamic.msg = "Nội dung bình luận không hợp lệ, hãy nhập lại";
                if (lan == "En") dataDynamic.msg = "Content of the comment is invalid, please re-enter";
                rs.data = dataDynamic;
                return Json(rs);
            }
            if (commentid == 0 && commentid != parentid)
            {
                commentid = parentid;
            }
            var data = new CmfDynamicComment()
            {
                Uid = uid,
                Touid = touid,
                Dynamicid = dynamicid,
                Commentid = commentid,
                Parentid = parentid,
                Content = content ?? "",
                Addtime = Utils.time(),
                Type = type,
                Voice = voice??"",
                Length = length??0
            };
            var result = await dynamicSerivce.setComment(data);
            info.comments = result.comments;
            info.replys = result.replys;

            dataDynamic.info.Add(info);
            rs.data = dataDynamic;
            return Json(rs);
        }

        [ActionName("addCommentLike")]
        [HttpGet]
        public async Task<ActionResult> addCommentLike(string lan, ulong uid, string token, ulong commentid, string sign)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo();
            dataDynamic.code = 0;
            dataDynamic.msg = "点赞成功";
            dataDynamic.info = new List<LikeModel>();
            if (uid < 1 || string.IsNullOrEmpty(token) || commentid < 1)
            {
                dataDynamic.code = 1001;
                dataDynamic.msg = "信息错误";
                rs.data = dataDynamic;
                return Json(rs);
            }
            string[] checkData = { "uid=" + uid, "commentid=" + commentid };
            var issign = Utils.checkSign(checkData, sign);
            if (!issign)
            {
                dataDynamic.code = 1002;
                dataDynamic.msg = "签名错误";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                dataDynamic.code = 700;
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please re-login!";
                if (lan == "Nam") dataDynamic.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var res = await dynamicSerivce.addCommentLike(lan, uid, commentid);
            if (res == null)
            {
                dataDynamic.code = 1003;
                dataDynamic.msg = "评论信息不存在";
                rs.data = dataDynamic;
                return Json(rs);
            }
            dataDynamic.info.Add(res);
            rs.data = dataDynamic;
            return Json(rs);
        }

        [ActionName("getReportlist")]
        [HttpGet]
        public async Task<ActionResult> getReportlist(string lan)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo() { code = 0, msg = "", info = new List<CmfDynamicReportClassify>() };

            var res = await dynamicSerivce.getReportlist();
            if (res == null)
            {
                dataDynamic.code = 1001;
                dataDynamic.msg = "暂无举报分类列表";
                if (lan == "En") dataDynamic.msg = "No report category list";
                if (lan == "Nam") dataDynamic.msg = "Không có danh mục báo cáo";
                rs.data = dataDynamic;
                return Json(rs);
            }
            foreach (var x in res)
            {
                if (lan == "En") x.Name = x.NameEn;
                if (lan == "Nam") x.Name = x.NameNam;
            }
            dataDynamic.info = res;
            rs.data = dataDynamic;
            return Json(rs);
        }

        [ActionName("report")]
        [HttpGet]
        public async Task<ActionResult> report(string lan, ulong uid, string token, ulong dynamicid, string content)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.ret = 200;
            ResultBaseInfo dataDynamic = new ResultBaseInfo() { code = 0, msg = "举报成功", info = new List<CmfDynamicReportClassify>() };
            if (lan == "En") dataDynamic.msg = "Report success";
            if (lan == "Nam") dataDynamic.msg = "Báo cáo thành công";

            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                dataDynamic.code = 700; 
                dataDynamic.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") dataDynamic.msg = "Your login status is invalid, please re-login!";
                if (lan == "Nam") dataDynamic.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = dataDynamic;
                return Json(rs);
            }
            var data = new CmfDynamicReport()
            {
                Addtime = Utils.time(),
                Content = content,
                Dynamicid = dynamicid,
                Uid = uid
            };
            var info = await dynamicSerivce.report(data);
            if (info == 1000)
            {
                dataDynamic.code = 100;
                dataDynamic.msg = "动态不存在";
                if (lan == "En") dataDynamic.msg = "The dynamic does not exist";
                if (lan == "Nam") dataDynamic.msg = "Không tồn tại bài viết";
                rs.data = dataDynamic;
                return Json(rs);
            }
            rs.data = dataDynamic;
            return Json(rs);
        }

    }
}
