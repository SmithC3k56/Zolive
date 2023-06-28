using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zolive_api.Models;
using zolive_api.Models.Livemanage;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class LivemanageController : Controller
    {

        private readonly newliveContext context;
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly ILivemanage livemanageService;
        public LivemanageController(newliveContext _context, ILivemanage livemanageService)
        {
            this.context = _context;
            this.livemanageService = livemanageService;
        }

        [ActionName("getRoomList")]
        [HttpGet]
        public async Task<ActionResult> getRoomList(string lan, ulong uid, string token, int p)
        {
            BaseResult baseResult = new BaseResult();
            baseResult.msg = "";
            baseResult.ret = 200;
            baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetRoomListModel>() };

            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                rs.code = 700;
                rs.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") rs.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") rs.msg = "Bạn đang đăng nhập không hợp lệ, vui lòng đăng nhập lại!";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var list = await livemanageService.getRoomList(lan, uid);
            if (list != null)
            {
                rs.info = list;
            }
            baseResult.data = rs;
            return Json(baseResult);
        }

        [ActionName("getShutList")]
        [HttpGet]
        public async Task<ActionResult> getShutList(string lan, ulong uid, ulong liveuid, string token, int p)
        {
            BaseResult baseResult = new BaseResult();
            baseResult.msg = "";
            baseResult.ret = 200;
            baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetRoomListModel>() };
            if (uid <= 0 || liveuid <= 0 || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(lan))
            {
                rs.code = 1001;
                rs.msg = "参数错误";
                if (lan == "En") rs.msg = "Parameter error";
                if (lan == "Nam") rs.msg = "Các tham số không hợp lệ";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                rs.code = 700;
                rs.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") rs.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") rs.msg = "Bạn đang đăng nhập không hợp lệ, vui lòng đăng nhập lại!";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var uidtype = await AfterLogin.isAdmin(uid, liveuid);
            if (uidtype == 30)
            {
                rs.code = 1001;
                rs.msg = "您不是该直播间的管理员，无权操作";
                if (lan == "En") rs.msg = "You are not the administrator of the live room, you are not authorized to operate";
                if (lan == "Nam") rs.msg = "Bạn không phải là người quản lý của phòng trò chuyện, không có quyền thao tác";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var list = await livemanageService.getShutList(lan, liveuid);
            if (list != null)
            {
                rs.info = list;
            }
            baseResult.data = rs;
            return Json(baseResult);
        }


        [ActionName("getKickList")]
        [HttpGet]
        public async Task<ActionResult> getKickList(string lan, ulong uid, string token, ulong liveuid, int p)
        {
            BaseResult baseResult = new BaseResult();
            baseResult.msg = "";
            baseResult.ret = 200;
            baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetRoomListModel>() };
            if (uid <= 0 || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(lan))
            {
                rs.code = 1001;
                rs.msg = "参数错误";
                if (lan == "En") rs.msg = "Parameter error";
                if (lan == "Nam") rs.msg = "Các tham số không hợp lệ";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                rs.code = 700;
                rs.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") rs.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") rs.msg = "Bạn đang đăng nhập không hợp lệ, vui lòng đăng nhập lại!";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var uidtype = await AfterLogin.isAdmin(uid, liveuid);
            if (uidtype == 30)
            {
                rs.code = 1001;
                rs.msg = "您不是该直播间的管理员，无权操作";
                if (lan == "En") rs.msg = "You are not the administrator of the live room, you are not authorized to operate";
                if (lan == "Nam") rs.msg = "Bạn không phải là người quản lý của phòng trò chuyện, không có quyền thao tác";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var list = await livemanageService.getKickList(lan, uid);
            if (list != null)
            {
                rs.info = list;
            }
            baseResult.data = rs;
            return Json(baseResult);
        }
    }
}
