using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using zolive_api.Models;
using zolive_api.Models.Buyer;
using zolive_api.Models.Live;
using zolive_api.Models.Paidprogram;
using zolive_api.Models.User;
using zolive_api.Models.Video;
using zolive_api.Services.Home;
using zolive_api.Services.Interface;
using zolive_api.Services.User;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
  [Route("appapi/[controller].[action]")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly IUserService _userService;
    private readonly ILoginService _loginService;
    private readonly ICommonService _commonService;
        private readonly IHomeService homeService;
    private readonly newliveContext context;
    private readonly CacheManager cacheManager = new CacheManager();
    public UserController(IHomeService homeService,newliveContext newlivecontext, ICommonService commonService, IUserService userService, ILoginService loginService)
    {
            this.homeService = homeService;
      context = newlivecontext;
      _userService = userService;
      _loginService = loginService;
      _commonService = commonService;
    }



        [ActionName("getUidsInfo")]
        [HttpGet]
        public async Task<ActionResult> getUidsInfo(string lan, ulong uid, string uids)
        {
            BaseResult baseResult = new BaseResult();
            baseResult.msg = "";
            baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };

            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg ="",info  = new List<UidInfo>() };

            var uids_arr = uids.Split(",");
            UidInfo uidInfo = new UidInfo();
            foreach (var x in uids_arr)
            {
                if (string.IsNullOrEmpty(x))
                {
                    var userinfo = await homeService.getUserInfo(lan, uid);
                    if(userinfo != null)
                    {
                        uidInfo.id = userinfo.id;
                        uidInfo.user_nicename = userinfo.user_nicename;
                        uidInfo.avatar = userinfo.avatar;
                        uidInfo.avatar_thumb= userinfo.avatar_thumb;
                        uidInfo.sex = userinfo.sex;
                        uidInfo.consumption = userinfo.consumption;
                        uidInfo.votestotal = userinfo.votestotal;
                        uidInfo.province = userinfo.province;
                        uidInfo.signature = userinfo.signature;
                        uidInfo.city = userinfo.city;
                        uidInfo.birthday = userinfo.birthday;
                        uidInfo.user_status = userinfo.user_status;
                        uidInfo.issuper = userinfo.issuper;
                        uidInfo.location = userinfo.location;
                        uidInfo.level = userinfo.level;
                        uidInfo.level_anchor = userinfo.level_anchor;
                        uidInfo.vip = userinfo.vip;
                        uidInfo.liang = userinfo.liang;
                        uidInfo.utot = _commonService.isAttention(uid, ulong.Parse(x)).Result;
                        uidInfo.ttou = await _commonService.isAttention(ulong.Parse(x), uid);
                        rs.info.Add(uidInfo);
                    }
                }
            }
            baseResult.data = rs;


            return Json(baseResult);
        }

    [ActionName("getBaseInfo")]
    [HttpGet]
    public async Task<ActionResult> getBaseInfo(string lan, ulong uid, string token)
    {
      BaseResult baseResult = new BaseResult();
      baseResult.msg = "";
      baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };

      ResultBaseInfo rs = new ResultBaseInfo();
      BaseInfo info =  _commonService.getInfo(uid).Result;
      rs.msg = "";
      rs.info = new List<BaseInfo>();
      if (info == null)
      {
        rs.code = 700;
        rs.msg = "Trạng thái đăng nhập không hợp lệ. Vui lòng đăng nhập lại";
        return Json(baseResult);
      }

      var shop_switch = _commonService.checkShopIsPass(uid).Result;
      info.paidprogram_switch = (_commonService.checkPaidProgramIsPass(uid).Result).ToString();

      var configpri =  _commonService.getConfigPri().Result;
      var configpub = await _commonService.getConfigPub();

      var agent_switch = configpri.agent_switch;
      var family_switch = configpri.family_switch;
      var service_switch = configpri.service_switch;
      var service_url = configpri.service_url;

      var ios_shelves = configpub.ios_shelves;

      info.agent_switch = agent_switch;
      info.family_switch = family_switch;

      info.shop_switch = shop_switch.ToString();

      await cacheManager.SetCacheString("lang:" + uid, lan);

      int version_ios = 0;
      int? shelves = 1;
      if ((version_ios > 0) && version_ios == ios_shelves)
      {
        agent_switch = 0;
        family_switch = 0;
        shelves = 0;
      }
      List<ListImg> list1 = new List<ListImg>();
      List<ListImg> list2 = new List<ListImg>();
      List<ListImg> list3 = new List<ListImg>();


      list1 = new List<ListImg>
            {
                new ListImg() { id = 191,name = Utils.getVs1(lan,"消息"),thumb = "http://live.newlivevn.com/static/1.png", href ="" },
                new ListImg() { id = 192,name = Utils.getVs1(lan,"钱包"),thumb = "http://live.newlivevn.com/static/2.png", href ="" },
                new ListImg() { id = 193,name = Utils.getVs1(lan,"明细"),thumb = "http://live.newlivevn.com/static/3.png", href ="" },
                new ListImg() { id = 194,name = Utils.getVs1(lan,"商城"),thumb = "http://live.newlivevn.com/static/4.png", href ="" },

                new ListImg() { id = 19,name = Utils.getVs1(lan,"我的视频"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/video.png", href ="" },
                new ListImg() { id = 23,name = Utils.getVs1(lan,"我的动态"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/dymic.png", href ="" },

                new ListImg() { id = 3,name = Utils.getVs1(lan,"我的等级"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/level.png", href ="http://live.newlivevn.com/Appapi/Level/index" },
                new ListImg() { id = 11,name = Utils.getVs1(lan,"我的认证"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/auth.png", href ="http://live.newlivevn.com/Appapi/Auth/index" },

                new ListImg() { id = 22,name = Utils.getVs1(lan,"直播小店"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/shop.png?t=1", href ="" },
                new ListImg() { id = 24,name = Utils.getVs1(lan,"付费内容"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/pay.png", href ="" }

            };

      list2.Add(new ListImg() { id = 20, name = Utils.getVs1(lan, "房间管理"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/room.png", href = "" });

      if (shelves != null)
      {
        list1.Add(new ListImg { id = 1, name = Utils.getVs1(lan, "我的收益"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/votes.png", href = "" });
        list2.Add(new ListImg { id = 5, name = Utils.getVs1(lan, "装备中心"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/equipment.png", href = "http://live.newlivevn.com/Appapi/Equipment/index" });
      }
      if (family_switch != null)
      {
        list2.Add(new ListImg { id = 6, name = Utils.getVs1(lan, "家族中心"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/family.png", href = "http://live.newlivevn.com/Appapi/Family/index2" });
        list2.Add(new ListImg { id = 7, name = Utils.getVs1(lan, "家族驻地"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/family2.png", href = "http://live.newlivevn.com/Appapi/Family/home" });
      }
      if (agent_switch != null)
      {
        list2.Add(new ListImg { id = 8, name = Utils.getVs1(lan, "邀请奖励"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/agent.png", href = "http://live.newlivevn.com/Appapi/Agent/index" });
      }
      if (service_switch != null && service_url != null)
      {
        list3.Add(new ListImg { id = 21, name = Utils.getVs1(lan, "在线客服(Beta)"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/kefu.png", href = "" });
      }
      list3.Add(new ListImg { id = 13, name = Utils.getVs1(lan, "个性设置"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/set.png", href = "" });

      List<ListImg> lists = new List<ListImg>();
      lists.AddRange(list1);
      lists.AddRange(list2);
      lists.AddRange(list3);

      info.list = new List<List<ListImg>>();
      info.list.Add(lists);
      rs.info.Add(info);

      baseResult.data = rs;
      baseResult.ret = 200;
      return Json(baseResult);

    }

    [ActionName("Bonus")]
    [HttpGet]
    public async Task<ActionResult> Bonus(string? lan, ulong uid, string token)
    {
      BaseResult result = new BaseResult();
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      ResultBaseInfo dataBonus = new ResultBaseInfo() { code = 0, msg = "", info = new List<InfoBonus>() };
      var checktoken = await AfterLogin.CheckToken(uid, token);
      if (checktoken == 700)
      {
        dataBonus.code = 700;
        dataBonus.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") dataBonus.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") dataBonus.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = dataBonus;
        return Json(result);
      }
      var rs = await _userService.LoginBonus(uid);
      dataBonus.info.Add(rs);
      dataBonus.msg = "";
      dataBonus.code = 0;
      result.ret = 200;
      result.msg = "";
      result.data = dataBonus;

      return Json(result);
    }


    [ActionName("getBonus")]
    [HttpGet]
    public async Task<ActionResult> getBonus(string? lan, ulong uid, string token)
    {
      BaseResult result = new BaseResult();
      ResultBaseInfo dataBonus = new ResultBaseInfo();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      try
      {
        var checktoken = await AfterLogin.CheckToken(uid, token);
        if (checktoken == 700)
        {
          dataBonus.code = 700;
          dataBonus.msg = "您的登陆状态失效，请重新登陆！";
          if (lan == "En") dataBonus.msg = "Your login status is invalid, please log in again!";
          if (lan == "Nam") dataBonus.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
          result.data = dataBonus;
          return Json(result);
        }

        var code = await _userService.getLoginBonus(uid);
        if (code == 0)
        {
          dataBonus.msg = "Nhận quà thành công";
          dataBonus.info = new List<InfoBonus>();
          dataBonus.code = 0;
          result.data = dataBonus;
          return Json(result);
        }
        else
        {
          dataBonus.msg = "Không thể nhận thêm quà";
          dataBonus.info = new List<InfoBonus>();
          dataBonus.code = code;
          result.data = dataBonus;
          return Json(result);
        }


      }
      catch (Exception ex)
      {
        result.msg = ex.Message;
      }
      return Json(result);
    }

    //getUserHome
    [ActionName("getUserHome")]
    [HttpGet]
    public async Task<ActionResult> getUserHome(string lan, ulong uid, ulong touid)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };

      var info = _userService.getUserHome(lan, uid, touid).Result;
      var guardlist = _userService.getGuardList(lan, touid).Result;

      info.guardlist = guardlist.Take(3).ToList();
      var key = "getMyLabel_" + touid + "_" + lan;
      var lable_cache = cacheManager.GetCacheString(key);
      IList<LabelInfoModel> label = new List<LabelInfoModel>();
      if (lable_cache == null)
      {
        label = await _userService.getMyLabel(lan, uid);
        if (label != null && label.Count > 0) await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(label));
      }
      else
      {
        label = JsonConvert.DeserializeObject<List<LabelInfoModel>>(lable_cache) ?? new List<LabelInfoModel>();
      }

      CmfLabelUser user_lable = new CmfLabelUser();
      if (uid == touid)
      {
        string[] ankel = { };
        var user_lables = await context.CmfLabelUsers.Where(x => x.Touid == touid).ToListAsync();
        foreach (var v in user_lables)
        {
          ankel = v.Label.Split(",");

        }
        user_lable.Label = string.Join(",", ankel);

      }
      else
      {
        user_lable = await context.CmfLabelUsers.Where(x => x.Uid == uid && x.Touid == touid).FirstOrDefaultAsync() ?? new CmfLabelUser();
      }
      var labels = await context.CmfLabels.OrderBy(x => x.ListOrder).ThenByDescending(x => x.Id).ToListAsync();

      info.label = new List<CmfLabel>();
      foreach (var v in labels)
      {
        if (user_lable.Label != null)
        {
          if (user_lable.Label.Contains(v.Id.ToString()))
          {

            if (lan == "En") v.Name = v.NameEn;
            else if (lan == "Nam") v.Name = v.NameNam;
            info.label.Add(v);
          }
        }

      }


      info.videolist = _userService.getHomeVideo(lan, uid, touid, 1).Result;
      info.isshop = 0;

      info.shop = await _userService.getShop(lan, touid);
      if (info.shop != null)
      {
        info.isshop = 1;
        info.shop.nums = _userService.countGoods(touid, 1).Result;

      }
      result.data = new ResultBaseInfo();
      ResultBaseInfo rst = new ResultBaseInfo();
      rst.msg = "";
      rst.code = 0;
      rst.info = new List<UserInfo>();
      rst.info.Add(info);
      result.data = rst;
      result.ret = 200;

      return Json(result);
    }

    [ActionName("getLiverecord")]
    [HttpGet]
    public async Task<ActionResult> getLiverecord(string lan, ulong? uid, ulong touid, int p)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rs = new ResultBaseInfo();
      rs.code = 0;
      rs.msg = "";
      rs.info = new List<LiveRecordModel>();
      var info = await _userService.getLiverecord(touid, p);

      rs.info = info;
      result.data = rs;
      return Json(result);
    }

    [ActionName("GetMyLabel")]
    [HttpGet]
    public async Task<ActionResult> GetMyLabel(string lan, ulong uid, string token)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();

      ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "", info = new List<LabelInfoModel>() };

      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rs.code = 700;
        rs.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = rs;
        return Json(result);
      }
      var key = "getMyLabel_" + uid + "_" + lan;
      var info = cacheManager.GetCacheString(key);
      IList<LabelInfoModel> infos = new List<LabelInfoModel>();
      if (string.IsNullOrEmpty(info))
      {
        infos = await _userService.getMyLabel(lan, uid);

        if (infos.Count > 0) await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(infos));
      }
      else
      {
        infos = JsonConvert.DeserializeObject<List<LabelInfoModel>>(info) ?? new List<LabelInfoModel>();
      }
      rs.info = infos;
      result.data = rs;
      return Json(result);
    }

    [ActionName("updateFields")]
    [HttpGet]
    public async Task<ActionResult> updateFields(string lan, ulong uid, string token, string fields)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rs = new ResultBaseInfo();
      rs.code = 0;
      rs.msg = "";
      rs.info = new List<dynamic>();

      var m = "Sửa thành công";

      if (lan == "En") m = "Modified successfully";

      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rs.code = 700;
        rs.msg = "Trạng thái đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = rs;
        return Json(result);
      }
      var url = Utils.UrlDecode(fields);
      var json_decode_field = JsonConvert.DeserializeObject<dynamic>(url) ?? new List<dynamic>();
      var allow = new List<string>() { "user_nicename", "sex", "signature", "birthday", "location", "city" };

      foreach (var field in json_decode_field)
      {
        if (allow.Contains(field.Name))
        {
          if (field.Name.ToString() == "user_nicename")
          {
            if (string.IsNullOrEmpty(field.Value.Value))
            {
              rs.code = 1002;
              rs.msg = "Biệt hiệu phải được điền";
              if (lan == "En") rs.msg = "Field nicename not null";
              result.data = rs;
              return Json(result);
            }
            var isExit = await _userService.checkName(uid, field.Value.Value);
            if (!isExit)
            {
              rs.code = 1002;
              rs.msg = "Biệt danh trùng, hãy sửa đổi";
              if (lan == "En") rs.msg = "Duplicate nickname, please modify";
              result.data = rs;
              return Json(result);
            }
            var sensitivewords = await _userService.sensitiveField(field.Value.Value);
            if (sensitivewords == 1001)
            {
              rs.code = 10011;
              rs.msg = "Nhập không hợp lệ, vui lòng nhập lại";
              result.data = rs;
              if (lan == "En") rs.msg = "Illegal input, please re-enter";
              return Json(result);
            }
          }
          if (field.Name == "signature")
          {
            var sensitivewords = await _userService.sensitiveField(field.Value.Value);
            if (sensitivewords == 1001)
            {
              rs.code = 10011;
              rs.msg = "Nhập không hợp lệ, vui lòng nhập lại !";
              if (lan == "En") rs.msg = "Illegal input, please re-enter";
              result.data = rs;
              return Json(result);
            }
          }
        }
      }
      var info = await _userService.userUpdate(uid, url);
      if (!info)
      {
        rs.code = 1001;
        rs.msg = "Lỗi sửa đổi";
        if (lan == "En") rs.msg = "Modification failed";
        result.data = rs;
        return Json(result);
      }
      await cacheManager.DeleteCache("userinfo_" + uid);
      var infoResult = new
      {
        status = info,
        msg = rs.msg,
        code = rs.code
      };
      rs.info.Add(infoResult);
      rs.msg = m;
      result.data = rs;
      return Json(result);
    }


    [ActionName("getBalance")]
    [HttpGet]
    public async Task<ActionResult> getBalance(string lan, ulong uid, string token, int type, string? version_ios)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<getBalanceModel>() };
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "Hết hạn phiên đăng nhập";
        result.data = rsdata;
        return Json(result);
      }
      var info = await _userService.getBalance(uid);

      var key = "getChargeRules";
      var rules = cacheManager.GetCacheString(key);
      IList<getChargeRulesModel> ruleslist = new List<getChargeRulesModel>();
      if (string.IsNullOrEmpty(rules))
      {
        ruleslist = await _userService.getChargeRules();
        if (ruleslist.Count > 0) await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(ruleslist));
      }
      else
      {
        ruleslist = JsonConvert.DeserializeObject<List<getChargeRulesModel>>(rules) ?? new List<getChargeRulesModel>();
      }

      info.rules = ruleslist;
      var configpub = await _commonService.getConfigPub();
      var configpri = await _commonService.getConfigPri();

      var aliapp_switch = (int)configpri.aliapp_switch;

      info.aliapp_switch = aliapp_switch;
      info.aliapp_partner = aliapp_switch == 1 ? configpri.aliapp_partner : "";
      info.aliapp_seller_id = aliapp_switch == 1 ? configpri.aliapp_seller_id : "";
      info.aliapp_key_android = aliapp_switch == 1 ? configpri.aliapp_key_android : "";
      info.aliapp_key_ios = aliapp_switch == 1 ? configpri.aliapp_key_ios : "";

      var wx_switch = (int)configpri.wx_switch;
      info.wx_switch = wx_switch;
      info.wx_appid = wx_switch == 1 ? configpri.wx_appid : "";
      info.wx_appsecret = wx_switch == 1 ? configpri.wx_appsecret : "";
      info.wx_mchid = wx_switch == 1 ? configpri.wx_mchid : "";
      info.wx_key = wx_switch == 1 ? configpri.wx_key : "";

      var shelves = 1;
      var ios_shelves = configpub.ios_shelves;
      if (version_ios != null && version_ios == ios_shelves) shelves = 0;

      List<Paylist> paylist = new List<Paylist>();

      paylist.Add(new Paylist() { id = "ali", name = "pay by AliPay", thumb = "https://zolive.m99.club/static/app/pay/ali.png", href = "" });

      if (wx_switch == 1 && shelves == 1)
      {
        paylist.Add(new Paylist() { id = "wx", name = "WeChat Pay", thumb = "https://zolive.m99.club/static/app/pay/wx.png", href = "" });
      }

      if (shelves == 0 && type == 1)
      {
        paylist.Add(new Paylist() { id = "apple", name = "Apple Pay", thumb = "https://zolive.m99.club/static/app/pay/apple.png", href = "" }); ;
      }
      var name_coin = configpub.name_coin.ToString();
      var name_score = configpub.name_score.ToString();
      var zh = "";
      var en = "";
      var nam = "";
      var zh1 = "";
      var en1 = "";
      var nam1 = "";
      var ns = "";
      var nm = "";

      if (!string.IsNullOrEmpty(name_coin))
      {
        var namecoin = configpub.name_coin.ToString().Split(",");

        zh = namecoin[0];
        en = namecoin[1];
        nam = namecoin[2];
      }
      if (!string.IsNullOrEmpty(name_score))
      {
        var namescore = configpub.name_score.ToString().Split(",");
        zh1 = namescore[0];
        en1 = namescore[1];
        nam1 = namescore[2];
      }
      switch (lan)
      {
        case "Zh":
          ns = zh;
          nm = zh1;
          info.tip_t = ns + "/" + nm + "说明:";
          info.tip_d = ns + "可通过平台提供的支付方式进行充值获得，" + ns + "适用于平台内所有消费； " + nm + "可通过直播间内游戏奖励获得，所得" + nm + "可用于平台商城内兑换会员、坐 骑、靓号等服务，不可提现。";
          break;
        case "En":
          ns = en;
          nm = en1;
          info.tip_t = ns + "/" + nm + " Illustration:";
          info.tip_d = ns + " can be recharged through the methods provided." + ns + " is the primary currency used for the purchases on the platform. " + nm + " can be obtain through game rewards in the live room." + nm + " are to be used to purchase VIP ID, Vehicles, etc. but is unable to withdraw.";
          break;
        default:
          ns = nam;
          nm = nam1;
          info.tip_t = ns + "/" + nm + " Chú thích:";
          info.tip_d = ns + " Có thể nạp tiền thông qua phương thức thanh toán do nền tảng cung cấp，" + ns + " Áp dụng cho tất cả tiêu dùng trong nền tảng； " + nm + " Có thể nhận được thông qua phần thưởng trò chơi trong phòng live," + nm + " có thể được sử dụng để đổi thẻ hội viên, phương tiện, ID VIP và các dịch vụ khác trong trung tâm thương mại của nền tảng.Không thể rút tiền";
          break;
      }
      info.paylist = paylist;
      rsdata.info.Add(info);
      result.data = rsdata;


      return Json(result);
    }


    [ActionName("getAuthInfo")]
    [HttpGet]
    public async Task<ActionResult> getAuthInfo(string lan, ulong uid, string token)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetAuthInfoClass>() };

      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        result.data = rsdata;
        return Json(result);
      }
      var isAuth = await _loginService.isAuth(uid);
      if (!isAuth)
      {
        rsdata.code = 1001;
        rsdata.msg = "请先进行实名认证";
        if (lan == "En") rsdata.msg = "Please conduct real name authentication first";
        if (lan == "Nam") rsdata.msg = "Làm ơn thực hiện xác thực tên thật trước";
        result.data = rsdata;
        return Json(result);
      }
      var res = await _userService.getAuthInfo(uid);
      if (res != null) rsdata.info.Add(res);
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("getUserAccountList")]
    [HttpGet]
    public async Task<ActionResult> getUserAccountList(string lan, ulong uid, string token)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<CmfCashAccount>() };//CmfCashAccount
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        result.data = rsdata;
        return Json(result);
      }
      rsdata.info = await _userService.getUserAccountList(uid);
      result.data = rsdata;
      return Json(result);
    }
    [ActionName("setUserAccount")]
    [HttpGet]
    public async Task<ActionResult> setUserAccount(string lan, ulong uid, string token, int type, string account_bank, string name, string account)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "添加成功", info = new List<CmfCashAccount>() };
      if (lan == "En") rsdata.msg = "Added successfully";
      if (lan == "Nam") rsdata.msg = "Thêm thành công";


      if (type == 3)
      {
        if (string.IsNullOrEmpty(account_bank))
        {
          rsdata.code = 1001;
          rsdata.msg = "银行名称不能为空";
          if (lan == "En") rsdata.msg = "Bank name cannot be empty";
          if (lan == "Nam") rsdata.msg = "Tên ngân hàng không được để trống";
          result.data = rsdata;
          return Json(result);
        }
      }
      if (string.IsNullOrEmpty(account))
      {
        rsdata.code = 1002;
        rsdata.msg = "账号不能为空";
        if (lan == "En") rsdata.msg = "Account number cannot be empty";
        if (lan == "Nam") rsdata.msg = "Số tài khoản không được để trống";
        result.data = rsdata;
        return Json(result);
      }
      if (account.Length > 40)
      {
        rsdata.code = 1002;
        rsdata.msg = "账号长度不能超过40位";
        if (lan == "En") rsdata.msg = "Account number cannot exceed 40 characters";
        if (lan == "Nam") rsdata.msg = "Số tài khoản không được vượt quá 40 ký tự";
        result.data = rsdata;
        return Json(result);
      }
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        result.data = rsdata;
        return Json(result);
      }
      #region getUserAccount
      var isexist = await context.CmfCashAccounts.Where(x => x.Uid == uid && x.Type == type && x.AccountBank == account_bank && x.Account == account).OrderByDescending(x => x.Addtime).FirstOrDefaultAsync();
      #endregion
      if (isexist != null)
      {
        rsdata.code = 1004;
        rsdata.msg = "账号已存在";
        if (lan == "En") rsdata.msg = "Account already exists";
        if (lan == "Nam") rsdata.msg = "Số tài khoản đã tồn tại";
        result.data = rsdata;
        return Json(result);
      }
      var data = new CmfCashAccount()
      {
        Uid = uid,
        Type = type,
        AccountBank = account_bank,
        Name = name,
        Account = account,
        Addtime = Utils.time()
      };
      await context.CmfCashAccounts.AddAsync(data);
      await context.SaveChangesAsync();

      result.data = rsdata;
      return Json(result);
    }


    [ActionName("delUserAccount")]
    [HttpGet]
    public async Task<ActionResult> delUserAccount(string lan, ulong uid, string token, int id)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "删除成功", info = new List<CmfCashAccount>() };
      if (lan == "En") rsdata.msg = "Deleted successfully";
      if (lan == "Nam") rsdata.msg = "Xóa thành công";
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tài khoản của bạn đã hết hạn, vui lòng đăng nhập lại!";
        result.data = rsdata;
        return Json(result);
      }
      var obj = await context.CmfCashAccounts.Where(x => x.Uid == uid && x.Id == id).FirstOrDefaultAsync();
      if (obj == null)
      {
        rsdata.code = 1005;
        rsdata.msg = "账号不存在";
        if (lan == "En") rsdata.msg = "Account does not exist";
        if (lan == "Nam") rsdata.msg = "Số tài khoản không tồn tại";
        result.data = rsdata;
        return Json(result);
      }
      else
      {
        context.CmfCashAccounts.Remove(obj);
        await context.SaveChangesAsync();
      }
      return Json(result);
    }
    [ActionName("setShopCash")]
    [HttpGet]
    public async Task<ActionResult> setShopCash(string lan, ulong uid, string token, int accountid, ulong money, long time, string sign)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "提现成功", info = new List<dynamic>() };
      if (lan == "En") rsdata.msg = "Withdrawal success";
      if (lan == "Nam") rsdata.msg = "Rút tiền thành công";
      if (uid < 0 || string.IsNullOrEmpty(token) || time <= 0 || string.IsNullOrEmpty(sign))
      {
        rsdata.code = 1001;
        rsdata.msg = "参数错误";
        if (lan == "En") rsdata.msg = "Parameter error";
        if (lan == "Nam") rsdata.msg = "Tham số không chính xác";
        result.data = rsdata;
        return Json(result);
      }
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tài khoản của bạn đã hết hạn, vui lòng đăng nhập lại!";
        result.data = rsdata;
        return Json(result);
      }
      if (accountid <= 0)
      {
        rsdata.code = 1002;
        rsdata.msg = "请选择提现账号";
        if (lan == "En") rsdata.msg = "Please select withdrawal account";
        if (lan == "Nam") rsdata.msg = "Vui lòng chọn một tài khoản rút tiền";
        result.data = rsdata;
        return Json(result);
      }
      if (money <= 0)
      {
        rsdata.code = 1002;
        rsdata.msg = "请输入提现金额";
        if (lan == "En") rsdata.msg = "Please enter withdrawal amount";
        if (lan == "Nam") rsdata.msg = "Vui lòng nhập số tiền rút";
        result.data = rsdata;
        return Json(result);
      }
      var now = Utils.time();
      if (now - time > 300)
      {
        rsdata.code = 1001;
        rsdata.msg = "参数错误";
        if (lan == "En") rsdata.msg = "Parameter error";
        if (lan == "Nam") rsdata.msg = "Tham số không chính xác";
        result.data = rsdata;
        return Json(result);
      }
      string[] checkdata = { "time=" + time, "token=" + token, "uid=" + uid, "accountid=" + accountid };

      var issign = Utils.checkSign(checkdata, sign);
      if (!issign)
      {
        rsdata.code = 1001;
        rsdata.msg = "签名错误";
        if (lan == "En") rsdata.msg = "Signature error";
        if (lan == "Nam") rsdata.msg = "Chữ ký không chính xác";
        result.data = rsdata;
        return Json(result);
      }
      var configpri = await _commonService.getConfigPri();

      var res = await _userService.setShopCash(uid, accountid, money);
      if (res == 1001)
      {
        rsdata.code = 1001;
        rsdata.msg = "余额不足";
        if (lan == "En") rsdata.msg = "Insufficient balance";
        if (lan == "Nam") rsdata.msg = "Số dư không đủ";
        result.data = rsdata;
        return Json(result);
      }
      else if (res == 1004)
      {
        rsdata.code = 1004;
        rsdata.msg = "提现最低额度为" + configpri.balance_cash_min + "元";
        if (lan == "En") rsdata.msg = "The minimum withdrawal amount is " + configpri.balance_cash_min + " yuan";
        if (lan == "Nam") rsdata.msg = "Số tiền rút tối thiểu là " + configpri.balance_cash_min + " đồng";
        result.data = rsdata;
        return Json(result);
      }
      else if (res == 1005)
      {
        rsdata.code = 1005;
        rsdata.msg = "不在提现期限内，不能提现";
        if (lan == "En") rsdata.msg = "Not in the withdrawal period, cannot withdraw";
        if (lan == "Nam") rsdata.msg = "Không thuộc thời gian rút tiền, không thể rút tiền";
        result.data = rsdata;
        return Json(result);
      }
      else if (res == 1006)
      {
        rsdata.code = 1006;
        rsdata.msg = "每月只可提现" + configpri.balance_cash_max_times + "次,已达上限";
        if (lan == "En") rsdata.msg = "Each month can only withdraw " + configpri.balance_cash_max_times + " times, has reached the upper limit";
        if (lan == "Nam") rsdata.msg = "Mỗi tháng chỉ được rút " + configpri.balance_cash_max_times + " lần, đã đạt giới hạn";
        result.data = rsdata;
        return Json(result);
      }
      else if (res == 1007)
      {
        rsdata.code = 1007;
        rsdata.msg = "提现账号信息不正确";
        if (lan == "En") rsdata.msg = "Withdrawal account information is incorrect";
        if (lan == "Nam") rsdata.msg = "Thông tin tài khoản rút tiền không chính xác";
        result.data = rsdata;
        return Json(result);
      }
      else if (res == 0)
      {
        rsdata.code = 1002;
        rsdata.msg = "提现失败，请重试";
        if (lan == "En") rsdata.msg = "Withdrawal failed, please try again";
        if (lan == "Nam") rsdata.msg = "Rút tiền thất bại, vui lòng thử lại";
        result.data = rsdata;
        return Json(result);
      }
      result.data = rsdata;
      return Json(result);
    }


    [ActionName("getProfit")]
    [HttpGet]
    public async Task<ActionResult> getProfit(string lan, ulong uid, string token)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<getProfitModel>() };
      var checkToken = await AfterLogin.CheckToken(uid, token);

      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = rsdata;
        return Json(result);
      }
      var info = await _userService.getProfit(lan, uid);
      rsdata.info.Add(info);
      result.data = rsdata;

      return Json(result);
    }

    [ActionName("getPerSetting")]
    [HttpGet]
    public async Task<ActionResult> getPerSetting(string lan)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetPerSettingModel>() };

      IList<GetPerSettingModel> listrslt = new List<GetPerSettingModel>();
      listrslt = await _userService.getPerSetting();
      listrslt.Add(new GetPerSettingModel { id = 17, name = "意见反馈", thumb = "", href = Utils.get_upload_path("/Appapi/feedback/index") });
      listrslt.Add(new GetPerSettingModel { id = 15, name = "修改密码", thumb = "", href = "" });
      listrslt.Add(new GetPerSettingModel { id = 18, name = "清除缓存", thumb = "", href = "" });
      listrslt.Add(new GetPerSettingModel { id = 19, name = "注销账号", thumb = "", href = Utils.get_upload_path("/Appapi/feedback/index") });
      listrslt.Add(new GetPerSettingModel { id = 16, name = "检查更新", thumb = "", href = "" });

      foreach (var item in listrslt)
      {
        item.name = Utils.getVs1(lan, item.name);
      }
      rsdata.info = listrslt;
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("updatePass")]
    [HttpGet]
    public async Task<ActionResult> updatePass(string lan, ulong uid, string token, string oldpass, string pass, string pass2)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(oldpass) || string.IsNullOrEmpty(pass) || uid <= 0)
      {
        rsdata.code = 1001;
        rsdata.msg = "参数错误";
        if (lan == "En") rsdata.msg = "Parameter error";
        if (lan == "Nam") rsdata.msg = "Tham số sai";
        result.data = rsdata;
        return Json(result);
      }
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = rsdata;
        return Json(result);
      }
      if (pass != pass2)
      {
        rsdata.code = 1002;
        rsdata.msg = "两次新密码不一致";
        if (lan == "En") rsdata.msg = "The two new passwords are inconsistent";
        if (lan == "Nam") rsdata.msg = "Mật khẩu không khớp";
        result.data = rsdata;
        return Json(result);
      }
      var check = Utils.passcheck(pass);
      if (!check)
      {
        rsdata.code = 1004;
        rsdata.msg = "密码为6-20位字母数字组合";
        if (lan == "En") rsdata.msg = "The password is 6-20 bits of letters and numbers combined";
        if (lan == "Nam") rsdata.msg = "Mật khẩu phải là 6-20 ký tự chữ số";
        result.data = rsdata;
        return Json(result);
      }
      var info = await _userService.updatePass(uid, oldpass, pass);
      if (info == 1003)
      {
        rsdata.code = 1003;
        rsdata.msg = "旧密码错误";
        if (lan == "En") rsdata.msg = "Old password error";
        if (lan == "Nam") rsdata.msg = "Mật khẩu cũ không đúng";
        result.data = rsdata;
        return Json(result);
      }
      if (info == 0)
      {
        rsdata.code = 1001;
        rsdata.msg = "不正确的用户";
        if (lan == "En") rsdata.msg = "Incorrect user";
        if (lan == "Nam") rsdata.msg = "Không đúng người dùng";
        result.data = rsdata;
        return Json(result);
      }
      else if (info != 1)
      {
        rsdata.code = 1001;
        rsdata.msg = "修改失败";
        if (lan == "En") rsdata.msg = "Modification failed";
        if (lan == "Nam") rsdata.msg = "Thay đổi thất bại";
        result.data = rsdata;
        return Json(result);
      }
      rsdata.msg = "修改成功";
      if (lan == "En") rsdata.msg = "Modification successfully";
      if (lan == "Nam") rsdata.msg = "Thay đổi thành công";
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("setAttent")]
    [HttpGet]
    public async Task<ActionResult> setAttent(string lan, ulong uid, string token, ulong touid)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
      if (uid <= 0 || touid <= 0)
      {
        rsdata.code = 1001;
        rsdata.msg = "不能关注自己";
        if (lan == "En") rsdata.msg = "Cannot follow oneself";
        if (lan == "En") rsdata.msg = "Không thể theo dõi chính mình";
        result.data = rsdata;
        return Json(result);
      }

      var info = await _userService.setAttent(uid, touid);
      var infoResult = new
      {
        isattent = info
      };
      rsdata.info.Add(infoResult);
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("setBlack")]
    [HttpGet]
    public async Task<ActionResult> setBlack(string lan, ulong uid, string token, ulong touid)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = result;
        return Json(result);
      }
      var res = await _userService.setBlack(uid, touid);
      var infoResult = new
      {
        isblack = res
      };
      rsdata.info.Add(infoResult);
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("GetUserLabel")]
    [HttpGet]
    public async Task<ActionResult> GetUserLabel(string lan, ulong uid, ulong touid)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetUserlabelModel>() };
      var key = "getUserLabel_" + uid + "_" + touid;
      var label = cacheManager.GetCacheString(key);
      string[] label_check = { };
      if (string.IsNullOrEmpty(label))
      {
        var info = await _userService.getUserLabel(uid, touid);
        if (info != null)
        {
          label = info.Label;
          if (!string.IsNullOrEmpty(label)) await cacheManager.SetCacheString(key, label);
        }

      }
      else
      {
        label_check = Regex.Split("/,|，/", label);
      }

      var key2 = "getImpressionLabel" + Utils.time();
      var label_list = cacheManager.GetCacheString(key2);
      IList<CmfLabel> label_list_rs = new List<CmfLabel>();
      if (string.IsNullOrEmpty(label_list))
      {
        label_list_rs = await _userService.getImpressionLabel(lan);
      }
      else
      {
        label_list_rs = JsonConvert.DeserializeObject<List<CmfLabel>>(label_list) ?? new List<CmfLabel>();
      }
      List<GetUserlabelModel> rsInfo = new List<GetUserlabelModel>();
      foreach (var item in label_list_rs)
      {
        GetUserlabelModel obj = new GetUserlabelModel();
        var ifcheck = 0;
        if (label_check.Contains(item.Id.ToString()))
        {
          ifcheck = 1;
        }
        obj.ifcheck = ifcheck;
        obj.id = item.Id;
        obj.list_order = item.ListOrder;
        obj.colour = item.Colour;
        obj.colour2 = item.Colour2;
        obj.name = item.Name;
        if (lan == "En") obj.name = item.NameEn;
        if (lan == "Nam") obj.name = item.NameNam;
        rsInfo.Add(obj);
      }
      rsdata.info = rsInfo;
      result.data = rsdata;

      return Json(result);
    }

    [ActionName("setUserLabel")]
    [HttpGet]
    public async Task<ActionResult> setUserLabel(string lan, ulong uid, ulong touid, string token, string labels)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<GetUserlabelModel>() };

      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = rsdata;
        return Json(result);
      }
      if (uid == touid)
      {
        rsdata.code = 1003;
        rsdata.msg = "不能给自己设置标签";
        if (lan == "En") rsdata.msg = "You can not set labels for yourself";
        if (lan == "Nam") rsdata.msg = "Bạn không thể thiết lập nhãn cho mình";
        result.data = rsdata;
        return Json(result);
      }
      if (string.IsNullOrEmpty(labels))
      {
        rsdata.code = 1001;
        rsdata.msg = "请选择印象";
        result.data = rsdata;
        return Json(result);
      }

      var labels_a = Regex.Split("/,|，/", labels);
      var nums = labels_a.Count();
      if (nums > 3)
      {
        rsdata.code = 1002;
        rsdata.msg = "最多只能选择3个印象";
        if (lan == "En") rsdata.msg = "You can only select up to 3 impressions";
        if (lan == "Nam ") rsdata.msg = "Bạn chỉ có thể chọn tối đa 3 đánh giá";
        result.data = rsdata;
        return Json(result);
      }
      var results = await _userService.setUserLabel(uid, touid, labels);
      if (results == 1)
      {
        var key = "getUserLabel_" + uid + "_" + touid;
        await cacheManager.SetCacheString(key, labels);
        var key2 = "getMyLabel_" + touid;
        await cacheManager.DeleteCache(key2);
        rsdata.msg = "设置成功";
        if (lan == "En") rsdata.msg = "Set successfully";
        if (lan == "Nam") rsdata.msg = "Thiết lập thành công";
      }
      else
      {
        rsdata.msg = "安装失败";
        if (lan == "En") rsdata.msg = "Set faile";
        if (lan == "Nam") rsdata.msg = "Thiết lập thất bại";
      }


      result.data = rsdata;
      return Json(result);
    }

    [ActionName("getFansList")]
    [HttpGet]
    public async Task<ActionResult> getFansList(string lan, ulong uid, ulong touid, int p)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<UserInfo>() };

      var rstls = await _userService.getFansList(lan, uid, touid, p);
      if (rstls.Count() > 0)
      {
        rsdata.info = rstls;
      }
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("getFollowsList")]
    [HttpGet]
    public async Task<ActionResult> getFollowsList(string lan, ulong uid, ulong touid, int p)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<UserInfo>() };

      var ress = await _userService.getFollowsList(lan, uid, touid, p);
      if (ress != null)
      {
        rsdata.info = ress;
      }
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("ifToken")]
    [HttpGet]
    public async Task<ActionResult> ifToken(string lan, ulong uid, string token)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };

      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
      }
      result.data = rsdata;
      return Json(result);
    }

    [ActionName("checkBlack")]
    [HttpGet]
    public async Task<ActionResult> checkBlack(string lan, ulong uid, string token, ulong touid)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
      var checkToken = await AfterLogin.CheckToken(uid, token);
      if (checkToken == 700)
      {
        rsdata.code = 700;
        rsdata.msg = "您的登陆状态失效，请重新登陆！";
        if (lan == "En") rsdata.msg = "Your login status is invalid, please log in again!";
        if (lan == "Nam") rsdata.msg = "Tình trạng đăng nhập của bạn không hợp lệ, vui lòng đăng nhập lại!";
        result.data = rsdata;
        return Json(result);
      }
      var is_destroy = await _commonService.checkIsDestroyByUid(touid);
      if (is_destroy)
      {
        rsdata.code = 1001;
        rsdata.msg = "对方已注销";
        if (lan == "En") rsdata.msg = "The other party has been cancelled";
        if (lan == "Nam") rsdata.msg = "Đã hủy bỏ";
        result.data = rsdata;
        return Json(result);
      }
      var u2t = await _commonService.isBlack(uid, touid);
      var t2u = await _commonService.isBlack(touid, uid);
      var infoResult = new
      {
        u2t = u2t,
        t2u = t2u
      };
      rsdata.info.Add(infoResult);
      result.data = rsdata;
      return Json(result);
    }
    [ActionName("getAliCdnRecord")]
    [HttpGet]
    public async Task<ActionResult> getAliCdnRecord(string lan, ulong id)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
      var info = await _userService.getCdnRecord(id);
      if (info == null || string.IsNullOrEmpty(info.video_url))
      {
        rsdata.code = 1002;
        rsdata.msg = "直播回放不存在";
        if (lan == "En") rsdata.msg = "Live playback does not exist";
        if (lan == "Nam") rsdata.msg = "Phát lại trực tiếp không tồn tại";
        result.data = rsdata;
        return Json(result);
      }
      var body = new
      {
        url = info.video_url
      };
      rsdata.info.Add(body);
      result.data = rsdata;
      return Ok(result);
    }
  }
}
