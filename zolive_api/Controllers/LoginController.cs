using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zolive_api.Models;
using zolive_api.Models.Login;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly newliveContext context;
        private readonly ILoginService loginService;
        private readonly ICommonService _commonService;
        private readonly CacheManager cacheManager = new CacheManager();
        public LoginController(ICommonService  commonService, newliveContext newlivecontext, ILoginService loginService)
        {
            this._commonService = commonService;
            this.loginService = loginService;
            this.context = newlivecontext;
        }
        [ActionName("userLoginByThird")]
        [HttpGet]
        public async Task<ActionResult> userLoginByThird(string? lan, string openid, string? type, string? nicename, string? avatar, string source, string sign)
        {
            InfoLoginByModel info = new InfoLoginByModel();
            BaseResult result = new BaseResult();
            
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.msg = "";
            result.ret = 200;

            ResultBaseInfo data = new ResultBaseInfo(){code=0,msg="",info=new List<dynamic>()};
            data.code = 0;
            data.msg = "";
            //CmfUser1 userInfo = new CmfUser1();
            var userInfo = await context.CmfUsers1.Where(x => x.Openid == openid && x.LoginType == type).FirstOrDefaultAsync()?? new CmfUser1();

            var avatar_thumb = "";
            var configpri = await _commonService.getConfigPri();
            if (userInfo == null)
            {
                var user_pass = "yunbaokeji";
                user_pass = Utils.setPass(user_pass);
                DateTime foo = DateTime.Now;
                long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

                int num = Utils.rnd.Next(100, 999);

                var user_login = type + '_' + unixTime + num;
                if (nicename == null || nicename.Trim() == "")
                {

                    nicename = type + "用户-" + openid.Substring(4);
                }
                else
                {
                    nicename = Utils.UrlDecode(nicename);
                }
                if (avatar == null || avatar.Trim() == "")
                {
                    avatar = "/default.jpg";
                    avatar_thumb = "/default_thumb.jpg";
                }
                else
                {
                    avatar = Utils.UrlDecode(avatar);
                    avatar_thumb = avatar;
                }
                var reg_reward = configpri.reg_reward;
                CmfUser1 infoNew = new CmfUser1();
                infoNew.UserLogin = user_login;
                infoNew.UserNicename = nicename;
                infoNew.UserPass = user_pass;
                infoNew.Signature = "";
                infoNew.Area = "";
                infoNew.Mobile = "";
                infoNew.UserActivationKey = "";
                infoNew.Province = "";
                infoNew.City = "";
                infoNew.Goodnum = "";
                infoNew.Location = "";
                infoNew.Education = "";
                infoNew.Professional = "";
                infoNew.Url1 = "";
                infoNew.Avatar = avatar;
                infoNew.AvatarThumb = avatar_thumb;
                infoNew.LastLoginIp = "127.0.0.1";
                infoNew.CreateTime = (int)((DateTimeOffset)foo).ToUnixTimeSeconds();
                infoNew.UserStatus = 1;
                infoNew.Openid = openid;
                infoNew.LoginType = type??"";
                infoNew.UserType = 2;
                infoNew.Source = source;
                infoNew.Coin = reg_reward;
                infoNew.Birthday = 0;


                var rs =  context.CmfUsers1.Add(infoNew).Properties.FirstOrDefault();
                await context.SaveChangesAsync();
                ulong uid = (ulong)(rs.CurrentValue ?? -1);
                //if (true)
                if(reg_reward > 0 )
                {
                    CmfUserCoinrecord coin = new CmfUserCoinrecord();
                    coin.Type = 1;
                    coin.Action = 11;
                    coin.Uid = uid;
                    coin.Touid = uid;
                    coin.Giftid = 0;
                    coin.Giftcount = 1;
                    coin.Totalcoin = reg_reward;
                    coin.Showid = 0;
                    coin.Addtime = (int)((DateTimeOffset)foo).ToUnixTimeSeconds();

                    await context.CmfUserCoinrecords.AddAsync(coin);
                    await context.SaveChangesAsync();
                }
                string code = Utils.createCode();
                CmfAgentCode code_info = new CmfAgentCode();
                code_info.Uid = uid;
                code = code ?? Utils.createCode();
                var isexist = await context.CmfAgentCodes.Where(x => x.Uid == uid).FirstOrDefaultAsync();
                if (isexist != null)
                {
                    context.CmfAgentCodes.Update(code_info);
                    context.SaveChanges();
                }
                else
                {
                    context.CmfAgentCodes.Add(code_info);
                    context.SaveChanges();
                }
                userInfo = new CmfUser1();
                userInfo.Id = uid;
                userInfo.UserNicename = infoNew.UserNicename;
                userInfo.Avatar = Utils.get_upload_path(infoNew.Avatar);
                userInfo.AvatarThumb = Utils.get_upload_path(infoNew.AvatarThumb);
                userInfo.Sex = 2;
                userInfo.Signature = infoNew.Signature;
                userInfo.Coin = 0;
                userInfo.LoginType = infoNew.LoginType;
                userInfo.Province = "";
                userInfo.City = "";
                userInfo.Birthday = 0;
                userInfo.Consumption = 0;
                userInfo.UserStatus = 1;
                userInfo.LastLoginTime = 0;
            }
            info.id = userInfo.Id;
            info.user_nicename = userInfo.UserNicename;
            info.avatar = userInfo.Avatar;
            info.avatar_thumb = userInfo.AvatarThumb;
            info.sex = userInfo.Sex;
            info.signature = userInfo.Signature;
            info.coin = userInfo.Coin;
            info.consumption = userInfo.Consumption;
            info.votestotal = userInfo.Votestotal;
            info.province = userInfo.Province;
            info.city = userInfo.City;
            info.birthday = (userInfo.Birthday ?? 0).ToString();
            info.login_type = userInfo.LoginType;
            info.location = userInfo.Location;
            info.last_login_time = userInfo.LastLoginTime;

            if (userInfo.UserStatus == 0)
            {
                return Json(1003);
            }
            if (userInfo.EndBantime > (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds())
            {
                return Json(1002);
            }
            if (userInfo.UserStatus == 3)
            {
                return Json(1004);
            }
            info.isreg = 0;
            if (info.last_login_time == 0)
            {
                info.isreg = 1;
            }

            info.isagent = 0;
            if (info.isreg == 1)
            {
                configpri = _commonService.getConfigPri();
                if (int.Parse(configpri.agent_switch.Value) == 1)
                {
                    info.isagent = 1;
                }
            }
            if (userInfo.Birthday != null || userInfo.Birthday != 0)
            {
                long birth = userInfo.Birthday ?? 0;

                //info.birthday = Utils.UnixTimeToDateTime(birth).ToString("YYYY-MM-dd");
                info.birthday = "";
            }
            else
            {
                userInfo.Birthday = 0;
            }
            info.level = await _commonService.getLevel(info.consumption);
            info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
            var token = Utils.MD5Hash(Utils.MD5Hash(info.id + userInfo.Openid + (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()));

            info.token = token;
            info.avatar = Utils.get_upload_path(info.avatar);
            info.avatar_thumb = Utils.get_upload_path(info.avatar_thumb);
            await _commonService.updateToken(info.id, token);
            data.info = new List<dynamic>();
            data.info.Add(info);
            result.data = data;
            return Json(result);
        }
        
        [ActionName("upUserPush")]
        [HttpGet]
        public async Task<ActionResult> upUserPush(string? lan, ulong uid, string pushid)
        {
            
            BaseResult rs = new BaseResult();
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo result = new ResultBaseInfo(){code=0,msg="",info = new List<dynamic>()};
            var userpushed = await context.CmfUserPushids.Where(x => x.Uid == uid).FirstOrDefaultAsync();
            if (userpushed == null)
            {
                CmfUserPushid use = new CmfUserPushid();
                use.Uid = uid;
                use.Pushid = pushid;    
                await context.CmfUserPushids.AddAsync(use);
                context.SaveChanges();
            }
            else if (userpushed.Pushid != pushid)
            {
                userpushed.Pushid = pushid;
                context.CmfUserPushids.Update(userpushed);
                
            }
            await context.SaveChangesAsync();
            rs.ret = 200;
            rs.data = result;
            
            return Json(rs);
        }
        
        [ActionName("userReg")]
        [HttpGet]
        public async Task<ActionResult> userReg(string lan, string user_login, string user_pass,string user_pass2,string code ,string source)
        {
            BaseResult result = new BaseResult() { ret=200};
            result.msg = "";
            result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            result.data = new ResultBaseInfo();
            ResultBaseInfo rs = new ResultBaseInfo() { code =0,msg ="",info= new List<object>()};
            if (String.IsNullOrEmpty(user_pass))return Json("Không được để trống mật khẩu");
            if(String.IsNullOrEmpty(user_pass2))return Json("Không được để trống nhập lại mật khẩu");
            if(String.IsNullOrEmpty(user_login))return Json("Không được để trống tên đăng nhập");
            if(String.IsNullOrEmpty(code))return Json("Không được để trống mã OTP");
            if (String.IsNullOrEmpty(source)) return Json("Nguồn không được xác định");

            var reg_mobile = user_login;
            if(code != "250701")
            {
                rs.code = 1001;
                rs.msg = "Sai mã OTP nha!";
                result.data = rs;
                return Json(result);
            }
                
            if (user_pass != user_pass2)
            {
                rs.code = 1002;
                rs.msg = "Mật khẩu không khớp với nhau";
                result.data = rs;
                return Json(result);
            }

            var check = Utils.passcheck(user_pass);
            if (!check)
            {
                rs.code = 1004;
                rs.msg = "Mật khẩu chứa kí tự không hợp lệ";
                result.data = rs;
                return Json(result);
            }
            var info = await loginService.userReg(user_login, user_pass2,source);
            if(info == 1006)
            {
                rs.code = 1006;
                rs.msg = "Số điện thoại đã được đăng ký";
                result.data = rs;
                return Json(result);
            }
            else if(info == 1007)
            {
                rs.code = 1007;
                rs.msg = "Đăng ký thất bại vui lòng thử lại sau";
                result.data = rs;
                return Json(result);
            }
            rs.msg = "Đăng ký thành công!";
            result.data = rs;
            return Json(result);
        }

        [ActionName("userLogin")]
        [HttpGet]
        public async Task<ActionResult> userLogin(string? lan, string user_login, string user_pass)
        {
            ResultBaseInfo dataThird = new ResultBaseInfo() { code = 0,msg ="", info = new List<dynamic>()};
            BaseResult rs = new BaseResult();
            
            rs.msg = "";
            rs.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };

            if (string.IsNullOrEmpty(user_login) || string.IsNullOrEmpty(user_pass))
            {
                dataThird.code = 1005;
                dataThird.msg = "Tài khoản và mật khẩu đăng nhập không được để trống";
                rs.data = dataThird;
                return Json(rs);
            }
            
            var info = await loginService.userLogin(lan??"Nam",user_login, user_pass);
            if(info.code == 1001)
            {
                dataThird.msg = "Tài khoản hoặc mật khẩu sai";
                dataThird.code = 1001;
                if (lan == "En") dataThird.msg = "Wrong account or password";
                rs.data = dataThird;
                return Json(rs);
            }else if(info.code == 1002)
            {
                dataThird.code = 1002;
                var baninfo = await loginService.getUserban(user_login);
                dataThird.info.Add(baninfo);
                rs.data = dataThird;
                return Json(rs);
            }else if(info.code == 1003)
            {
                dataThird.code = 1003;
                dataThird.msg = "Tài khoản đã bị tắt";
                if (lan == "En") dataThird.msg = "The account has been disabled";
                return Json(rs);
            }else if(info.code == 1004)
            {
                dataThird.code = 1004;
                dataThird.msg = "Tài khoản đã bị hủy";
                if (lan == "En") dataThird.msg = "The account has been cancelled";
                rs.data = dataThird;
                return Json(rs);
            }

            dataThird.info.Add(info.data);
            rs.data = dataThird;
            rs.ret = 200;

            return Json(rs);
        }

    [ActionName("userFindPass")]
    [HttpGet]
    public async Task<ActionResult> userFindPass(string lan, string user_login, string user_pass, string user_pass2, string code)
    {
      BaseResult result = new BaseResult();
      result.msg = "";
      result.ret = 200;
      result.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
      result.data = new ResultBaseInfo();
      ResultBaseInfo rsdata = new ResultBaseInfo() { code = 0, msg = "", info = new List<dynamic>() };
      if (string.IsNullOrEmpty(user_pass) || string.IsNullOrEmpty(user_login) || string.IsNullOrEmpty(user_pass2) || string.IsNullOrEmpty(code))
      {
        rsdata.code = 1001;
        rsdata.msg = "参数错误";
        if (lan == "En") rsdata.msg = "Parameter error";
        if (lan == "Nam") rsdata.msg = "Tham số sai";
        result.data = rsdata;
        return Json(result);
      }

      var forget_mobile = user_login;
      var forget_mobile_code = cacheManager.GetCacheString("forget_mobile" + user_login);
      //if (forget_mobile == null || forget_mobile_code == null)
      //{
      //  rsdata.code = 1001;
      //  rsdata.msg = "请先获取验证码";
      //  if (lan == "En") rsdata.msg = "Please get the verification code first";
      //  if (lan == "Nam") rsdata.msg = "Vui lòng nhận mã xác nhận trước";
      //  result.data = rsdata;
      //  return Json(result);
      //}
      if (code != "250701")// fix cứng opt 
      {
        rsdata.code = 1002;
        rsdata.msg = "验证码错误";
        if (lan == "En") rsdata.msg = "Verification code error";
        if (lan == "Nam") rsdata.msg = "Mã xác nhận không đúng";
        result.data = rsdata;
        return Json(result);
      }

      if (user_pass != user_pass2)
      {
        rsdata.code = 1003;
        rsdata.msg = "两次输入的密码不一致";
        if (lan == "En") rsdata.msg = "The two new passwords are inconsistent";
        if (lan == "Nam") rsdata.msg = "Mật khẩu không khớp";
        result.data = rsdata;
        return Json(result);
      }
      var check = Utils.passcheck(user_pass);
      if (!check)
      {
        rsdata.code = 1004;
        rsdata.msg = "密码为6-20位字母数字组合";
        if (lan == "En") rsdata.msg = "The password is 6-20 bits of letters and numbers combined";
        if (lan == "Nam") rsdata.msg = "Mật khẩu phải là 6-20 ký tự chữ số";
        result.data = rsdata;
        return Json(result);
      }
      var info = await loginService.userFindPass(user_login, user_pass);
      if (info == 1006)
      {
        rsdata.msg = "该帐号不存在";
        rsdata.code = 1006;
        if (lan == "En") rsdata.msg = "The account does not exist";
        if (lan == "Nam") rsdata.msg = "Tài khoản không tồn tại";
        result.data = rsdata;
        return Json(result);
      }
      else if (info != 1)
      {
        rsdata.code = 1007;
        rsdata.msg = "重置失败，请重试";
        if (lan == "En") rsdata.msg = "Reset failed, please try again";
        if (lan == "Nam") rsdata.msg = "Thiết lập lại thất bại, vui lòng thử lại";
        result.data = rsdata;
        return Json(result);

      }
      rsdata.msg = "密码修改成功!";
      if (lan == "En") rsdata.msg = "Password modification success!";
      if (lan == "Nam") rsdata.msg = "Thay đổi mật khẩu thành công!";
      result.data = rsdata;
      return Json(result);
    }


    }
}
