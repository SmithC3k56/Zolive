using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using zolive_api.Models;
using zolive_api.Models.Home;
using zolive_api.Services.Home;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Home;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{


  [Route("appapi/[controller].[action]")]
  [ApiController]
  public class HomeController : Controller
  {
    private readonly newliveContext context;
    private readonly IHomeService HomeService;
    private readonly ICommonService _commonService;
    public HomeController(ICommonService commonService, newliveContext _context, IHomeService HomeService)
    {
      this._commonService = commonService;
      this.context = _context;
      this.HomeService = HomeService;
    }
    [ActionName("getConfig")]
    [HttpGet]
    public async Task<ActionResult> getConfig(string lan)
    {
      BaseResult rs = new BaseResult();
      rs.msg = "";
      rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };

      ResultBaseInfo data = new ResultBaseInfo()
      {
        code = 0,
        msg = "",
        info = new List<GetConfig>()

      };
      GetConfig info = new GetConfig();

      var config_pub = _commonService.getConfigPub().Result;
      info = JsonConvert.DeserializeObject<GetConfig>(config_pub.ToString()) ?? new GetConfig();

      info.liveclass = _commonService.getLiveClass(lan).Result;
      info.videoclass = _commonService.getVideoClass(lan).Result;
      info.level = _commonService.getLevelList1().Result;
      info.levelanchor = _commonService.getLevelAnchorList1().Result;
      info.guide = _commonService.getGuide().Result;

      var info_pri = await _commonService.getConfigPri();

      info.tximgfolder = "";
      info.txvideofolder = "";
      info.txcloud_appid = "";
      info.txcloud_region = "";
      info.txcloud_bucket = "";
      info.cloudtype = "1";

      info.qiniu_domain = "http://qiniu.vemo.tv/";
      info.video_audit_switch = info_pri.video_audit_switch;
      info.letter_switch = info_pri.letter_switch;



      info.shopexplain_url = info.site + "/portal/page/index?id=38";
      info.stricker_url = info.site + "/portal/page/index?id=39";


      var dirtyarr = new List<string>();
      if (info_pri.sensitive_words.Value != null || info_pri.sensitive_words.Value != "")
      {
        dirtyarr = new List<string>(info_pri.sensitive_words.Value.Split(','));
      }

      info.sensitive_words = dirtyarr;

      var name_coins = info.name_coin.Split(',');
      string name_coin = name_coins[0];
      string name_coin_en = name_coins[1];
      string name_coin_nam = name_coins[2];

      var name_scores = info.name_score.Split(',');
      string name_score = name_scores[0];
      string name_score_en = name_scores[1];
      string name_score_nam = name_scores[2];

      var name_votess = info.name_votes.Split(',');
      string name_votes = name_votess[0];
      string name_votes_en = name_votess[1];
      string name_votes_nam = name_votess[2];

      info.shop_system_name = "直播小店";

      if (lan == "En")
      {
        name_coin = name_coin_en;
        name_score = name_score_en;
        name_votes = name_votes_en;

        //set system nam
        info.shop_system_name = "Shop";

        //set title
        info.share_des = info.share_des_en;
        info.share_title = info.share_title_en;
        info.video_share_des = info.video_share_des_en;
        info.video_share_title = info.video_share_title_en;

      }
      else if (lan == "Nam")
      {
        name_coin = name_coin_nam;
        name_score = name_score_nam;
        name_votes = name_votes_nam;

        // set system nam 
        info.shop_system_name = "Cửa hàng";

        //set title
        info.share_des = info.share_des_nam;
        info.share_title = info.share_title_nam;
        info.video_share_des = info.video_share_des_nam;
        info.video_share_title = info.video_share_title_nam;

      }

      info.name_coin = name_coin;
      info.name_score = name_score;
      info.name_votes = name_votes;
      rs.data = data;
      rs.data.info.Add(info);

      rs.ret = 200;
      return Json(rs);
    }


    [ActionName("getLogin")]
    [HttpGet]
    public async Task<ActionResult> getLogin(string? lan)
    {
      BaseResult rs = new BaseResult();
      rs.msg = "";
      rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };

      ResultBaseInfo dataGetLogin = new ResultBaseInfo();

      var info = await _commonService.getConfigPub();
      var str = "login_alert_title";
      var str1 = "login_alert_content";
      var str2 = "login_clause_title";
      var rks = "隐私政策";
      var rks1 = "服务协议";
      if (lan == "En")
      {
        str = "login_alert_title_en";
        str1 = "login_alert_content_en";
        str2 = "login_clause_title_en";
        rks = "Privacy policy";
        rks1 = "Service agreement";
      }
      else if (lan == "Nam")
      {
        str = "login_alert_title_nam";
        str1 = "login_alert_content_nam";
        str2 = "login_clause_title_nam";
        rks = "Điều khoản dịch vụ";
        rks1 = "Chính sách bảo mật";
      }

      var title = info[str2];
      var rskstr = "《" + rks + "》";
      var rskstr1 = "《" + rks1 + "》";
      title = title.Value.ToString().Replace("{a}", rskstr).Replace("{b}", rskstr1);


      LoginAlert login_alert = new LoginAlert();

      login_alert.title = info[str];
      login_alert.content = info[str1];
      login_alert.login_title = title;
      login_alert.message = new List<Message>() {
            new Message(){
                 title = "《"+rks+"》",
                 url = Utils.get_upload_path(info["login_service_url"].Value.ToString())
        },
            new Message() {
            title = "《"+rks1+"》",
            url= Utils.get_upload_path(info["login_private_url"].Value.ToString())
        }
            };
      var loginType = info["login_type"];

      for (var i = 0; i < loginType.Count; i++)
      {
        var item = loginType[i];
        if (item.Value == "ios")
        {
          break;
        }
      }
      LoginAlert loginAlert = new LoginAlert();
      List<string> loginTypeList = new List<string>();
      List<string> loginTypeIosList = new List<string>();

      loginAlert.title = login_alert.title;
      loginAlert.content = login_alert.content;
      loginAlert.login_title = login_alert.login_title;
      loginAlert.message = login_alert.message;

      foreach (var item in loginType)
      {
        loginTypeList.Add(item.Value);
        loginTypeIosList.Add(item.Value);

      }

      dataGetLogin.msg = "success";
      dataGetLogin.code = 0;
      dataGetLogin.info = new List<Info>();

      Info obj = new Info();

      obj.login_alert = loginAlert;
      obj.login_type = loginTypeList;
      obj.login_type_ios = loginTypeIosList;

      dataGetLogin.info.Add(obj);

      rs.data = dataGetLogin;
      rs.ret = 200;


      return Json(rs);

    }


    [ActionName("getFollow")]
    [HttpGet]
    public async Task<ActionResult> getFollow(string lan, ulong uid, int p)
    {
      BaseResult reresult = new BaseResult();

      reresult.msg = "";
      reresult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      reresult.ret = 200;
      ResultBaseInfo datars = new ResultBaseInfo();
      datars.msg = "";
      datars.code = 0;
      datars.info = new List<InfoGetFollow>();
      reresult.data = datars;


      CacheManager cacheManager = new CacheManager();
      InfoGetFollow rs = new InfoGetFollow();
      switch (lan)
      {
        case "Nam":
          rs.title = "Idol bạn theo dõi chưa live";
          rs.des = "Xem Idol khác";
          rs.list = new List<GetHotModel>();
          break;
        case "En":
          rs.title = "The idol you followed is not live now";
          rs.des = "Go watch other idols";
          rs.list = new List<GetHotModel>();
          break;
        case "Zh":
          rs.title = "你关注的主播没有开播";
          rs.des = "赶快去看看其他主播的直播吧";
          rs.list = new List<GetHotModel>();
          break;
      }
      if (p < 1)
      {
        p = 1;
      }
      var pnum = 50;
      var start = (p - 1) * pnum;

      var touids = await context.CmfUserAttentions.Where(x => x.Uid == uid).Select(x => x.Touid).ToArrayAsync();

      if (touids == null)
      {
        datars.info.Add(rs);
        return Json(reresult);
      }
      int endtime = -1;
      if (p != 1)
      {
        endtime = int.Parse(cacheManager.GetCacheString("follow_starttime"));
        if (endtime != -1)
        {
          start = 0;

        }
      }

      var touidss = string.Join(",", touids);
      rs.list  = new List<GetHotModel>();
      if (endtime != -1)
      {
        rs.list  = await context.CmfLives.Where(x => x.Islive == 1 && x.Starttime < endtime && touidss.Contains(x.Uid.ToString())).Select(item => new GetHotModel
        {
          uid = item.Uid,
          title = item.Title,
          city = item.City,
          stream = item.Stream,
          pull = item.Pull,
          thumb = item.Thumb,
          isvideo = item.Isvideo,
          type = item.Type,
          type_val = item.TypeVal,
          goodnum = item.Goodnum,
          anyway = item.Anyway,
          starttime = item.Starttime,
          isshop = item.Isshop,
          game_action = item.GameAction,
          hotvotes = item.Hotvotes,
        }).ToListAsync();
      }
      else
      {
        rs.list  = await context.CmfLives.Where(x => x.Islive == 1 && touidss.Contains(x.Uid.ToString())).Take(pnum).Select(item => new GetHotModel
        {
          uid = item.Uid,
          title = item.Title,
          city = item.City,
          stream = item.Stream,
          pull = item.Pull,
          thumb = item.Thumb,
          isvideo = item.Isvideo,
          type = item.Type,
          type_val = item.TypeVal,
          goodnum = item.Goodnum,
          anyway = item.Anyway,
          starttime = item.Starttime,
          isshop = item.Isshop,
          game_action = item.GameAction,
          hotvotes = item.Hotvotes,
        }).ToListAsync();
      }

      for (var count = 0; count < rs.list.Count; count++)
      {
        rs.list [count] = await HomeService.handleLive(lan, rs.list[count]);
       
      }

      if (rs.list .Count > 0)
      {
        var last = rs.list .LastOrDefault();
        if (last != null)
          await cacheManager.SetCacheString("follow_starttime", JsonConvert.SerializeObject(last.starttime));
      }
      

      datars.info.Add(rs);
      return Json(reresult);
    }

    [ActionName("getHot")]
    [HttpGet]
    public async Task<ActionResult> getHot(string? lan, int p)
    {
      CacheManager cacheManager = new CacheManager();
      BaseResult reresult = new BaseResult();

      reresult.msg = "";
      reresult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      reresult.ret = 200;

      ResultBaseInfo data = new ResultBaseInfo();
      data.msg = "";
      data.code = 0;
      data.info = new List<InfoHot>();
      InfoHot info = new InfoHot();

      var key1 = "getSlide";
      var slide = cacheManager.GetCacheString(key1);
      info.slide = new List<getSlideModel>();
      if (slide == null)
      {
        info.slide = await HomeService.getSlide();
        await cacheManager.SetCacheString(key1, JsonConvert.SerializeObject(info.slide));
      }
      else
      {
        info.slide = JsonConvert.DeserializeObject<List<getSlideModel>>(slide) ?? new List<getSlideModel>();
      }
      var key2 = "getHot_" + p;
      var list = cacheManager.GetCacheString(key2);
      info.list = new List<GetHotModel>();
      if (list == null || String.IsNullOrEmpty(list))
      {
        info.list = await HomeService.getHot(lan, p);
        await cacheManager.SetCacheString(key2, JsonConvert.SerializeObject(info.list));
      }
      else
      {
        info.list = JsonConvert.DeserializeObject<List<GetHotModel>>(list) ?? new List<GetHotModel>();

      }



      data.info.Add(info);
      reresult.data = data;
      return Json(reresult);
    }


    [ActionName("getClassLive")]
    [HttpGet]
    public async Task<ActionResult> getClassLive(string? lan, ulong liveclassid, int p)
    {
      BaseResult reresult = new BaseResult();

      reresult.msg = "";
      reresult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      reresult.ret = 200;
      ResultBaseInfo datars = new ResultBaseInfo();

      datars.code = 0;
      datars.msg = "";
      datars.info = new List<GetHotModel>();

      var info = await HomeService.getClassLive(lan, liveclassid, p);
      datars.info = info;
      reresult.data = datars;
      return Json(reresult);
    }


    [ActionName("search")]
    [HttpGet]
    public async Task<ActionResult> search(string? lan, ulong uid, string key, int p)
    {
      BaseResult result = new BaseResult();

      result.msg = "";
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.ret = 200;
      ResultBaseInfo datars = new ResultBaseInfo() { code = 0, msg = "", info = new List<SearchModel>() };
      if (string.IsNullOrEmpty(key))
      {
        datars.code = 1001;
        datars.msg = "请填写关键词";
        if (lan == "En") datars.msg = "Please fill in the keyword";
        if (lan == "Nam") datars.msg = "Vui lòng điền từ khóa";
        result.data = datars;
        return Json(result);
      }
      if (p < 1)
      {
        p = 1;
      }
      var info = await HomeService.search(uid, key, p);
      datars.info = info;
      result.data = datars;
      return Json(result);
    }

    [ActionName("profitList")]
    [HttpGet]
    public async Task<ActionResult> profitList(string lan, int? is_resh, ulong uid, string type, int p)
    {
      BaseResult result = new BaseResult();

      result.msg = "";
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.ret = 200;
      ResultBaseInfo datars = new ResultBaseInfo() { code = 0, msg = "", info = new List<ProfitModel>() };
      var isResh = is_resh == null ? false : true;
      var res = await HomeService.profitList(lan, isResh, uid, type, p);
      datars.info = res;
      result.data = datars;
      return Json(result);
    }

    [ActionName("consumeList")]
    [HttpGet]
    public async Task<ActionResult> consumeList(string lan, int? is_resh, ulong uid, string type, int p)
    {
      BaseResult result = new BaseResult();

      result.msg = "";
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.ret = 200;
      ResultBaseInfo datars = new ResultBaseInfo() { code = 0, msg = "", info = new List<ProfitModel>() };
      var isResh = is_resh == null ? false : true;
      var res = await HomeService.consumeList(lan, isResh, uid, type, p);
      datars.info = res;
      result.data = datars;
      return Json(result);
    }
  }
}
