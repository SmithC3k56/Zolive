using Microsoft.AspNetCore.Mvc;
using zolive_api.Models;
using zolive_api.Models.MsgModel;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class MessageController : Controller
    {
        private newliveContext context;
        private IMessageService MessageService;
        public MessageController(newliveContext _context, IMessageService MessageService)
        {
            this.context = _context;
            this.MessageService = MessageService;

        }
        [ActionName("GetList")]
        [HttpGet]
        public async Task<ActionResult> GetList(string? lan,ulong uid,string token,int p)
        {
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo info = new ResultBaseInfo() { code =0,msg ="",info = new List<MsgModel>()};
            rs.data = info;
            var checkToken = await AfterLogin.CheckToken(uid,token);
            if(checkToken == 700)
            {
                info.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
                info.code = checkToken;
                rs.data = info;
                return Json(rs);
            }

            var list = await MessageService.getList(uid,p);
            info.info = list;
            rs.ret = 200;
            rs.data= info;
            return Json(rs);
        }
    }
}
