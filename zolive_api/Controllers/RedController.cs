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
  public class RedController : Controller
  {
    private readonly IRedService _redService;
    private CacheManager cacheManager = new CacheManager();
    public RedController(IRedService redService)
    {
      _redService = redService;
    }


    [ActionName("SendRed")]
    [HttpGet]
    public async Task<ActionResult> SendRed(string lan, string token, ulong uid, string stream, ulong coin, uint nums, string des, int type, int type_grant)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.ret = 200;
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "发送成功", info = new List<dynamic>() };
      if (lan == "En") rs.msg = "Send Success";
      else if (lan == "Nam") rs.msg = "Gửi thành công";

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
      if (coin == 0)
      {
        rs.code = 1002;
        rs.msg = "请输入正确的金额";
        if (lan == "En") rs.msg = "Please enter the correct amount";
        if (lan == "Nam") rs.msg = "Vui lòng nhập số tiền hợp lệ";
        baseResult.data = rs;
        return Json(baseResult);
      }
      if (nums == 0)
      {
        rs.code = 1003;
        rs.msg = "请输入正确的个数";
        if (lan == "En") rs.msg = "Please enter the correct number";
        if (lan == "Nam") rs.msg = "Vui lòng nhập số lượng hợp lệ";
        baseResult.data = rs;
        return Json(baseResult);
      }
      if (type == 0)
      {
        coin *= nums;
      }
      else
      {
        if (nums > coin)
        {
          rs.code = 1004;
          rs.msg = "红包数量不能超过红包金额";
          if (lan == "En") rs.msg = "The number of red packets cannot exceed the amount of red packets";
          if (lan == "Nam") rs.msg = "Số lượng hợp lệ không được vượt quá số tiền hợp lệ";
          baseResult.data = rs;
          return Json(baseResult);
        }
      }

      if (des.Length > 20)
      {
        rs.code = 1004;
        rs.msg = "红包名称最多20个字";
        if (lan == "En") rs.msg = "Red packet name up to 20 characters";
        if (lan == "Nam") rs.msg = "Tên hồng bao lên đến 20 ký tự";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var stream_a = stream.Split("_");
      if (stream_a == null || stream_a.Count() < 2)
      {
        rs.code = 1007;
        rs.msg = "信息错误";
        if (lan == "En") rs.msg = "Information error";
        if (lan == "Nam") rs.msg = "Thông tin không hợp lệ";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var liveuid = ulong.Parse(stream_a[0]);
      var showid = ulong.Parse(stream_a[1]);
      if (liveuid == 0 || showid == 0)
      {
        rs.code = 1007;
        rs.msg = "信息错误";
        if (lan == "En") rs.msg = "Information error";
        if (lan == "Nam") rs.msg = "Thông tin không hợp lệ";
        baseResult.data = rs;
        return Json(baseResult);
      }
      var nowtime = Utils.time();
      var addtime = nowtime;
      var effecttime = nowtime;
      if (type_grant == 1)
      {
        effecttime = nowtime + (nowtime + 3 * 60);
      }
      var data = new CmfRed()
      {
        Uid = uid,
        Liveuid = liveuid,
        Showid = showid,
        Type = type,
        TypeGrant = type_grant,
        Coin = coin,
        Nums = (int)nums,
        Des = des,
        Effecttime = effecttime,
        Status = 0,
        Addtime = addtime
      };
      var result = await _redService.sendRed(lan, data);
            if(result.code != 0)
            {
                rs.code = 1009;
                rs.msg =result.msg;
                baseResult.data=rs;
                return Json(baseResult);
            }
      if (result.code == 0)
      {
        baseResult.data = result;
      }
      var redid = result.info.Id;
      var key = "red_list_" + stream;
      cacheManager.rPush(key, redid.ToString());

      var key2 = "red_list_" + stream + "_" + redid;
      var red_list = _redService.redlist(coin, nums, type);
      foreach (var x in red_list)
      {
      cacheManager.rPush(key2, x.ToString());
      }
      var body = new
      {
        redid = redid
      };
      rs.info.Add(body);
      baseResult.data = rs;
      return Ok(baseResult);
    }
  }
}
