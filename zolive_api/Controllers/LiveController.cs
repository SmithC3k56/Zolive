using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using zolive_api.Models;
using zolive_api.Models.Live;
using zolive_api.Models.Livemanage;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
  [Route("appapi/[controller].[action]")]
  [ApiController]
  public class LiveController : Controller
  {
    private readonly IHomeService _homeService;
    private readonly ICommonService _commonService;
    private readonly IUserService _userService;
    private readonly newliveContext context;
    private readonly CacheManager cacheManager = new CacheManager();
    private readonly ILiveService liveService;
    private readonly IConfiguration _config;
    public LiveController(newliveContext _context, IConfiguration config, ICommonService commonService, IHomeService homeService, ILiveService liveService, IUserService userService)
    {
      this._config = config;
      this._userService = userService;
      this._homeService = homeService;
      this.context = _context;
      this._commonService = commonService;
      this.liveService = liveService;
    }

    [ActionName("getAdminList")]
    [HttpGet]
    public async Task<ActionResult> getAdminList(string lan, ulong uid, string token, ulong liveuid)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetAdminListModel>() };
      if (uid <= 0 || string.IsNullOrEmpty(token) || liveuid <= 0)
      {
        rs.code = 700;
        rs.msg = "参数错误！";
        if (lan == "En") rs.msg = "Parameter error!";
        if (lan == "Nam") rs.msg = "Các tham số không hợp lệ!";
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
      var info = await liveService.getAdminList(lan, liveuid);
      if (info != null)
      {
        rs.info.Add(info);
      }
      baseResult.data = rs;
      return Json(baseResult);
    }

    [ActionName("checkLive")]
    [HttpGet]
    public async Task<ActionResult> checkLive(string lan, ulong uid, string token, ulong liveuid, string stream)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<checkLiveResult>() };
      var configpub = await _commonService.getConfigPub();
      if (configpub.maintain_switch == "1")
      {
        rs.code = 1002;
        rs.msg = configpub.maintain_tips;
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

      var isban = await AfterLogin.isban(uid);
      if (isban == 0)
      {
        rs.code = 1001;
        rs.msg = "该账号已被禁用";
        if (lan == "En") rs.msg = "This account has been disabled";
        if (lan == "Nam") rs.msg = "Tài khoản này đã bị cấm";
        baseResult.data = rs;
        return Json(baseResult);
      }
      if (uid == liveuid)
      {
        rs.code = 1011;
        rs.msg = "不能进入自己的直播间";
        if (lan == "En") rs.msg = "You can't enter your own live room";
        if (lan == "Nam") rs.msg = "Bạn không thể vào phòng live của mình";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var info = await liveService.checkLive(lan, uid, liveuid, stream);
      if (info == null)
      {
        rs.code = 1001;
        rs.msg = "直播间不存在";
        if (lan == "En") rs.msg = "The live room does not exist";
        if (lan == "Nam") rs.msg = "Phòng live không tồn tại";
        baseResult.data = rs;
        return Json(baseResult);
      }
      rs.info.Add(info);
      baseResult.data = rs;
      return Json(baseResult);
    }

    [ActionName("getReportClass")]
    [HttpGet]
    public async Task<ActionResult> getReportClass(string lan)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<CmfReportClassify>() };
      var infos = await liveService.getReportClass();
      foreach (var info in infos)
      {
        if (lan == "En") info.Name = info.NameEn;
        if (lan == "Nam") info.Name = info.NameNam;
      }

      rs.info = infos;
      baseResult.data = rs;
      return Json(baseResult);
    }

    [ActionName("setReport")]
    [HttpGet]
    public async Task<ActionResult> setReport(string lan, string token, ulong uid, ulong touid, string? content)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<CmfReportClassify>() };
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
      if (string.IsNullOrEmpty(content))
      {
        rs.code = 1001;
        rs.msg = "举报内容不能为空";
        if (lan == "En") rs.msg = "Report content can not be empty";
        if (lan == "Nam") rs.msg = "Nội dung báo cáo không được để trống";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var info = await liveService.setReport(uid, touid, content);
      if (info == 0)
      {
        rs.code = 1001;
        rs.msg = "举报失败";
        if (lan == "En") rs.msg = "Report failed";
        if (lan == "Nam") rs.msg = "Báo cáo thất bại";
        baseResult.data = rs;
        return Json(baseResult);
      }
      rs.msg = "举报成功";
      if (lan == "En") rs.msg = "Report success";
      if (lan == "Nam") rs.msg = "Báo cáo thành công";
      baseResult.data = rs;
      return Json(baseResult);
    }
    //createRoom

    [ActionName("stopRoom")]
    [HttpGet]
    public async Task<ActionResult> stopRoom(string lan, string token, ulong uid, long? time, string sign, string? stream, string? source)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
      var _REQUEST = "{\r\n \"lan\":\"" + lan + "\",\r\n \"uid\":" + uid + ",\r\n \"token\":\"" + token + "\",\r\n \"time\":" + time + ",\r\n \"sign\":\"" + sign + "\"   \r\n}";

      var API_ROOT = _config.GetValue<string>("API_ROOT");
      var path1 = API_ROOT + "/Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
      var content1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Submit parameter information Start:\r\n";
      var path2 = API_ROOT + "/Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
      var content2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + $" Submit parameter information _REQUEST:{_REQUEST}\r\n";
      await Utils.file_put_contents(path1, content1, "FILE_APPEND");
      await Utils.file_put_contents(path2, content2, "FILE_APPEND");
      if (string.IsNullOrEmpty(source))
      {
        if (time == null || time < 1 || string.IsNullOrEmpty(sign))
        {
          rs.code = 1001;
          rs.msg = "参数错误,请重试";
          if (lan == "En") rs.msg = "Parameter error, please try again";
          if (lan == "Nam") rs.msg = "Tham số không hợp lệ, vui lòng thử lại";
          baseResult.data = rs;
          return Json(baseResult);
        }
        var now = Utils.time();
        if (now - time > 300)
        {
          rs.code = 1001;
          rs.msg = "参数错误";
          if (lan == "En") rs.msg = "Parameter error";
          if (lan == "Nam") rs.msg = "Tham số không hợp lệ";
          baseResult.data = rs;
          return Json(baseResult);
        }
        string[] checkData = {
            "uid="+uid,
            "token="+token,
            "time="+time,
            "stream="+stream
        };

        var issign = Utils.checkSign(checkData, sign);
        if (!issign)
        {
          rs.code = 1001;
          rs.msg = "签名错误";
          if (lan == "En") rs.msg = "Signature error";
          if (lan == "Nam") rs.msg = "Chữ ký không hợp lệ";
          baseResult.data = rs;
          return Json(baseResult);
        }
      }
      var key = "stopRoom_" + stream;
      var isexist = cacheManager.GetCacheString(key);
      await Utils.file_put_contents(API_ROOT + "/Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt",
      DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Submit parameter information isexist:" + isexist + "\r\n",
       "FILE_APPEND");
      if (string.IsNullOrEmpty(isexist))
      {
        var checkToken = await AfterLogin.CheckToken(uid, token);
        await Utils.file_put_contents(API_ROOT + "/Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt",
        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Submit parameter information checkToken:" + checkToken + "\r\n",
         "FILE_APPEND");
        await cacheManager.SetCacheStrings(key, "1", TimeSpan.FromMinutes(10));

        if (checkToken == 700)
        {
          await liveService.stopRoom(uid, stream ?? "");
          rs.code = 700;
          rs.msg = "您的登陆状态失效，请重新登陆！";
          if (lan == "En") rs.msg = "Your login status is invalid, please log in again!";
          if (lan == "Nam") rs.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
          baseResult.data = rs;
          return Json(baseResult);
        }
        await liveService.stopRoom(uid, stream ?? "");
      }
      rs.info.Add(new { msg = "Closed broadcast successfully" });
      if (lan == "Nam") rs.info.Add(new { msg = "Đã đóng chương trình phát sóng thành công" });

      baseResult.data = rs;
      return Json(baseResult);
    }

    [ActionName("checkLiveing")]
    [HttpGet]
    public async Task<ActionResult> checkLiveing(string lan, string token, ulong uid, string stream)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };

      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        await liveService.stopRoom(uid, stream);
        rs.code = 700;
        rs.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rs.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rs.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var info = await liveService.checkLiveing(uid, stream);
      var body = new
      {
        status = info
      };
      rs.info.Add(body);

      return Ok(baseResult);
    }

    [ActionName("getUserLists")]
    [HttpGet]
    public async Task<ActionResult> getUserLists(string lan, string stream, ulong liveuid)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };

      await liveService.getUserList(lan, liveuid, stream);

      return Ok(baseResult);
    }

    [ActionName("sendBarrage")]
    [HttpGet]
    public async Task<ActionResult> sendBarrage(string lan, string token, ulong uid, ulong liveuid, string stream, string content, ulong giftid = 0, int giftcount = 1)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };

      if (string.IsNullOrEmpty(content))
      {
        rs.code = 1003;
        rs.msg = "弹幕内容不能为空";
        if (lan == "En") rs.msg = "The content of the bullet screen cannot be empty";
        if (lan == "Nam") rs.msg = "Nội dung của màn hình dấu đầu dòng không được để trống";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rs.code = 700;
        rs.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rs.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rs.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var result= await liveService.sendBarrage(uid, liveuid, stream, giftid, giftcount, content);
      if(result == null){
          rs.code = 1001;
          rs.msg ="礼物信息不存在";
            if (lan == "En") rs.msg = "The gift information does not exist";
            if (lan == "Nam") rs.msg = "Thông tin quà không tồn tại";
            baseResult.data = rs;
            return Json(baseResult);
      }
      var body  = new {
          barragetoken = result.barragetoken,
          level = result.level,
          coin = result.coin
      };
      await cacheManager.SetCacheStrings("barragetoken",result.barragetoken, TimeSpan.FromMinutes(200));
      rs.info.Add(body);
      baseResult.data = rs;
      return Ok(baseResult);
    }
  }
}
