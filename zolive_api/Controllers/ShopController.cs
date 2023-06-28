using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zolive_api.Models;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{

    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class ShopController : Controller
    {

        private readonly IUserService _userService;
        private readonly ICommonService _commonService;
        private readonly newliveContext context;
        private readonly CacheManager cacheManager = new CacheManager();
        public ShopController(newliveContext newliveContext, IUserService userService, ICommonService commonService)
        {
            _userService = userService;
            _commonService = commonService;
            context = newliveContext;
        }

        [ActionName("getShop")]
        [HttpGet]
        public async Task<ActionResult> getShop(string lan, ulong uid, string token, ulong touid, int p)
        {
            BaseResult result = new BaseResult();
            result.ret = 200;
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };

            var checkToken = await AfterLogin.CheckToken(uid, token);
            if(checkToken == 700)
            {
                rs.code = 700;
                rs.msg = "您的登陆状态失效，请重新登陆！";
                if(lan =="En") rs.msg = "Your login status is invalid, please log in again!";
                if(lan =="Nam") rs.msg = "Bạn đang đăng nhập không hợp lệ, vui lòng đăng nhập lại!";
                result.data = rs;
                return Json(result);
            }
            var info =  _userService.getShop(lan, touid).Result;
            if(info == null){
                rs.code = 1001;
                rs.msg = "店铺不存在";
                if(lan =="En") rs.msg = "Shop does not exist";  
                if(lan =="Nam") rs.msg = "Cửa hàng không tồn tại";  
                result.data = rs;
                return Json(result);
            }
            var list = await _userService.getGoodsList(touid,1,p);
            info.goods_nums  = await _userService.countGoods(touid,1);
            info.isattention = await _commonService.isAttention(uid,touid); 
            var body = new {
                shop_info = info,
                list = list
            };
            rs.info.Add(body);
            return Ok(result);
        }

    }
}
