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
  public class AgentController : Controller
  {
    private readonly newliveContext context;
    private ILiveService liveService;
    private readonly CacheManager cacheManager = new CacheManager();
    public AgentController(newliveContext _context, ILiveService liveService)
    {
      this.context = _context;
      this.liveService = liveService;
    }
    [ActionName("getCode")]
    [HttpGet]
    public async Task<ActionResult> getCode(string lan, ulong uid, string token)
    {
      BaseResult rs = new BaseResult();
      rs.msg = "";
      rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      rs.ret = 200;
      rs.data = new ResultBaseInfo();
      ResultBaseInfo result = new ResultBaseInfo()
      {
        msg = "",
        code = 0,
        info = new List<GetCodeModel>()
      };
      if (uid <= 0 || string.IsNullOrEmpty(token))
      {
        result.code = 1001;
        result.msg = "参数错误";
        if (lan == "En") result.msg = "Parameter error";
        if (lan == "Nam") result.msg = "Các tham số không đúng";
        rs.data = result;
        return Json(rs);
      }
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        result.code = 700;
        result.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") result.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") result.msg = "Bạn đang đăng nhập không hợp lệ, vui lòng đăng nhập lại!";
        rs.data = result;
        return Json(rs);
      }
      var info = await liveService.getCode(uid);
      if (info == null)
      {
        result.code = 1001;
        result.msg = "信息错误";
        if (lan == "En") result.msg = "Information error";
        if (lan == "Nam") result.msg = "Thông tin không đúng";
        rs.data = result;
        return Json(rs);
      }
      var infoResult = new GetCodeModel();

      infoResult.uid = info.Uid;
      var href = Utils.get_upload_path("/portal/index/scanqr");
      var qr = Utils.scerweima(href);
      infoResult.href = href;
      infoResult.qr = qr;
      infoResult.code = info.Code;
      result.info.Add(infoResult);
      rs.data = result;
      return Json(rs);
    }

  }
}
