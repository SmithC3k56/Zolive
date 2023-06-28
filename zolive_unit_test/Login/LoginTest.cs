using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using zolive_api.Models;
using zolive_api.Models.Login;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test
{
  public class LoginTest
  {
    public static readonly newliveContext context = new newliveContext();
    public static readonly CacheManager cacheManager = new CacheManager();
    public static readonly IRedis redis;
    public static Random rnd = new Random();
        private ICommonService _commonService;
    public static IConfiguration InitConfiguration()
    {

      var config = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .Build();
      return config;
    }

    [SetUp]
    public void Setup()
    {
      var config = InitConfiguration();
      ConfigNew.Configuration = config;
    }


    [Test]
    public async Task MainTest()
    {

    }

    public async Task<int> userFindPass(string user_login, string user_pass)
    {
      var user_info = await context.CmfUsers1.Where(x => x.UserLogin == user_login && x.UserType == 2).FirstOrDefaultAsync();
      if (user_info == null) return 1006;

      user_pass = Utils.setPass(user_pass);
      user_info.UserPass = user_pass;
      context.CmfUsers1.Update(user_info);
      await context.SaveChangesAsync();
      return 1;
    }

    public async Task getCode(string lan, string mobile, string sign)
    {
      if (String.IsNullOrEmpty(mobile) || String.IsNullOrEmpty(sign))
      {
        //return show mes error;
      }
      var checkuser = await checkUser(mobile);

      if (checkuser)
      {
        // return message account registered;
      }

      var mobile_code = rnd.Next(6, 1);


    }

    public async Task<ResultBaseInfo> sendCode(string mobile, string code)
    {
      ResultBaseInfo rs = new ResultBaseInfo();
      rs.info = new List<object>();
      rs.msg = "";
      rs.code = 0;
      var config = await _commonService.getConfigPri();
      if (config.sendcode_switch == null)
      {
        rs.code = 667;
        rs.msg = "123456";
        return rs;
        // return message with content: 123456;
      }
      var qp = mobile.Substring(0, 2);
      if (int.Parse(qp) == 86)
      {
        var phone = mobile.Substring(2, 11);
        var smsapi = "http://api.smsbao.com/";
        var content = "【ZoLive】Hi！Your ZoLive verification code is:" + code;
        var sendurl = smsapi + "sms?u=newliveroyal&p=" + Utils.MD5Hash("Selina111") + "&m=" + phone + "&c=" + HttpUtility.UrlEncode(content);
        var rt = await file_get_content(sendurl);
        if (rt == "0")
        {
          CmfSendcode data = new CmfSendcode();
          data.Type = 1;
          data.Account = mobile;
          data.Content = content;
          await setSendcode(data);
          return rs;
        }
        else
        {
          rs.code = 1008611;
          rs.msg = "Không gửi được sms. Có lỗi sảy ra. Vui long liên hệ với admin";

        }
      }
      return rs;
    }

    public async Task userReg(string lan, string user_login, string user_pass, string user_pass2, string source, string code)
    {
      var reg_mobile = user_login;
      var reg_mobile_code = "250701";
      if (string.IsNullOrEmpty(reg_mobile) || string.IsNullOrEmpty(reg_mobile_code))
      {
        return;//return message notification about not null here;
      }

      if (user_pass != user_pass2)
      {
        return;//inconsistent
      }
      var check = passcheck(user_pass);

      if (!check)
      {
        // return pass invalid
      }


    }



    [Test]
    public async Task Testtt()
    {
      await userReg("84966803014", "abc123", "Android");
    }

    public async Task<int> userReg(string user_login, string user_pass, string source)
    {
      user_pass = Utils.setPass(user_pass);
      var configpri = await _commonService.getConfigPri();

      var reg_reward = configpri.reg_reward;

      CmfUser1 data = new CmfUser1();
      data.UserLogin = user_login;
      data.Mobile = user_login;
      data.UserNicename = "User" + user_login.Substring(7);
      data.UserPass = user_pass;
      data.Signature = "";
      data.Avatar = "/default.jpg";
      data.AvatarThumb = "/default_thumb.jpg";
      data.LastLoginIp = Utils.GetLocalIPAddress();
      data.CreateTime = Utils.time();
      data.UserStatus = 1;
      data.UserType = 2;
      data.Source = source;
      data.Coin = reg_reward;
      data.Birthday = 0;
      data.Sex = 0;
      data.Score = 0;
      data.Consumption = 0;
      data.Education = "";
      data.UserUrl = "";
      data.UserEmail = "";
      data.UserActivationKey = "";
      data.Votes = 0;
      data.Votestotal = 0;
      data.Province = "";
      data.City = "";
      data.Isrecommend = false;
      data.Openid = "";
      data.LoginType = "phone";
      data.Iszombie = false;
      data.Isrecord = false;
      data.Iszombiep = false;
      data.Issuper = false;
      data.Ishot = false;
      data.Goodnum = "";
      data.Location = "";
      data.EndBantime = 0;
      data.Balance = 0;
      data.BalanceTotal = 0;
      data.BalanceConsumption = 0;
      data.Professional = "";
      data.Area = "";
      data.Url1 = "";
      data.Je = 0;


      var isexit = await context.CmfUsers1.Where(x => x.UserLogin == user_login).FirstOrDefaultAsync();
      if (isexit != null)
      {
        return 1006;// return 1006
      }

      var rs = await context.CmfUsers1.AddAsync(data);
      await context.SaveChangesAsync();

      var info = await context.CmfUsers1.Where(x => x.UserLogin == user_login).FirstOrDefaultAsync();
      if (info == null)
      {
        return 1007;// return 1007
      }
      var uid = info.Id;
      var reg_rewardl = int.Parse(reg_reward.Value);
      if (reg_rewardl > 0)
      {

        CmfUserCoinrecord insert = new CmfUserCoinrecord()
        {
          Type = 1,
          Action = 11,
          Uid = uid,
          Giftid = 0,
          Touid = uid,
          Giftcount = 1,
          Totalcoin = reg_reward,
          Showid = 0,
          Addtime = Utils.time()
        };
        await context.CmfUserCoinrecords.AddAsync(insert);
        await context.SaveChangesAsync();
      }
      var code = Utils.createCode();
      CmfAgentCode code_info = new CmfAgentCode() { Uid = uid, Code = code };

      var agencode = await context.CmfAgentCodes.Where(x => x.Uid == uid).FirstOrDefaultAsync();
      if (agencode != null)
      {
        context.CmfAgentCodes.Update(code_info);
      }
      else
      {
        await context.AddAsync(code_info);
      }
      await context.SaveChangesAsync();
      return 1;

    }
    public bool passcheck(string user_pass)
    {
      Regex rgx = new Regex(@"/^(?=.*[A-Za-z])(?=.*[0-9])[a-zA-Z0-9~!@&%#_]{6,20}$/");
      var isok = rgx.IsMatch(user_pass);
      return isok;
    }

    public async Task setSendcode(CmfSendcode data)
    {
      if (data != null)
      {
        data.Addtime = Utils.time();

        await context.CmfSendcodes.AddAsync(data);
        await context.SaveChangesAsync();
      }

    }

    [Test]
    public async Task testLogin()
    {
      await userLogin("En", "84966803014", "abc123");
    }

    public async Task<InfoLoginByModel> userLogin(string lan, string user_login, string user_pass)
    {
      InfoLoginByModel infoModel = new InfoLoginByModel();
      user_pass = Utils.setPass(user_pass);
      var info = await context.CmfUsers1.Where(x => x.UserLogin == user_login).FirstOrDefaultAsync();

      if (info == null || info.UserPass != user_pass)
      {
        return new InfoLoginByModel();//1001
      }
      else
      {
        infoModel.id = info.Id;
        infoModel.user_nicename = info.UserNicename;
        infoModel.avatar = info.Avatar;
        infoModel.avatar_thumb = info.AvatarThumb;
        infoModel.sex = info.Sex;
        infoModel.signature = info.Signature;
        infoModel.coin = info.Coin;
        infoModel.consumption = info.Consumption;
        infoModel.votestotal = info.Votestotal;
        infoModel.province = info.Province;
        infoModel.city = info.City;
        infoModel.login_type = info.LoginType;
        infoModel.location = info.Location;
        infoModel.last_login_time = info.LastLoginTime;
      }

      if (info.UserStatus == 0)
      {
        return new InfoLoginByModel();//1003
      }

      if (info.EndBantime > Utils.time())
      {
        return new InfoLoginByModel();//1002
      }

      if (info.UserStatus == 3)
      {
        return new InfoLoginByModel();//1004
      }

      infoModel.isreg = 0;
      if (info.Birthday != null || info.Birthday > 0)
      {
        infoModel.birthday = Utils.datetime(lan, info.Birthday ?? 0);
      }
      else
      {
        infoModel.birthday = "";
      }
      infoModel.level = await _commonService.getLevel(info.Consumption);
      infoModel.level_anchor = await _commonService.getLevelAnchor(info.Votestotal);
      infoModel.token = Utils.MD5Hash(Utils.MD5Hash((info.Id + user_login + Utils.time()).ToString()));
      infoModel.avatar = Utils.get_upload_path(info.Avatar);
      infoModel.avatar_thumb = Utils.get_upload_path(info.AvatarThumb);
      await _commonService.updateToken(info.Id, infoModel.token);
      return infoModel;
    }

    public async Task<baninfoModel> getUserban(string user_login)
    {
      var userinfo = await context.CmfUsers1.Where(x => x.UserLogin == user_login && x.UserType == 2).Select(x => new
      {
        id = x.Id,
        end_bantime = x.EndBantime
      }).FirstOrDefaultAsync();

      if (userinfo == null)
      {
        return new baninfoModel();
      }
      else
      {
        var rs = await baninfo(userinfo.id, userinfo.end_bantime);
        return rs;
      }
    }

    public async Task<baninfoModel> baninfo(ulong uid, long end_bantime)
    {
      baninfoModel rs = new baninfoModel() { ban_long = "0", ban_lon1g = 0, ban_reason = "", end_bantime = "0", ban_tip = "" };

      var baninfo = await context.CmfUserBanrecords.Where(x => x.Uid == uid).FirstOrDefaultAsync();
      if (baninfo != null)
      {
        var ban_long_cal = Convert.ToDecimal(baninfo.BanLong - Utils.time());
        rs.ban_long = getBanSeconds(ban_long_cal);
        rs.ban_lon1g = baninfo.BanLong;
        rs.ban_reason = baninfo.BanReason ?? "";
        rs.end_bantime = Utils.UnixTimeToDateTime(end_bantime).ToString("yyyy-MM-dd");
        rs.ban_tip = "Thời gian cấm là " + rs.ban_long + " " + rs.end_bantime + " mở khóa";
      }
      return rs;
    }

    public string getBanSeconds(decimal cha, int type = 0)
    {
      var iz = Math.Floor(cha / 60);
      var hz = Math.Floor(iz / 60);
      var dz = Math.Floor(hz / 60);

      var s = cha % 60;
      var i = Math.Floor(iz % 60);
      var h = Math.Floor(hz / 24);

      string rs, ri, rh, rhz = "";

      if (type == 1)
      {
        if (s < 10)
        {
          rs = "0" + s;
        }
        if (i < 10)
        {
          ri = "0" + i;
        }
        if (h < 10)
        {
          rh = "0" + h;
        }
        if (hz < 10)
        {
          rhz = "0" + hz;
        }
        return hz + ":" + i + ":" + s;
      }
      if (cha < 60)
      {
        return cha + "giây";
      }
      else if (iz < 60)
      {
        return iz + "phút" + s + "giây";
      }
      else if (hz < 24)
      {
        return hz + "giờ" + i + "phút";
      }
      else if (dz < 30)
      {
        return dz + "ngày" + h + "giờ";
      }
      else
      {
        return "";
      }
    }
    //[Test]
    //public async Task testGetContent()
    //{
    //    var test = await file_get_content("Https://google.com");
    //}
    public async Task<string> file_get_content(string url)
    {
      if (String.IsNullOrEmpty(url) || String.IsNullOrWhiteSpace(url))
      {
        return "Địa chỉ không được để trống";
      }
      else
      {
        var webRequest = WebRequest.Create(url);

        var strContent = "";
        using (var response = webRequest.GetResponse())
        using (var content = response.GetResponseStream())
        using (var reader = new StreamReader(content))
        {
          strContent = await reader.ReadToEndAsync();
        }
        return strContent;
      }

    }
    public async Task<bool> checkUser(string mobile)
    {
      if (String.IsNullOrEmpty(mobile))
      {
        return false;
      }
      var isExit = await context.CmfUsers1.Where(x => x.UserLogin == mobile).FirstOrDefaultAsync();
      if (isExit != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

  }
}
