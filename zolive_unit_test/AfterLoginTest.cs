using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Web;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Linq;
using zolive_api.Models.Home;
using zolive_api.Models.User;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;
using Microsoft.AspNetCore.Http;
using StackExchange.Redis;
using System.Security.Cryptography;
using zolive_api.Models;
using System.Net;
using System.IO;
using zolive_api.Services.Home;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zolive_api.Services.Interface;

namespace zolive_unit_test
{
    public class AfterLoginTest
    {
        public static readonly newliveContext context = new newliveContext();
        public static readonly CacheManager cacheManager = new CacheManager();
        public static readonly IRedis redis;
        public static Random rnd = new Random();
        private static ICommonService _commonService;
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
            //Bonus(45018, "c06e4a807a3fc142b1e7e84989090e88");
            //getFollow("En", 45018, 1);
            //getHot("En",1);
            //var rs = getSlide();
            //await getClassLive("Nam", 2, 1);
        }

        [Test]
        public  async Task LoginTest()
        {
            await getLoginBonus(45018);
        }

        public  async Task<int> getLoginBonus(ulong uid)
        {
            var rs = 0;
            var configpri =await _commonService.getConfigPri();
            if(configpri.bonus_switch == null|| configpri.bonus_switch == "")
            {
                return rs;
            }

            var key = "loginbonus";
            var list = cacheManager.GetCacheString(key);
            List<BonusList> bonus_coin = new List<BonusList>();
            
            if (list == null)
            {
                var loginBonus = await context.CmfLoginbonus.Select(x => new
                {
                    day = x.Day,
                    coin = x.Coin
                }).ToListAsync();
               if(loginBonus != null)
                {
                    foreach(var bonus in loginBonus)
                    {
                        BonusList obj = new BonusList();
                        obj.day = bonus.day;
                        obj.coin = bonus.coin;
                          bonus_coin.Add(obj);
                    }
                    await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(loginBonus));
                }
            }
            else
            {
                bonus_coin = JsonConvert.DeserializeObject<List<BonusList>>(list??"")?? new List<BonusList>();
            }
            var isadd = 0;
            var signDb =await context.CmfUserSigns.Where(x => x.Uid == uid).Select(x => new
            {
                bonus_day = x.BonusDay,
                bonus_time = x.BonusTime,
                count_day = x.CountDay
            }).FirstOrDefaultAsync();

            SignInfo signInfo = new SignInfo();

            if (signDb == null)
            {
                isadd = 1;
                signInfo.count_day = 0;
                signInfo.bonus_time = 0;
                signInfo.bonus_day = 0;
            }
            else
            {
                signInfo.bonus_day = signDb.bonus_day;
                signInfo.bonus_time = signDb.bonus_time;
                signInfo.count_day = signDb.count_day;
            }

