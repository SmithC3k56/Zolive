using Microsoft.EntityFrameworkCore;
using zolive_api.Models;
using zolive_api.Models.Login;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Login
{
  public class LoginService : ILoginService
  {
    private readonly newliveContext context;
    private readonly CacheManager cacheManager = new CacheManager();
    private readonly ICommonService _commonService ;


    public LoginService(newliveContext context, ICommonService commonService)
    {
      this.context = context;
            this._commonService = commonService;
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
    public async Task<bool> isAuth(ulong uid)
    {
      var status = await context.CmfUserAuths.Where(x => x.Uid == uid).Select(x => x.Status).FirstOrDefaultAsync();

      return status;

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
        rs.ban_long = Utils.getBanSeconds(ban_long_cal);
        rs.ban_lon1g = baninfo.BanLong;
        rs.ban_reason = baninfo.BanReason ?? "";
        rs.end_bantime = Utils.UnixTimeToDateTime(end_bantime).ToString("yyyy-MM-dd");
        rs.ban_tip = "Thời gian cấm là " + rs.ban_long + " " + rs.end_bantime + " mở khóa";
      }
      return rs;
    }
    public async Task<UserLogin> userLogin(string lan, string user_login, string user_pass)
    {
      UserLogin result = new UserLogin() { code = 0, data = new InfoLoginByModel() };
      InfoLoginByModel infoModel = new InfoLoginByModel();
      user_pass = Utils.setPass(user_pass);
      var info = await context.CmfUsers1.Where(x => x.UserLogin == user_login).FirstOrDefaultAsync();

      if (info == null || info.UserPass != user_pass)
      {
        result.code = 1001;
        return result;//1001
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
        result.code = 1003;
        return result;//1003
      }

      if (info.EndBantime > Utils.time())
      {
        result.code = 1002;
        return result;//1002
      }

      if (info.UserStatus == 3)
      {
        result.code = 1004;
        return result;//1004
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
      result.data = infoModel;
      return result;
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

  }
}
