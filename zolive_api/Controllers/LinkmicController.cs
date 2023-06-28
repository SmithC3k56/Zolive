using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zolive_api.Models;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class LinkmicController : Controller
    {
        private readonly ILinkmicService _linkmicService;
        public LinkmicController(ILinkmicService linkmicService)
        {
            _linkmicService = linkmicService;
        }


        [ActionName("setMic")]
        [HttpGet]
        public async Task<ActionResult> setMic(string lan, ulong uid, string token, int ismic)
        {
            BaseResult result = new BaseResult();
            result.ret = 200;
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };


            var checkToken =await AfterLogin.CheckToken(uid, token);
            if(checkToken == 700)
            {
                rs.code = 700;
                rs.msg = "您的登陆状态失效，请重新登陆！";
                if (lan == "En") rs.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") rs.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                result.data = rs;
                return Json (result);
            }
            rs.msg = "设置成功";
            if (lan == "En") rs.msg = "Set successfully";
            if (lan == "Nam") rs.msg = "Đặt thành công";
            result.data = rs;
            _linkmicService.setMic(uid,ismic);


            return Ok(result);
        }
        }
}
