using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using zolive_api.Models;
using zolive_api.Models.Live;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;
using zolive_model.Models;

namespace zolive_api.Controllers
{
    [Route("appapi/[controller].[action]")]
    [ApiController]
    public class LivesController : Controller
    {
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly ILiveService liveService;
        private readonly ICommonService _commonService;
        private readonly IHomeService _homeService;
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public LivesController(IConfiguration config, ILiveService liveService, IUserService _userService, IHomeService homeService, ICommonService _commonService)
        {
            _config = config;
            this._commonService = _commonService;
            this._homeService = homeService;
            this.liveService = liveService;
            this._userService = _userService;
        }


        [HttpPost]
        [ActionName("createRoom")]
        public async Task<ActionResult> createRoom()
        {
            var title = "";
            var token = "";
            var province = "";
            var lan = "";
            var uid = 0UL;
            var type = 0;
            var type_val = "";
            var city = "";
            var lng = "";
            var lat = "";
            var anyway = 0;
            var deviceinfo = "";
            var isshop = 0;
            var liveclassid = 0UL;
            var FILE = HttpContext.Request.Form.Files.FirstOrDefault();
            var ob = HttpContext.Request.Form.ToArray();
            foreach (var room in ob)
            {
                switch (room.Key)
                {
                    case "lan":
                        lan = room.Value[0];
                        break;
                    case "title":
                        title = room.Value[0];
                        break;
                    case "token":
                        token = room.Value[0];
                        break;
                    case "province":
                        province = room.Value[0];
                        break;
                    case "uid":
                        uid = ulong.Parse(room.Value[0]);
                        break;
                    case "type":
                        type = int.Parse(room.Value[0]);
                        break;
                    case "type_val":
                        type_val = room.Value[0];
                        break;
                    case "city":
                        city = room.Value[0];
                        break;
                    case "lng":
                        lng = room.Value[0];
                        break;
                    case "lat":
                        lat = room.Value[0];
                        break;
                    case "anyway":
                        anyway =int.Parse(room.Value[0]);
                        break;
                    case "deviceinfo":
                        deviceinfo = room.Value[0];
                        break;
                    case "isshop":
                        isshop = int.Parse(room.Value[0]);
                        break;
                    case "liveclassid":
                        liveclassid = ulong.Parse(room.Value[0]);
                        break;
                    //case "user_nicename":
                    //    user_nicename = room.Value[0];
                    //    break;
                    //case "avatar":
                    //    avatar = room.Value[0];
                    //    break;
                    //case "avatar_thumb":
                    //    avatar_thumb = room.Value[0];
                    //    break;
                }
            }

            BaseResult baseResult = new BaseResult();
            baseResult.msg = "";
            baseResult.ret = 200;
            baseResult.debug = new Debug { sqls = new List<object>(), stack = new List<object>(), version = "1.4.2" };
            ResultBaseInfo rs = new ResultBaseInfo() { code = 0, msg = "Mở live thành công", info = new List<CreateRoomResult>() };
            CreateRoomResult info = new CreateRoomResult();
            var configpub = await _commonService.getConfigPub();
            if (configpub.maintain_switch.Value == "1")
            {
                rs.code = 1002;
                rs.msg = configpub.maintain_tips.Value;
                baseResult.data = rs;
                return Json(baseResult);
            }
       
            var checkToken = await AfterLogin.CheckToken(uid, token);
            if (checkToken == 700)
            {
                rs.code = 700;
                rs.msg = "您的登陆状态失效，请重新登陆！";
                if(lan == "En") rs.msg = "Your login status is invalid, please log in again!";
                if (lan == "Nam") rs.msg = "Bạn đang đăng nhập không hợp lệ, vui lòng đăng nhập lại!";
               
                baseResult.data = rs;
                return Json(baseResult);
            }
            var isban = await AfterLogin.isban(uid);
            if (isban == 0)
            {
                rs.code = 1001;
                rs.msg = "该账号已被禁用";
                if (lan == "En") rs.msg = "The account has been disabled";
                if (lan == "Nam") rs.msg = "Tài khoản đã bị cấm";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var result = await liveService.checkBan(uid);
            if (result == 1)
            {
                rs.code = 1015;
                rs.msg = "已被禁播";
                if (lan == "En") rs.msg = "Has been banned";
                if (lan == "Nam") rs.msg = "Đã bị cấm";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var configpri = await _commonService.getConfigPri();
            if (configpri.auth_islimit.Value == "1")
            {
                var isAuth = await liveService.isAuth(uid);
                if (!isAuth)
                {
                    rs.code = 1002;
                    rs.msg = "请先进行身份认证或等待审核";
                    if(lan == "En") rs.msg = "Please go to the authentication or wait for review";
                    if (lan == "Nam") rs.msg = "Vui lòng điều hành xác thực hoặc đợi để xem xét";
                    baseResult.data = rs;
                    return Json(baseResult);
                }
            }
            var userinfo = await _homeService.getUserInfo("Nam", uid);
            if (configpri.level_islimit.Value == "1")
            {
                if (userinfo.level < uint.Parse(configpri.level_limit.Value))
                {
                    rs.code = 1003;
                    rs.msg = "等级小于" + configpri.level_limit.Value + "级，不能直播";
                    if (lan == "En") rs.msg ="Level is less than" + configpri.level_limit.Value + "Level, cannot live stream";
                    if (lan == "Nam") rs.msg ="Cấp độ nhỏ hơn" + configpri.level_limit.Value + "Cấp độ, không thể phát trực tiếp";
                    baseResult.data = rs;
                    return Json(baseResult);
                }
            }
            var nowtime = Utils.time();
            var showid = nowtime;
            var starttime = nowtime;

            var sensitivewords = await _userService.sensitiveField(title);
            if (sensitivewords == 1001)
            {
                rs.code = 10011;
                rs.msg = "输入非法，请重新输入";
                if(lan == "En") rs.msg = "Illegal input, please re-enter";
                if(lan == "Nam") rs.msg = "Đầu vào không hợp lệ, vui lòng nhập lại";
                baseResult.data = rs;
                return Json(baseResult);
            }
            if (type == 1 && type_val == "")
            {
                rs.code = 1002;
                rs.msg = "密码不能为空";
                if(lan == "En") rs.msg ="Password can not be blank";
                if(lan == "Nam") rs.msg ="Mật khẩu không được để trống";
                baseResult.data = rs;
                return Json(baseResult);
            }
            else if (type > 1 && int.Parse(type_val) <= 0)
            {
                rs.code = 1002;
                rs.msg = "价格不能小于等于0";
                if(lan == "En") rs.msg = "Price cannot be less than or equal to 0";
                if(lan == "Nam") rs.msg = "Giá không được nhỏ hơn hoặc bằng 0";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var stream = uid + "_" + nowtime;
            var wy_cid = "";
            var pull = "";
            var push = "";
            if (configpri.cdn_switch.Value == "5")
            {
                var privateResult = await _commonService.PrivateKeyA("rtmp", stream, 1);
                var wyinfo = await JsonConvert.DeserializeObject<dynamic>(privateResult);
                pull = wyinfo.ret.rtmpPullUrl;
                wy_cid = wyinfo.ret.cid;
                push = wyinfo.ret.pushUrl;
            }
            else
            {
                push =  _commonService.PrivateKeyA("rtmp", stream, 1).Result;
                pull = await _commonService.PrivateKeyA("rtmp", stream, 0);
            }

            if (string.IsNullOrEmpty(city))
            {
                city = "好像在火星";
                if (lan == "En") city ="New York";
                if (lan =="Nam") city ="Hồ Chí Minh";
            }
            if (string.IsNullOrEmpty(lng) && lng != "0")
            {
                lng = "";
            }
            if (string.IsNullOrEmpty(lat) && lat != "0")
            {
                lat = "";
            }
            var thumb = "";
            if (FILE != null)
            {
               
                var nameFile = FILE.FileName;
                if (!Utils.checkExt(nameFile))
                {
                    rs.code = 1004;
                    rs.msg = "图片仅能上传 jpg,png,jpeg";
                    baseResult.data = rs;
                    return Json(baseResult);
                }
                var uptype = _config.GetValue<int>("uptype");
                if(uptype == 1)
                {
                    //FILE.Tmp
                }
                try
                {
                    WebClient client = new WebClient();
                    // upload video 
                    //client.UploadFileAsync();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var liang = await _commonService.getUserLiang(uid);
            var goodnum = 0;
            if (liang.name != "0")
            {
                goodnum = int.Parse(liang.name);
            }
            info.liang = liang;
            var vip = await _commonService.getUserVip(uid);
            info.vip = vip;

            var dataroom = new CmfLive()
            {
                Uid = uid,
                Showid = showid,
                Starttime = starttime,
                Title = title,
                Province = province,
                City = city,
                Stream = stream,
                Thumb = thumb,
                Pull = pull,
                Lng = lng,
                Lat = lat,
                Type = type,
                TypeVal = type_val,
                Goodnum = goodnum.ToString(),
                Isvideo = false,
                Islive = 0,
                WyCid = wy_cid,
                Anyway = anyway,
                Liveclassid = liveclassid,
                Deviceinfo = deviceinfo,
                Isshop = isshop,
                Hotvotes = 0,
                Pkuid = 0,
                Pkstream = "",
                BankerCoin = 10000000
            };
            var createRomeResult = await liveService.createRoom(uid, dataroom);
            if (createRomeResult == 0)
            {
                rs.code = 1011;
                rs.msg = "开播失败，请重试";
                if (lan  == "En") rs.msg = "Start failed, please try again";
                if (lan  == "Nam") rs.msg = "Bắt đầu không thành công, vui lòng thử lại";
                baseResult.data = rs;
                return Json(baseResult);
            }
            var data = "city=" + city;
            await _userService.userUpdate(uid, data);
            userinfo.city = city;
            userinfo.usertype = 50;
            userinfo.sign = "0";

            await cacheManager.SetCacheString(token, JsonConvert.SerializeObject(userinfo));
            var votestotal = await liveService.getVotes(uid);
            info.userlist_time = configpri.userlist_time.Value;
            info.barrage_fee = configpri.barrage_fee.Value;
            info.chatserver = configpri.chatserver.Value;
            info.votestotal = votestotal;
            info.stream = stream;
            info.push = push;
            info.pull = pull;
            info.game_switch = configpri.game_switch.Value;
            info.game_bankerid = "0";
            info.game_banker_name = "吕布";
            info.game_banker_avatar = "";
            info.game_banker_coin = Utils.NumberFormat("Nam", 10000000);
            info.game_banker_limit = configpri.game_banker_limit.Value;
            info.tx_appid = configpri.tx_appid.Value;
            info.jackpot_level = "-1";
            var guard_nums = await liveService.getGuardNums(uid);
            info.guard_nums = guard_nums;
            var jackpotset = await liveService.getJackpotSet() ?? "";
            if (jackpotset.Contains("switch"))
            {
                var jackpotinfo = await liveService.getJackpotInfo();
                info.jackpot_level = jackpotinfo.Level.ToString();
            }
            
            if (!string.IsNullOrEmpty(configpri.sensitive_words.Value))
            {
                info.sensitive_words = configpri.sensitive_words.Value.Split(',');
            }
            if (!string.IsNullOrEmpty(thumb))
            {
                info.thumb = Utils.get_upload_path(thumb);
            }
            else
            {
                info.thumb = userinfo.avatar_thumb;
            }
            rs.info.Add(info);
            baseResult.data = rs;

            return Json(baseResult);
        }

    }
}
