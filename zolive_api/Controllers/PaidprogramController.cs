using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zolive_api.Models;
using zolive_api.Models.Paidprogram;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class PaidprogramController : Controller
    {
        private newliveContext context;
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly IPaidprogram paidprogramService;
        private readonly ILoginService loginService;
        private readonly ICommonService _commonService;
        public PaidprogramController(ICommonService commonService,newliveContext context, IPaidprogram paidprogramService, ILoginService loginService)
        {
            this._commonService = commonService;
            this.context = context;
            this.paidprogramService = paidprogramService;
            this.loginService = loginService;
        }
        [ActionName("getPaidProgramList")]
        [HttpGet]
        public async Task<ActionResult> getPaidProgramList(string lan, ulong uid, string token, long time, string sign, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.msg = "";
            rs.ret = 200;
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();
            ResultBaseInfo result = new ResultBaseInfo() { code = 0, msg = "", info = new List<PaidProgramModel>() };

            if (uid < 0 || string.IsNullOrEmpty(token) || time <= 0 || string.IsNullOrEmpty(sign))
            {
                result.code = 1001;
                result.msg = "参数错误";
                if (lan == "En") result.msg = "Parameter error";
                if (lan == "Nam") result.msg = "Tham số không hợp lệ";
                rs.data = result;
                return Json(rs);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                result.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") result.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") result.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.code = 700;
                rs.data = result;
                return Json(rs);
            }
            var now = Utils.time();
            if (now - time > 300)
            {
                result.code = 1001;
                result.msg = "参数错误";
                if (lan == "En") result.msg = "Parameter error";
                if (lan == "Nam") result.msg = "Tham số không hợp lệ";
                rs.data = result;
                return Json(rs);
            }
            string[] checkdata = { "time=" + time, "token=" + token, "uid=" + uid };
            var issign = Utils.checkSign(checkdata, sign);
            if (!issign)
            {
                result.code = 1001;
                result.msg = "签名错误";
                if (lan == "En") result.msg = "Signature error";
                if (lan == "Nam") result.msg = "Chữ ký không hợp lệ";
                rs.data = result;
                return Json(rs);
            }
            var res = await paidprogramService.getPaidProgramList(lan, uid, p);
            if (res != null)
            {
                result.info = res;
            }
            rs.data = result;
            return Json(rs);
        }

        [ActionName("getApplyStatus")]
        [HttpGet]
        public async Task<ActionResult> getApplyStatus(string lan, ulong uid, string token, long time, string sign)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.msg = "";
            rs.ret = 200;
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();
            ResultBaseInfo result = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetApplyStatusModel>() };
            GetApplyStatusModel infors = new GetApplyStatusModel();
            if (uid < 1 || string.IsNullOrEmpty(token))
            {
                result.code = 1001;
                result.msg = "参数错误";
                if (lan == "En") result.msg = "Parameter error";
                if (lan == "Nam") result.msg = "Tham số không hợp lệ";
                rs.data = result;
                return Json(rs);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                result.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") result.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") result.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.code = 700;
                rs.data = result;
                return Json(rs);
            }
            var now = Utils.time();
            if (now - time > 300)
            {
                result.code = 1001;
                result.msg = "参数错误";
                if (lan == "En") result.msg = "Parameter error";
                if (lan == "Nam") result.msg = "Tham số không hợp lệ";
                rs.data = result;
                return Json(rs);
            }
            infors.isauth = 1;
            var title = "申请开通付费内容权限需要先进行实名认证";
            if (lan == "En") title = "To apply for the right to pay for the content, you need to first do the real-name authentication";
            if (lan == "Nam") title = "Để đăng ký quyền sử dụng nội dung trả phí, bạn cần phải đăng ký thông tin thật của mình";
            infors.auth_msg = title;
            var configpri = await _commonService.getConfigPri();
            if (int.Parse(configpri.auth_islimit.Value) == 1)
            {
                var isAuth = await loginService.isAuth(uid);
                if (!isAuth)
                {
                    infors.isauth = 0;
                    result.info.Add(infors);
                    rs.data = result;
                    return Json(rs);
                }
            }
            var apply_status = await paidprogramService.getApplyStatus(uid);
            title = "";
            var desc = "";
            var payment_title = "";
            var configpub = await _commonService.getConfigPub();
            switch (apply_status)
            {
                case -2:
                    title = "申请说明";
                    if (lan == "En") title = "Apply for instructions";
                    if (lan == "Nam") title = "Hướng dẫn đăng ký";
                    desc = configpub.payment_des.Value;
                    if (lan == "En") desc = configpub.payment_des_en.Value;
                    if (lan == "Nam") desc = configpub.payment_des_nam.Value;
                    var de = "平台付费内容管理规范协议说明";
                    if (lan == "En") de = "Platform payment content management rules";
                    if (lan == "Nam") de = "Quy định quản lý nội dung trả phí";
                    payment_title = "《" + de + "》";
                    break;

                case -1:
                    title = "申请未通过";
                    if (lan == "En") title = "Apply not passed";
                    if (lan == "Nam") title = "Không được phép";
                    desc = "您的申请被拒" + configpub.payment_time.Value + "日后可再次申请,如有疑问可咨询平台客服";
                    if (lan == "En") desc = "Your application was rejected " + configpub.payment_time.Value + " days later, you can apply again if there are any questions, please consult the platform customer service";
                    if (lan == "Nam") desc = "Bạn không được phép đăng ký " + configpub.payment_time.Value + " ngày sau, nếu có bất kỳ thắc mắc nào, vui lòng liên hệ với chúng tôi";
                    break;
                case 0:
                    title = "申请已提交";
                    if (lan == "En") title = "Apply has been submitted";
                    if (lan == "Nam") title = "Đã đăng ký";
                    desc = "审核通过后即可上传付费内容";
                    if (lan == "En") desc = "You can start uploading paid content after passing review";
                    if (lan == "Nam") desc = "Sau khi được chấp nhận, bạn có thể tải lên nội dung trả phí";
                    break;
                case 1:
                    title = "申请已通过";
                    if (lan == "En") title = "Apply has been approved";
                    if (lan == "Nam") title = "Đã được phép";
                    desc = "审核通过,可上传付费内容";
                    if (lan == "En") desc = "Application completed, you can start to upload paid content";
                    if (lan == "Nam") desc = "Đã được duyệt, bạn có thể tải lên nội dung trả phí";
                    break;
            }
            infors.apply_status = apply_status;
            infors.title = title;
            infors.desc = desc;
            infors.payment_title = payment_title;
            result.info.Add(infors);
            rs.data = result;
            return Json(rs);
        }
        [ActionName("apply")]
        [HttpGet]
        public async Task<ActionResult> apply(string lan, ulong uid, string token, long time, string sign)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "申请成功";
            if (lan == "En") rs.msg = "Apply successfully";
            if (lan == "Nam") rs.msg = "Đăng ký thành công";
            rs.ret = 200;
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();
            ResultBaseInfo result = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };

            if (uid < 1 || string.IsNullOrEmpty(token))
            {
                result.code = 1001;
                result.msg = "参数错误";
                if (lan == "En") result.msg = "Parameter error";
                if (lan == "Nam") result.msg = "Tham số không đúng";
                rs.data = result;
                return Json(rs);
            }

            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                result.code = 700;
                result.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") result.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") result.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = result;
                return Json(rs);
            }
            var now = Utils.time();
            if (now - time > 300)
            {
                result.code = 1001;
                result.msg = "参数错误";
                if (lan == "En") result.msg = "Parameter error";
                if (lan == "Nam") result.msg = "Tham số không đúng";
                rs.data = result;
                return Json(rs);
            }

            string[] checkdata = { "time=" + time, "token=" + token, "uid=" + uid };
            var issign = Utils.checkSign(checkdata, sign);
            if (!issign)
            {
                result.code = 1001;
                result.msg = "签名错误";
                if (lan == "En") result.msg = "Signature error";
                if (lan == "Nam") result.msg = "Chữ ký không đúng";
                rs.data = result;
                return Json(rs);
            }
            var isAuth = await loginService.isAuth(uid);
            if (!isAuth)
            {
                result.code = 1002;
                result.msg = "申请开通付费内容权限需要先进行实名认证";
                if (lan == "En") result.msg = "Apply for paid content permission requires first to perform real-name authentication";
                if (lan == "Nam") result.msg = "Đăng ký trả phí yêu cầu đầu tiên phải thực hiện xác thực thẻ thẻ tín dụng";
                rs.data = result;
                return Json(rs);
            }
            var res = await paidprogramService.apply(uid);
            if(res ==1001){
                result.code =1001;
                result.msg = "申请已通过,不可重复申请";
                if (lan == "En") result.msg = "Apply has been approved, you can not apply again";
                if (lan == "Nam") result.msg = "Đã được phép, bạn không thể đăng ký lại";
                rs.data = result;
                return Json(rs);
            }else if(res ==1002){
                result.code= 1002;
                result.msg ="正在审核中,请耐心等待";
                if (lan == "En") result.msg = "Under review, please wait patiently";
                if (lan == "Nam") result.msg = "Đang được duyệt, vui lòng chờ";
                rs.data = result;
                return Json(rs);
            }else if (res ==1003){ 
                result.code= 1003;
                result.msg ="申请太频繁,请过段时间再试";
                if (lan == "En") result.msg = "Apply too frequently, please try again later";
                if (lan == "Nam") result.msg = "Đăng ký quá thường xuyên, vui lòng thử lại sau";
                rs.data = result;
                return Json(rs);
            }else if(res == 1004){
                result.code= 1004;
                result.msg ="申请失败,请重试";
                if (lan == "En") result.msg = "Apply failed, please try again";
                if (lan == "Nam") result.msg = "Đăng ký thất bại, vui lòng thử lại";
                rs.data = result;
                return Json(rs);
            }
            rs.data = result;
            return Json(rs);
        }
    }
}

