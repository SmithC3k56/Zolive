using Microsoft.AspNetCore.Mvc;
using zolive_api.Models;
using zolive_api.Models.Buyer;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class BuyerController : Controller
    {
        private readonly IBuyerService buyerService;
        public BuyerController(IBuyerService buyerService)
        {
            this.buyerService = buyerService;
        }
        [ActionName("getHome")]
        [HttpGet]
        public async Task<ActionResult> getHome(string? lan, ulong uid, string token)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();
            ResultBaseInfo data = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetHomeModel>() };
            var checkToken = await AfterLogin.CheckToken(uid, token);

            if (checkToken == 700)
            {
                data.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                data.code = 700;
                rs.data = data;
                return Json(rs);
            }
            var res = await buyerService.getHome(uid);
            data.info.Add(res);
            var apply_res = await buyerService.getShopApplyInfo(uid);
            var apply_reason = "";
            if (apply_res.apply_status != -1)
            {
                apply_reason = apply_res.apply_info.reason;
            }
            data.info[0].apply_status = apply_res.apply_status;
            data.info[0].apply_reason = apply_reason;
            rs.ret = 200;
            rs.data = data;
            return Json(rs);
        }
        [ActionName("getGoodsVisitRecord")]
        [HttpGet]
        public async Task<ActionResult> getGoodsVisitRecord(string? lan, ulong uid, string token, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.ret = 200;
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();

            ResultBaseInfo result = new ResultBaseInfo() { code = 0, msg = "", info = new List<ModelNewList>() };
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (uid < 0 || token == "")
            {
                result.code = 1001;
                result.msg = "Thông tin người dùng không hợp lệ";
                rs.data = result;
                return Json(rs);
            }
            else if (checkToken == 700)
            {
                result.code = 700;
                result.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = result;
                return Json(rs);
            }
            var res = await buyerService.getGoodsVisitRecord(lan, uid, p);
            if (res.list != null && res.date != null) { result.info.Add(res); }
            result.info = new List<ModelNewList>();
            rs.data = result;
            return Json(rs);
        }
        [ActionName("addressList")]
        [HttpGet]
        public async Task<ActionResult> addressList(string? lan, ulong uid, string token, long time, string sign)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.ret = 200;
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();
            ResultBaseInfo result = new ResultBaseInfo() { code = 0, msg = "", info = new List<AddressListModel>() };
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                result.code = 700;
                result.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = result;
                return Json(rs);
            }
            var now = Utils.time();
            if (now - time > 300)
            {
                result.code = 1001;
                result.msg = "Lỗi tham số";
                rs.data = result;
                return Json(rs);
            }

            string[] checkdata =  { "time="+time, "token="+token, "uid="+ uid };
            var issign = Utils.checkSign(checkdata, sign);

            if (!issign)
            {
                result.code = 1001;
                result.msg = "Lỗi chữ kí";
                rs.data = result;
                return Json(rs);
            }

            var results = await buyerService.addressList(uid);

            result.info = results;
            rs.data = result;

            return Json(rs);
        }
        [ActionName("getRefundList")]
        [HttpGet]
        public async Task<ActionResult> getRefundList(string? lan, ulong uid, string token, long time, string sign, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();
            ResultBaseInfo result = new ResultBaseInfo() { code = 0, msg = "", info = new List<getRefundListInfo>() };

            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                result.code = 700;
                result.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                rs.data = result;
                return Json(rs);
            }
            var now = Utils.time();
            if (now - time > 300)
            {
                result.code = 1001;
                result.msg = "Lỗi tham số";
                rs.data = result;
                return Json(rs);
            }

            string[] checkdata = { "time=" + time, "token=" + token, "uid=" + uid };
            var issign = Utils.checkSign(checkdata, sign);

            if (!issign)
            {
                result.code = 1001;
                result.msg = "Lỗi chữ kí";
                rs.data = result;
                return Json(rs);
            }
            var res = await buyerService.getRefundList(lan, uid, p);
            var user_balance = await buyerService.getUserShopBalance(uid);
            result.info.Add(new getRefundListInfo() { list = res, user_balance = user_balance });
            rs.data = result;
            return Json(rs);
        }
        [ActionName("getGoodsOrderList")]
        [HttpGet]
        public async Task<ActionResult> getGoodsOrderList(string? lan, ulong uid, string token, string type, long? time, string sign, int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            rs.data = new ResultBaseInfo();
            ResultBaseInfo result = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetGoodsOrderListModel>() };
            string[] type_arr = { "all", "wait_payment", "wait_shipment", "wait_receive", "wait_evaluate", "refund" };

            if (uid < 0 || token == "" || !type_arr.Contains(type) || p < 1 || time == null || string.IsNullOrEmpty(sign))
            {
                result.code = 1001;
                result.msg = "参数错误";
                rs.data = result;
                return Json(rs);
            }
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                result.code = checkToken;
                result.msg = "您的登陆状态失效，请重新登陆！";
                rs.data = result;
                return Json(rs);
            }
            var now = Utils.time();
            if (now - time > 300)
            {
                result.code = 1001;
                result.msg = "参数错误";
                rs.data = result;
                return Json(rs);
            }
            string[] checkdata = { "time=" + time, "token=" + token, "uid=" + uid };
            var issign = Utils.checkSign(checkdata, sign);
            if (!issign)
            {
                result.code = 1001;
                result.msg = "签名错误";
                rs.data = result;
                return Json(rs);
            }
            result.info = await buyerService.getGoodsOrderList(lan, uid, type, p);
            rs.data = result;
            return Json(rs);
        }
    }
}