            var nowtime = Utils.time();
            if (nowtime > signInfo.bonus_time)
            {
                var bonus_time = nowtime + 60 * 60 * 24;
                var bonus_day = signInfo.bonus_day;
                var count_day = signInfo.count_day;

                if (bonus_day > 6)
                {
                    bonus_day = 0;
                }
                bonus_day++;
                count_day++;
                if (count_day > 7)
                {
                    count_day = 1;
                }
                bonus_day = count_day;

                if (isadd == 1)
                {
                    CmfUserSign infonew = new CmfUserSign();
                    infonew.Uid = uid;
                    infonew.BonusDay = bonus_day;
                    infonew.BonusTime = bonus_time;
                    infonew.CountDay = count_day;

                    context.CmfUserSigns.Add(infonew);
                }
                else
                {
                    CmfUserSign obj = await context.CmfUserSigns.Where(x => x.Uid == uid).FirstOrDefaultAsync() ?? new CmfUserSign();
                    obj.BonusTime = bonus_time;
                    obj.CountDay = count_day;
                    obj.BonusDay = bonus_day;
                    context.SaveChanges();
                }
                int? coin=null;
                foreach(var v in bonus_coin)
                {
                    if(v.day == bonus_day)
                    {
                        coin = v.coin;
                    }
                }
                if(coin != null)
                {
                    CmfUser1 user = await context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefaultAsync()?? new CmfUser1();
                    user.Coin = user.Coin+ (ulong)coin;

                    CmfUserCoinrecord obj = new CmfUserCoinrecord();
                    obj.Type = 1;
                    obj.Action = 3;
                    obj.Uid = uid;
                    obj.Touid = uid;
                    obj.Giftcount = 0;
                    obj.Totalcoin = coin??0;
                    obj.Showid = 0;
                    obj.Addtime = nowtime;
                    context.CmfUserCoinrecords.Add(obj);
                    await context.SaveChangesAsync();

                }
                rs = 1;

            }
            return rs;
        }

        #region getClassLive
        public  async Task<List<GetHotModel>> getClassLive(string? lan,ulong liveclassid,int p)
        {
            if(p < 1)
            {
                p = 1;
            }

            var pnum = 50;
            var lives = context.CmfLives.Where(x=> x.Islive ==1 && x.Liveclassid== liveclassid).Take(pnum).ToList();
            if(p != 1)
            {
                var endtime = cacheManager.GetCacheString("getClassLive_starttime");
                if (!String.IsNullOrEmpty(endtime))
                {
                    lives= lives.Where(x=> x.Starttime < long.Parse(endtime)).ToList();
                }
            }
            lives = lives.OrderByDescending(x => x.Starttime).ToList();
            List<GetHotModel> getHots = new List<GetHotModel>();
            foreach(var item in lives)
            {
                GetHotModel hot = new GetHotModel();

                hot.uid = item.Uid;
                hot.title = item.Title;
                hot.city = item.City;
                hot.stream = item.Stream;
                hot.pull = item.Pull;
                hot.thumb = item.Thumb;
                hot.isvideo = item.Isvideo;
                hot.type = item.Type;
                hot.type_val = item.TypeVal;
                hot.goodnum = item.Goodnum;
                hot.anyway = item.Anyway;
                hot.starttime = item.Starttime;
                hot.isshop = item.Isshop;
                hot.game_action = item.GameAction;
                hot.hotvotes = item.Hotvotes;
                //hot = await HomeService.handleLive(lan, hot);

                getHots.Add(hot);
            }
            if(getHots.Count > 0)
            {
                var last = getHots.LastOrDefault();
                cacheManager.SetCacheString("getClassLive_starttime",JsonConvert.SerializeObject(last.starttime));
            }
            return getHots;
        }

        #endregion

        #region getSlide
        public static List<getSlideModel> getSlide()
        {
            var rs = context.CmfSlideItems.Where(x => x.Status == 1 && x.SlideId == 2).OrderBy(x => x.ListOrder).Select(x => new
            {
                slide_pic = x.Image,
                slide_url = x.Url
            }).ToList();
            List<getSlideModel> lstrs = new List<getSlideModel>();
            foreach (var slide in rs)
            {
                getSlideModel obj = new getSlideModel();
                obj.slide_pic = Utils.get_upload_path(slide.slide_pic);
                obj.slide_url= slide.slide_url;
                lstrs.Add(obj);
            }
            return lstrs;
        }
        #endregion
        #region getHot
        public static async Task<List<GetHotModel>> getHot(string? lan ,int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var pnum = 50;
            var start = (p - 1) * pnum;
            var rs = context.CmfLives.Where(x => x.Islive == 1 && x.Ishot == true ).Take(pnum);
            ulong endtime = 0;

            if (p == 1)
            {
                cacheManager.SetCacheString("hot_starttime",JsonConvert.SerializeObject(Utils.time()));
            }
            else
            {
                if(!String.IsNullOrEmpty(cacheManager.GetCacheString("hot_hotvotes")))
                {
                    var hotvotes = long.Parse(cacheManager.GetCacheString("hot_hotvotes"));
                    rs = rs.Where(x => x.Hotvotes <hotvotes);
                }
                else
                {
                    rs = rs.Where(x => x.Hotvotes < 0);
                }
            }
            if (p != 0)
            {
           
                if (!String.IsNullOrEmpty(cacheManager.GetCacheString("hot_starttime")))
                {
                    endtime = ulong.Parse(cacheManager.GetCacheString("hot_starttime"));
                    rs = rs.Where(x => x.Starttime < (long)endtime);
                }
            }

            var results = rs.OrderByDescending(x => x.Hotvotes).ThenByDescending(x => x.Starttime).ThenByDescending(x => x.Isrecommend).ToList();
            List<GetHotModel> getHots = new List<GetHotModel>();
            for (var i = 0; i < results.Count; i++)
            {
                GetHotModel hot = new GetHotModel();
                var item  = results[i];
               
                hot.uid = item.Uid;
                hot.title = item.Title;
                hot.city = item.City;
                hot.stream = item.Stream;
                hot.pull = item.Pull;
                hot.thumb = item.Thumb;
                hot.isvideo = item.Isvideo;
                hot.type = item.Type;
                hot.type_val = item.TypeVal;
                hot.goodnum = item.Goodnum;
                hot.anyway= item.Anyway;
                hot.starttime= item.Starttime;
                hot.isshop= item.Isshop;
                hot.game_action= item.GameAction;
                hot.hotvotes = item.Hotvotes;

                //hot = await HomeService.handleLive(lan, hot);

                getHots.Add(hot);
            }
            if(getHots.Count > 0)
            {
                var last = getHots.LastOrDefault();
                cacheManager.SetCacheString("hot_hotvotes", JsonConvert.SerializeObject(last.hotvotes));
            }
            
            var js = JsonConvert.SerializeObject(getHots);
            return getHots;
        }
        #endregion
        #region GetFollow
        //public static InfoGetFollow getFollow(string lan, ulong uid, int p)
        //{
        //    InfoGetFollow rs = new InfoGetFollow();
        //    switch (lan)
        //    {
        //        case "Nam":
        //            rs.title = "Idol bạn theo dõi chưa live";
        //            rs.des = "Xem Idol khác";
        //            rs.list = new List<CmfLive>();
        //            break;
        //        case "En":
        //            rs.title = "The idol you followed is not live now";
        //            rs.des = "Go watch other idols";
        //            rs.list = new List<CmfLive>();
        //            break;
        //        case "Zh":
        //            rs.title = "你关注的主播没有开播";
        //            rs.des = "赶快去看看其他主播的直播吧";
        //            rs.list = new List<CmfLive>();
        //            break;
        //    }
        //    if (p < 1)
        //    {
        //        p = 1;
        //    }
        //    var pnum = 50;
        //    var start = (p - 1) * pnum;

        //    var touid = context.CmfUserAttentions.Where(x => x.Uid == uid).ToList();

        //    if (touid == null)
        //    {
        //        return rs;
        //    }
        //    int endtime = -1;
        //    if (p != 1)
        //    {
        //        endtime = int.Parse(cacheManager.GetCacheString("follow_starttime"));
        //        if (endtime != -1)
        //        {
        //            start = 0;

        //        }
        //    }

        //    int[] touids = new int[touid.Count];
        //    int i = 0;
        //    foreach (var item in touid)
        //    {
        //        touids[i] = item.Touid;
        //        i++;
        //    }

        //    var touidss = string.Join(",", touids);
        //    List<CmfLive> result = new List<CmfLive>();
        //    if (endtime != -1)
        //    {
        //        result = context.CmfLives.Where(x => x.Islive == 1 && x.Starttime < endtime && touidss.Contains(x.Uid.ToString())).ToList();
        //    }
        //    else
        //    {
        //        result = context.CmfLives.Where(x => x.Islive == 1 && touidss.Contains(x.Uid.ToString())).Take(pnum).ToList();
        //    }

        //    for(var count = 0;count <result.Count;count++)
        //    {
        //        var item = result[count];
        //         item = handleLive(lan, item);
        //    }

        //    if(result.Count > 0)
        //    {
        //        var last = result.LastOrDefault();
        //        if(last != null)
        //        cacheManager.SetCacheString("follow_starttime", JsonConvert.SerializeObject(last.Starttime));
        //    }
        //    rs.list = result.ToList();

        //    return rs;
        //}

        public static async Task<CmfLive?> handleLive(string? lan,CmfLive v)
        {
            var configpri = await _commonService.getConfigPri();
            HandleLiveModel rs = new HandleLiveModel();
            var num =cacheManager.ZCard("user_" + v.Stream);
            v.Goodnum = num.ToString();
            var userinfo = await getUserInfo(lan, v.Uid);
            //v.avatar = Utils.get_upload_path(userinfo.avatar);
            //v.A= Utils.get_upload_path(userinfo.avatar_thumb);
             //= userinfo.user_nicename;
            //v.sex = userinfo.sex;
            //v.= userinfo.level;
            //rs.level_anchor = userinfo.level_anchor;

            if(v.Thumb == null || v.Thumb == "")
            {
                v.Thumb = userinfo.avatar;

            }if(v.Isvideo == false && configpri.cdn_switch != 5)
            {
                v.Pull = await PrivateKeyA("rtmp", v.Stream, 0);
            }
            if(v.Type == 1)
            {
                v.TypeVal= "";
            }
            //rs.game = getGame(v.GameAction);
            return v;
        } 
        public static string getGame(int action)
        {
            List<ParamModel> gameaction = new List<ParamModel>();
            gameaction.Add(new ParamModel() { Key = "0", Value = "" });
            gameaction.Add(new ParamModel() { Key = "1", Value = "智勇三张" });
            gameaction.Add(new ParamModel() { Key = "2", Value = "海盗船长" });
            gameaction.Add(new ParamModel() { Key = "3", Value = "转盘" });
            gameaction.Add(new ParamModel() { Key = "4", Value = "开心牛仔" });
            gameaction.Add(new ParamModel() { Key = "5", Value = "二八贝" });

            var rs = gameaction.Where(x => x.Key == action.ToString()).FirstOrDefault();
            if(rs == null)
            {
                return "";
            }
            else
            {
                return rs.Value;
            }
        }
        public static async Task<string> PrivateKeyA(string host, string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var cdn_switch = configpri.cdn_switch;
            string url = "";
            switch (cdn_switch)
            {
                case "1":
                    url = await PrivateKey_ali(host, stream, type);
                    break;
                case "2":
                    url = await PrivateKey_tx(host, stream, type);
                    break ;
                case "3":
                    url  = await PrivateKey_qn(host, stream, type); //chưa hoàn thiện
                    break;
                case "4":
                    url = await PrivateKey_ws(host, stream, type);
                    break;
                case "5":
                    url= await PrivateKey_wy(host, stream, type);
                    break;
                case "6":
                    url = await PrivateKey_ady(host, stream, type);
                    break;

            }
            return url;
        }
        public static async Task<string> PrivateKey_ady(string host,string stream,int type)
        {
            string url = "";
            var configpri = await _commonService.getConfigPri();
            var stream_a = stream.Split(".");
            string streamKey = stream_a[0];
            var ext = stream_a[1];
            var domain = "";
            var filename = "";
            if(type == 1)
            {
                domain = host + "://" + configpri.ady_push;
                filename = "/" + configpri.ady_apn + "/" + stream;
                url = domain + filename;

            }
            else
            {
                if(ext == "m3u8")
                {
                    domain = host + "://" + configpri.ady_hls_pull;
                    filename = "/" + configpri.ady_apn + "/" + stream;
                    url = domain +filename;
                }
                else
                {
                    domain = host + "://" + configpri.ady_pull;
                    filename = "/" + configpri.ady_apn + "/" + stream;
                    url= domain + filename;
                }
            }

            return url;
        }
        public static async Task<string> PrivateKey_wy(string host,string stream, int type)
        {
            string rs = "";
            string url = "";
            string paramarr ="";
            var configpri = await _commonService.getConfigPri();
            var appkey = configpri.wy_appkey;
            var appSecret = configpri.wy_appsecret;
            var nonce = Utils.rand(1000, 9999);
            var curTime = Utils.time();
            var checkSum = Utils.sha1(appSecret + nonce + curTime);
            var header = new string[] {
            "Content-Type:application/json;charset=utf-8",
            "AppKey:"+appkey,
            "Nonce:"+nonce,
            "CurTime"+curTime,
            "CheckSum"+checkSum
            };
            if(type == 1)
            {
                url = "https://vcloud.163.com/app/channel/create";
                paramarr = "name=" + stream + "& type=" + 0;
                
            }
            else
            {
                url = "https://vcloud.163.com/app/address";
                paramarr = "cid=" + stream; 
                //paramarr.Add(new ParamModel() { Key = "cid", Value = stream });
            }
            //var paramarrjson = JsonConvert.SerializeObject(paramarr);

            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(paramarr);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentLength = byte1.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            WebResponse response = request.GetResponse();
            newStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(newStream);
            
            sr.Close();
            newStream.Close();
            rs = JsonConvert.SerializeObject(response.ResponseUri);
            return rs;
        }
        public static async Task<string> PrivateKey_ws(string host, string stream,int type)
        {
            var configpri = await _commonService.getConfigPri();
            var domain = "";
            if (type == 1)
            {
                domain = host + "://" + configpri.ws_push;

            }else
            {
                domain = host + "://" + configpri.ws_pull;
            }
            var filename = "/" + configpri.ws_apn + "/" + stream;

           var url = domain + filename;
            return url;
        }
        public static async Task<string> PrivateKey_qn(string host,string stream,int type)
        {
            var configpri = await _commonService.getConfigPri();
            var ak = configpri.qn_ak;
            var sk = configpri.qn_sk;
            var hubName = configpri.qn_hname;
            var push = configpri.qn_push;
            var pull = configpri.qn_pull;
            var stream_a = stream.Split(".");
            var streamKey = stream_a[0];
            var ext = stream_a[1];
            var url = "";
            if(type == 1)
            {
                var time = Utils.time() + 60 * 60 * 10;
                
            }
            return url;
        }
        public static async Task<string> PrivateKey_tx(string host,string stream, int type)
        {
            string url = "";
            var configpri  = await _commonService.getConfigPri();
            var bizid = configpri.tx_bizid;
            var push_url_key = configpri.tx_push_key;
            var play_url_key = configpri.tx_play_key;
            var push = configpri.tx_push;
            var pull = configpri.tx_pull;
            var stream_a = stream.Split(".");
            var streamKey = stream_a[0];
            var ext = stream_a[1];

            var live_code = streamKey;
            var now = Utils.time();
            var now_time = now + 3 * 60 * 60;
            var txTime = Utils.DecimalToHex(now_time);

            var txSecret = Utils.MD5Hash(push_url_key + live_code + txTime);
            var safe_url = "?txSecret=" + txSecret + "&txTime=" + txTime;

            var play_safe_url = "";

            if (configpri.tx_play_key_switch != null || configpri.tx_play_key_switch != "")
            {
                var play_auth_time = now + (int)configpri.tx_play_time;
                var txPlayTime = Utils.DecimalToHex(play_auth_time);
                var txPlaySecret = Utils.MD5Hash(play_url_key + live_code + txPlayTime);
                play_safe_url = "?txSecret=" + txPlaySecret + "&txTime=" + txPlayTime;
            }

            if(type == 1)
            {
                url = "rtmp://" + push + "/live/" + live_code + safe_url;
            }
            else
            {
                url = "http://" + pull + "/live/" + live_code + ".flv" + play_safe_url;
            }

            return url;
        }
        public static async Task<string> PrivateKey_ali(string host,string stream,int type)
        {
            var configpri = await _commonService.getConfigPri();

            var push  = configpri.push_url;
            var pull = configpri.pull_url;
            var key_push = configpri.auth_key_push;
            var length_push = configpri.auth_length_push;
            var key_pull = configpri.auth_key_pull;
            var length_pull = configpri.auth_length_pull;
            string domain = "";
            long time;
            string auth_key = "";
            string url = "";
            if (type == 1)
            {
                domain = host + "://" + push;
                time = Utils.time() + (long)length_push;
            }
            else
            {
                domain = host + "://" + pull;
                time = Utils.time() + (long)length_pull;
            }
            var filename = "/5showcam/"+ stream;
            if(type == 1)
            {
                if(key_push != "")
                {
                    var sstring = filename + "-" + time + "-0-0-" + key_push;
                    var md5 = Utils.MD5Hash(sstring);
                    auth_key = "auth_key="+ time + "-0-0-"+ md5;
                }
                if(auth_key!= null || !String.IsNullOrEmpty(auth_key)|| !String.IsNullOrWhiteSpace(auth_key) )
                {
                    auth_key = "?" + auth_key;
                }
                url = domain + filename + auth_key;
            }
            else
            {
                if(key_pull != "")
                {
                    var sstring = filename + "-"+time+ "-0-0-" + key_pull;
                    var md5 = Utils.MD5Hash(sstring);
                    auth_key = "auth_key=" + time + "-0-0-" + md5;
                }
                if (auth_key != null || !String.IsNullOrEmpty(auth_key) || !String.IsNullOrWhiteSpace(auth_key)){
                    auth_key = "?" + auth_key;
                }
                url= domain + filename + auth_key;
            }
            return url;

        }
        public static async Task<UserInfo> getUserInfo(string? lan, ulong uid, int type = 0)
        {
            UserInfo info = new UserInfo();
            if (uid == 0)
            {
                if (uid == 0)//code base is string "goodsorder_admin"
                {
                    var configpub = _commonService.getConfigPub();
                    info.user_nicename = "订单消息";
                    if (lan == "En")
                    {
                        info.user_nicename = "Order message";
                    }
                    else if (lan == "Nam")
                    {
                        info.user_nicename = "Thông tin đơn hàng";

                    }
                    info.avatar = Utils.get_upload_path("/orderMsg.png");
                    info.avatar_thumb = Utils.get_upload_path("/orderMsg.png");
                    info.id = 0;
                }
                info.coin = 0;
                info.sex = 1;
                info.signature = "";
                info.province = "";
                info.city = "";
                info.birthday = "";
                info.issuper = 0;
                info.votestotal = 0;
                info.consumption = 0;
                info.location = "";
                info.user_status = 1;

            }
            else
            {
                var user = cacheManager.GetCacheString("userinfos_" + uid);
                if (user == null)
                {
                    var rs = context.CmfUsers1.Where(x => x.Id == uid && x.UserType == 2).Select(x => new
                    {
                        id = x.Id,
                        user_nicename = x.UserNicename,
                        avatar = x.Avatar,
                        avatar_thumb = x.AvatarThumb,
                        sex = x.Sex,
                        signature = x.Signature,
                        consumption = x.Consumption,
                        votestotal = x.Votestotal,
                        province = x.Province,
                        city = x.City,
                        birthday = x.Birthday,
                        user_status = x.UserStatus,
                        issuper = x.Issuper,
                        location = x.Location

                    }).FirstOrDefault();
                    if (rs != null)
                    {
                        info.id = uid;
                        info.user_nicename = rs.user_nicename;
                        info.avatar = rs.avatar;
                        info.avatar_thumb = rs.avatar_thumb;
                        info.sex = rs.sex;
                        info.signature = rs.signature;
                        info.consumption = rs.consumption;
                        info.votestotal = rs.votestotal;
                        info.province = rs.province;
                        info.city = rs.city;
                        var birthday = rs.birthday ?? 0;
                        info.birthday = Utils.UnixTimeToDateTime(birthday).ToString("yyyy-MM-dd");
                        info.user_status = rs.user_status;
                        info.issuper = rs.issuper?1:0;
                        info.location = rs.location;

                        cacheManager.SetCacheString("userinfo_" + uid, JsonConvert.SerializeObject(info));
                    }
                    if(type == 1)
                    {
                        return info;
                    }
                    if(rs == null)
                    {
                        info.id = uid;
                        info.user_nicename = "用户不存在";
                        info.avatar = "/default.jpg";
                        info.avatar_thumb = "/default_thumb.jpg";
                        info.sex = 0;
                        info.signature = "";
                        info.consumption=0;
                        info.votestotal =0;
                        info.province = "";
                        info.city = "";
                        info.birthday = "";
                        info.issuper=0;
                    }
                }
                else
                {
                    info = JsonConvert.DeserializeObject<UserInfo>(user) ?? new UserInfo();
                    info.level = await _commonService.getLevel(info.consumption);
                    info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
                    info.avatar = Utils.get_upload_path(info.avatar);
                    info.avatar_thumb = Utils.get_upload_path(info.avatar_thumb);
                    info.vip = await _commonService.getUserVip(uid);
                    info.liang = await _commonService.getUserLiang(uid);
                    if(info.birthday == "" || info.birthday == "0")
                    {
                        info.birthday = "";
                    }
                }
            }
            return info;
        }

        #endregion
        #region UpUserPush
        public static int upUserPush(ulong uid, string pushid)
        {
            var userpushed = context.CmfUserPushids.Where(x => x.Uid == uid).FirstOrDefault();
            if (userpushed == null)
            {
                context.CmfUserPushids.Add(userpushed);
                context.SaveChanges();
            }
            else if (userpushed.Pushid != pushid)
            {
                userpushed.Pushid = pushid;
                context.CmfUserPushids.Update(userpushed);
                context.SaveChanges();
            }
            return 1;
        }
        #endregion
        #region Bonus

        public static async Task<ResultBaseInfo> Bonus(ulong uid, string token)
        {
            var checktoke = CheckToken(uid, token);
            ResultBaseInfo dataBonus = new ResultBaseInfo();
            if (checktoke == 0)
            {
                dataBonus.info = new List<InfoBonus>();
                var rs = await LoginBonus(uid);
                if (rs == null)
                {
                    dataBonus.code = 1001;
                    dataBonus.msg = "领取失败";
                    return dataBonus;
                }
                dataBonus.info.Add(rs);
                return dataBonus;
            }
            dataBonus.msg = "Is valid token";
            dataBonus.code = 1001;
            return dataBonus;

        }
        public static int CheckToken(ulong uid, string token)
        {
            if (uid == null || token == null)
            {
                cacheManager.DeleteCache("uid");
                cacheManager.DeleteCache("token");
                cacheManager.DeleteCache("user");
                return 700;
            }
            var key = "token_" + uid;
            dynamic userinfo = cacheManager.GetCacheString(key);

            if (userinfo == null || userinfo.Trim() == "")
            {
                var usertoken = context.CmfUserTokens.Where(x => x.UserId == uid).Select(x => new
                {
                    token = x.Token,
                    expire_time = x.ExpireTime
                }).FirstOrDefault();
                if (usertoken != null)
                {
                    cacheManager.SetCacheString(key, JsonConvert.SerializeObject(userinfo));
                }
                else
                {
                    cacheManager.DeleteCache(key);
                }
            }
            long unixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            userinfo = JsonConvert.DeserializeObject<dynamic>(userinfo);
            if (userinfo == null || userinfo.token != token || userinfo.expire_time < unixTime)
            {
                cacheManager.DeleteCache("uid");
                cacheManager.DeleteCache("token");
                cacheManager.DeleteCache("user");
                return 700;
            }
            else
            {
                return 0;
            }
        }
        public static async Task<InfoBonus> LoginBonus(ulong uid)
        {
            InfoBonus rs = new InfoBonus();
            var configpri = await _commonService.getConfigPri();
            if (configpri.bonus_switch == null)
            {
                return rs;
            }
            rs.bonus_switch = configpri.bonus_switch;
            var key = "loginbonus";

            var list = cacheManager.GetCacheString(key);
            List<BonusList> bonus = new List<BonusList>();
            if (list == null || list.Trim() == "")
            {
                var dayCoins = context.CmfLoginbonus.ToList();

                foreach (var day in dayCoins)
                {
                    BonusList obj = new BonusList();
                    obj.day = day.Day;
                    obj.coin = day.Coin;
                    bonus.Add(obj);
                }
                if (bonus.Count > 0)
                {
                    cacheManager.SetCacheString(key, JsonConvert.SerializeObject(bonus));
                }
            }
            else
            {
                bonus = JsonConvert.DeserializeObject<List<BonusList>>(list) ?? new List<BonusList>();
            }
            rs.bonus_list = bonus;

            var bonus_coin = new List<dynamic>();

            //foreach(var b in bonus)
            //{
            //    var obj = new Object();
            //    obj. = b.coin;
            //}
            //UserSigns signinfo = new UserSigns();
            var signinfodb = context.CmfUserSigns.Where(x => x.Uid == uid).Select(x => new
            {
                bonus_day = x.BonusDay,
                bonus_time = x.BonusTime,
                count_day = x.CountDay
            }).FirstOrDefault();

            if (signinfodb == null)
            {
                rs.bonus_day = 0;
                rs.bonus_time = 0;
                rs.count_day = 0;
            }
            else
            {
                rs.bonus_day = signinfodb.bonus_day;
                rs.bonus_time = (int)signinfodb.bonus_time;
                rs.count_day = signinfodb.count_day;
            }

            if (signinfodb.count_day >= 7)
            {
                rs.count_day = 0;
            }

            var nowtime = ((DateTimeOffset)(DateTime.Now)).ToUnixTimeSeconds();

            if (nowtime > signinfodb.bonus_time)
            {
                rs.bonus_day = rs.count_day;
                if (rs.bonus_day == 0)
                {
                    rs.bonus_day += 1;
                }
            }
            else
            {
                rs.bonus_day = 0;
            }

            return rs;
        }
        #endregion
    }
}
