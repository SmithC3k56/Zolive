using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Text;
using zolive_api.Models;
using zolive_api.Models.Home;
using zolive_api.Models.User;
using zolive_api.Models.Video;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Home
{
    public class HomeService : IHomeService
    {

        private readonly newliveContext context;
        private readonly ICommonService _commonService;
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly Random rnd = new Random();
        public HomeService(newliveContext context, ICommonService commonService)
        {
            this.context = context;
            this._commonService = commonService;
        }

        public async Task<IList<ProfitModel>> consumeList(string lan, bool is_resh, ulong uid, string type, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var pnum = 50;
            var start = (p - 1) * pnum;

            var caches_key = "comlist" + type + p;
            var dataCache = cacheManager.GetCacheString(caches_key);
            IList<ProfitModel> dataResult = new List<ProfitModel>();
            long dayStart = 0;
            long dayEnd = 0;
            profitListResultModel[] rslt = { };
            if (dataCache == null & !is_resh)
            //if (true)
            {

                switch (type)
                {
                    case "day":
                        var day = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day);
                        dayStart = Utils.DateTimeToLong(day);
                        dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));

                        rslt = await context.CmfUserCoinrecords.Where(x => (x.Type == 0 && x.Action == 1 || x.Action == 2) && x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => (long)x.Totalcoin),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                        .OrderByDescending(x => x.totalcoin)
                        .ToArrayAsync();


                        break;
                    case "week":
                        var w = Utils.GetWeekNumberOfMonth(DateTime.Now);
                        var first = 1;
                        w = w > 1 ? w - first : 6;
                        var date = DateTime.Now.ToString("yyyyMMdd");
                        var week_start_Value = int.Parse(date) - w;
                        var week_start_dt = DateTime.ParseExact(s: week_start_Value.ToString(), format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("vi-VN"));

                        var week_end_dt = week_start_dt.AddDays(7);

                        var week_start = Utils.DateTimeToLong(week_start_dt);
                        var week_end = Utils.DateTimeToLong(week_end_dt);

                        rslt = await context.CmfUserCoinrecords.Where(x => (x.Type == 0 && x.Action == 1 || x.Action == 2) && x.Addtime >= week_start && x.Addtime <= week_end).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => (long)x.Totalcoin),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                                .OrderByDescending(x => x.totalcoin)
                                .ToArrayAsync();
                        break;

                    case "month":
                        var month = DateTime.ParseExact(s: (DateTime.Now.ToString("yyyyMM") + "01"), format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("vi-VN"));
                        var month_start = Utils.DateTimeToLong(month);
                        var month_end = Utils.DateTimeToLong(month.AddMonths(1)) - 1;
                        rslt = await context.CmfUserCoinrecords.Where(x => (x.Type == 0 && x.Action == 1 || x.Action == 2) && x.Addtime >= month_start && x.Addtime <= month_end).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => (long)x.Totalcoin),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                                .OrderByDescending(x => x.totalcoin)
                                .ToArrayAsync();

                        break;
                    case "total":
                        rslt = await context.CmfUserCoinrecords.Where(x => x.Type == 0 && x.Action == 1 || x.Action == 2).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => (long)x.Totalcoin),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                            .OrderByDescending(x => x.totalcoin)
                            .ToArrayAsync();

                        break;
                    default:
                        dayStart = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day));
                        dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));
                        rslt = await context.CmfUserCoinrecords.Where(x => x.Type == 0 && x.Action == 1 || x.Action == 2 && x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => (long)x.Totalcoin),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                                .OrderByDescending(x => x.totalcoin)
                                .ToArrayAsync();

                        break;
                }

                foreach (var v in rslt)
                {

                    var userinfo =  getUserInfo(lan, v.uid).Result;
                    if (userinfo != null)
                    {
                        dataResult.Add(new ProfitModel()
                        {
                            uid = v.uid,
                            avatar = userinfo.avatar,
                            avatar_thumb = userinfo.avatar_thumb,
                            user_nicename = userinfo.user_nicename,
                            sex = userinfo.sex,
                            level = userinfo.level,
                            level_anchor = userinfo.level_anchor,
                            totalcoin = (int)v.totalcoin,

                        });

                    }
                }

                var time = new TimeSpan(hours: 0, minutes: 10, seconds: 0);
                await cacheManager.SetCacheStrings(caches_key, JsonConvert.SerializeObject(dataResult), time);
            }
            else
            {
                dataResult = JsonConvert.DeserializeObject<IList<ProfitModel>>(dataCache ?? "")?? new List<ProfitModel>();
            }
            foreach (var v in dataResult)
            {
                v.isAttention =  _commonService.isAttention(uid, v.uid).Result;
            }
            return dataResult;
        }
        public async Task<IList<ProfitModel>> profitList(string lan, bool is_resh, ulong uid, string type, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var pnum = 50;
            var start = (p - 1) * pnum;

            var caches_key = "prolist" + type + p;
            var dataCache = cacheManager.GetCacheString(caches_key);
            IList<ProfitModel> dataResult = new List<ProfitModel>();
            long dayStart = 0;
            long dayEnd = 0;
            IList<profitListResultModel> rslt = new List<profitListResultModel>();
             if (dataCache == null & !is_resh)
            //if (true)
            {
                //var result = await context.CmfUserVoterecords.Where(x => x.Action == 1 || x.Action == 2).ToListAsync();
                switch (type)
                {
                    case "day":
                        var day = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day);
                        dayStart = Utils.DateTimeToLong(day);
                        dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));

                        rslt =await context.CmfUserVoterecords.Where(x => ( x.Action == 1 || x.Action == 2)&& x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => x.Total),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                        .OrderByDescending(x => x.totalcoin)
                        .ToListAsync();


                        break;
                    case "week":
                        var w = Utils.GetWeekNumberOfMonth(DateTime.Now);
                        var first = 1;
                        w = w > 1 ? w - first : 6;
                        var date = DateTime.Now.ToString("yyyyMMdd");
                        var week_start_Value = int.Parse(date) - w;
                        var week_start_dt = DateTime.ParseExact(s: week_start_Value.ToString(), format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("vi-VN"));

                        var week_end_dt = week_start_dt.AddDays(7);

                        var week_start = Utils.DateTimeToLong(week_start_dt);
                        var week_end = Utils.DateTimeToLong(week_end_dt);

                        rslt = await context.CmfUserVoterecords.Where(x => (x.Action == 1 || x.Action == 2) && x.Addtime >= week_start && x.Addtime <= week_end).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => x.Total),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                                .OrderByDescending(x => x.totalcoin)
                                .ToListAsync();
                        break;

                    case "month":
                        var month = DateTime.ParseExact(s: (DateTime.Now.ToString("yyyyMM") + "01"), format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("vi-VN"));
                        var month_start = Utils.DateTimeToLong(month);
                        var month_end = Utils.DateTimeToLong(month.AddMonths(1)) - 1;
                        rslt = await context.CmfUserVoterecords.Where(x => (x.Action == 1 || x.Action == 2) && x.Addtime >= month_start && x.Addtime <= month_end).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => x.Total),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                                .OrderByDescending(x => x.totalcoin)
                                .ToListAsync();

                        break;
                    case "total":
                        rslt = await context.CmfUserVoterecords.Where(x => x.Action == 1 || x.Action == 2).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => x.Total),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                            .OrderByDescending(x => x.totalcoin)
                            .ToListAsync();

                        break;
                    default:
                        dayStart = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day));
                        dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));
                        rslt = await context.CmfUserVoterecords.Where(x => ( x.Action == 1 || x.Action == 2) && x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new profitListResultModel
                        {
                            totalcoin = g.Sum(x => x.Total),
                            uid = g.Key
                        }).Skip(start).Take(pnum)
                                .OrderByDescending(x => x.totalcoin)
                                .ToListAsync();
                        break;
                }
                foreach (var v in rslt)
                {

                    var userinfo = getUserInfo(lan, v.uid).Result;
                    if (userinfo != null)
                    {
                        ProfitModel obj = new ProfitModel()
                        {
                            uid = v.uid,
                            avatar = userinfo.avatar,
                            avatar_thumb = userinfo.avatar_thumb,
                            user_nicename = userinfo.user_nicename,
                            sex = userinfo.sex,
                            level = userinfo.level,
                            level_anchor = userinfo.level_anchor,
                            totalcoin = (int)v.totalcoin
                        };
                        dataResult.Add(obj);

                    }
                }
                var time = new TimeSpan(hours: 0, minutes: 10, seconds: 0);
                await cacheManager.SetCacheStrings(caches_key, JsonConvert.SerializeObject(dataResult), time);
            }
            else
            {
                dataResult = JsonConvert.DeserializeObject<IList<ProfitModel>>(dataCache ?? "") ?? new List<ProfitModel>();
            }
            //dataResult.ForEach(async x => );
            foreach (var x in dataResult)
            {
                x.isAttention = _commonService.isAttention(uid, x.uid).Result;
            }
            return dataResult;
        }
        public async Task<List<SearchModel>> search(ulong uid, string key, int p)
        {
            if (p < 1) p = 1;

            var pnum = 50;
            var start = (p - 1) * pnum;
            var result = await context.CmfUsers1.Where(x => x.UserType == 2 && (x.Id.ToString().Equals(key) || x.UserNicename.Contains(key) || x.Goodnum.Contains(key)) && x.Id != uid).Skip(start).Take(pnum).OrderByDescending(x => x.Id).Select(x => new
            {
                Id = x.Id,
                user_nicename = x.UserNicename,
                avatar = x.Avatar,
                sex = x.Sex,
                signature = x.Signature,
                consumption = x.Consumption,
                votestotal = x.Votestotal
            }).ToListAsync();
            if (p != 1)
            {
                var id = cacheManager.GetCacheString("search");

                if (id != null)
                {
                    result = result.Where(x => x.Id < ulong.Parse(id.ToString())).ToList();
                }
            }
            List<SearchModel> results = new List<SearchModel>();
            foreach (var item in result)
            {
                var obj = new SearchModel();
                obj.level = await _commonService.getLevel(item.consumption);
                obj.level_anchor = await _commonService.getLevelAnchor(item.votestotal);
                obj.isattention = await _commonService.isAttention(uid, item.Id);

                obj.avatar = item.avatar.Contains("https") ? item.avatar : "http://zolive.m99.club" + item.avatar;
                results.Add(obj);
            }
            if (result.Count > 0)
            {
                var last = result.LastOrDefault();
                if (last != null)
                    await cacheManager.SetCacheString("search", last.Id.ToString());
            }
            return results;

        }
        public async Task<List<GetHotModel>> getClassLive(string? lan, ulong liveclassid, int p)
        {
            if (p < 1)
            {
                p = 1;
            }

            var pnum = 50;
            var lives = context.CmfLives.Where(x => x.Islive == 1 && x.Liveclassid == liveclassid).Take(pnum).ToList();
            if (p != 1)
            {
                var endtime = cacheManager.GetCacheString("getClassLive_starttime");
                if (!String.IsNullOrEmpty(endtime))
                {
                    lives = lives.Where(x => (ulong)x.Starttime < ulong.Parse(endtime)).ToList();
                }
            }
            lives = lives.OrderByDescending(x => x.Starttime).ToList();
            List<GetHotModel> getHots = new List<GetHotModel>();
            foreach (var item in lives)
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
                hot = await this.handleLive(lan, hot);

                getHots.Add(hot);
            }
            if (getHots.Count > 0)
            {
                var last = getHots.LastOrDefault();
                var time = new TimeSpan(hours: 0, minutes: 10, seconds: 0);
                await cacheManager.SetCacheStrings("getClassLive_starttime", JsonConvert.SerializeObject(last.starttime), time);
            }
            return getHots;
        }
        public async Task<List<GetHotModel>> getHot(string? lan, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var pnum = 50;
            var start = (p - 1) * pnum;
            var rs = context.CmfLives.Where(x => x.Islive == 1 && x.Ishot == true).Take(pnum);
            ulong endtime = 0;

            if (p == 1)
            {
                await cacheManager.SetCacheString("hot_starttime", JsonConvert.SerializeObject(Utils.time()));
            }
            else
            {
                if (!String.IsNullOrEmpty(cacheManager.GetCacheString("hot_hotvotes")))
                {
                    var hotvotes = long.Parse(cacheManager.GetCacheString("hot_hotvotes"));
                    rs = rs.Where(x => x.Hotvotes < hotvotes);
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
                var item = results[i];

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

                hot = await this.handleLive(lan, hot);

                getHots.Add(hot);
            }
            if (getHots.Count > 0)
            {
                var last = getHots.LastOrDefault();
                await cacheManager.SetCacheString("hot_hotvotes", JsonConvert.SerializeObject(last.hotvotes));
            }
            return getHots;
        }
        public async Task<IList<getSlideModel>> getSlide()
        {
            var rs = await context.CmfSlideItems.Where(x => x.Status == 1 && x.SlideId == 2).OrderBy(x => x.ListOrder).Select(x => new getSlideModel
            {
                slide_pic = x.Image,
                slide_url = x.Url
            }).ToListAsync();

            return rs;
        }
        public async Task<GetHotModel> handleLive(string? lan, GetHotModel v)
        {
            var configpri = await _commonService.getConfigPri();

            var num = await cacheManager.ZCard("user_" + v.stream);
            v.nums = num;
            var userinfo = await getUserInfo(lan, v.uid);
            v.avatar = userinfo.avatar;
            v.avatar_thumb = userinfo.avatar_thumb;
            v.user_nicename = userinfo.user_nicename;
            v.sex = userinfo.sex;
            v.level = userinfo.level;
            v.level_anchor = userinfo.level_anchor;

            if (v.thumb == null || v.thumb == "")
            {
                v.thumb = userinfo.avatar;

            }
            if (v.isvideo == false && configpri.cdn_switch != 5)
            {
                v.pull = await _commonService.PrivateKeyA("rtmp", v.stream, 0);
            }
            if (v.type == 1)
            {
                v.type_val = "";
            }
            v.game = getGame(v.game_action);
            return v;
        }
        public string getGame(int action)
        {
            List<ParamModel> gameaction = new List<ParamModel>();
            gameaction.Add(new ParamModel() { Key = "0", Value = "" });
            gameaction.Add(new ParamModel() { Key = "1", Value = "智勇三张" });
            gameaction.Add(new ParamModel() { Key = "2", Value = "海盗船长" });
            gameaction.Add(new ParamModel() { Key = "3", Value = "转盘" });
            gameaction.Add(new ParamModel() { Key = "4", Value = "开心牛仔" });
            gameaction.Add(new ParamModel() { Key = "5", Value = "二八贝" });

            var rs = gameaction.Where(x => x.Key == action.ToString()).FirstOrDefault();
            if (rs == null)
            {
                return "";
            }
            else
            {
                return rs.Value;
            }
        }
        // public async Task<string> PrivateKeyA(string host, string stream, int type)
        // {
        //     var configpri = await _commonService.getConfigPri();
        //     var cdn_switch = configpri.cdn_switch;
        //     string url = "";
        //     switch (cdn_switch)
        //     {
        //         case "1":
        //             url = await PrivateKey_ali(host, stream, type);
        //             break;
        //         case "2":
        //             url = await PrivateKey_tx(host, stream, type);
        //             break;
        //         case "3":
        //             url = await PrivateKey_qn(host, stream, type); //chưa hoàn thiện
        //             break;
        //         case "4":
        //             url = await PrivateKey_ws(host, stream, type);
        //             break;
        //         case "5":
        //             url = await PrivateKey_wy(host, stream, type);
        //             break;
        //         case "6":
        //             url = await PrivateKey_ady(host, stream, type);
        //             break;

        //     }
        //     return url;
        // }
        // public async Task<string> PrivateKey_ady(string host, string stream, int type)
        // {
        //     string url = "";
        //     var configpri = await _commonService.getConfigPri();
        //     var stream_a = stream.Split(".");
        //     string streamKey = stream_a[0];
        //     var ext = stream_a[1];
        //     var domain = "";
        //     var filename = "";
        //     if (type == 1)
        //     {
        //         domain = host + "://" + configpri.ady_push;
        //         filename = "/" + configpri.ady_apn + "/" + stream;
        //         url = domain + filename;

        //     }
        //     else
        //     {
        //         if (ext == "m3u8")
        //         {
        //             domain = host + "://" + configpri.ady_hls_pull;
        //             filename = "/" + configpri.ady_apn + "/" + stream;
        //             url = domain + filename;
        //         }
        //         else
        //         {
        //             domain = host + "://" + configpri.ady_pull;
        //             filename = "/" + configpri.ady_apn + "/" + stream;
        //             url = domain + filename;
        //         }
        //     }

        //     return url;
        // }
        // public async Task<string> PrivateKey_wy(string host, string stream, int type)
        // {
        //     string rs = "";
        //     string url = "";
        //     string paramarr = "";
        //     var configpri = await _commonService.getConfigPri();
        //     var appkey = configpri.wy_appkey;
        //     var appSecret = configpri.wy_appsecret;
        //     var nonce = Utils.rand(1000, 9999);
        //     var curTime = Utils.time();
        //     var checkSum = Utils.sha1(appSecret + nonce + curTime);
        //     var header = new string[] {
        //     "Content-Type:application/json;charset=utf-8",
        //     "AppKey:"+appkey,
        //     "Nonce:"+nonce,
        //     "CurTime"+curTime,
        //     "CheckSum"+checkSum
        //     };
        //     if (type == 1)
        //     {
        //         url = "https://vcloud.163.com/app/channel/create";
        //         paramarr = "name=" + stream + "& type=" + 0;

        //     }
        //     else
        //     {
        //         url = "https://vcloud.163.com/app/address";
        //         paramarr = "cid=" + stream;
        //         //paramarr.Add(new ParamModel() { Key = "cid", Value = stream });
        //     }
        //     //var paramarrjson = JsonConvert.SerializeObject(paramarr);

        //     ASCIIEncoding encoding = new ASCIIEncoding();
        //     byte[] byte1 = encoding.GetBytes(paramarr);
        //     HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //     request.ContentLength = byte1.Length;
        //     request.ContentType = "application/x-www-form-urlencoded";
        //     request.Method = "POST";

        //     Stream newStream = request.GetRequestStream();
        //     newStream.Write(byte1, 0, byte1.Length);
        //     newStream.Close();

        //     WebResponse response = request.GetResponse();
        //     newStream = response.GetResponseStream();
        //     StreamReader sr = new StreamReader(newStream);

        //     sr.Close();
        //     newStream.Close();
        //     rs = JsonConvert.SerializeObject(response.ResponseUri);
        //     return rs;
        // }
        // public async Task<string> PrivateKey_ws(string host, string stream, int type)
        // {
        //     var configpri = await _commonService.getConfigPri();
        //     var domain = "";
        //     if (type == 1)
        //     {
        //         domain = host + "://" + configpri.ws_push;

        //     }
        //     else
        //     {
        //         domain = host + "://" + configpri.ws_pull;
        //     }
        //     var filename = "/" + configpri.ws_apn + "/" + stream;

        //     var url = domain + filename;
        //     return url;
        // }
        // public async Task<string> PrivateKey_qn(string host, string stream, int type)
        // {
        //     var configpri = await _commonService.getConfigPri();
        //     var ak = configpri.qn_ak;
        //     var sk = configpri.qn_sk;
        //     var hubName = configpri.qn_hname;
        //     var push = configpri.qn_push;
        //     var pull = configpri.qn_pull;
        //     var stream_a = stream.Split(".");
        //     var streamKey = stream_a[0];
        //     var ext = stream_a[1];
        //     var url = "";
        //     if (type == 1)
        //     {
        //         var time = Utils.time() + 60 * 60 * 10;

        //     }
        //     return url;
        // }
        // public async Task<string> PrivateKey_tx(string host, string stream, int type)
        // {
        //     string url = "";
        //     var configpri = await _commonService.getConfigPri();
        //     var bizid = configpri.tx_bizid;
        //     var push_url_key = configpri.tx_push_key;
        //     var play_url_key = configpri.tx_play_key;
        //     var push = configpri.tx_push;
        //     var pull = configpri.tx_pull;
        //     var stream_a = stream.Split(".");
        //     var streamKey = stream_a[0];
        //     var ext = stream_a[1];

        //     var live_code = streamKey;
        //     var now = Utils.time();
        //     var now_time = now + 3 * 60 * 60;
        //     var txTime = Utils.DecimalToHex(now_time);

        //     var txSecret = Utils.MD5Hash(push_url_key + live_code + txTime);
        //     var safe_url = "?txSecret=" + txSecret + "&txTime=" + txTime;

        //     var play_safe_url = "";

        //     if (configpri.tx_play_key_switch != null || configpri.tx_play_key_switch != "")
        //     {
        //         var play_auth_time = now + (int)configpri.tx_play_time;
        //         var txPlayTime = Utils.DecimalToHex(play_auth_time);
        //         var txPlaySecret = Utils.MD5Hash(play_url_key + live_code + txPlayTime);
        //         play_safe_url = "?txSecret=" + txPlaySecret + "&txTime=" + txPlayTime;
        //     }

        //     if (type == 1)
        //     {
        //         url = "rtmp://" + push + "/live/" + live_code + safe_url;
        //     }
        //     else
        //     {
        //         url = "http://" + pull + "/live/" + live_code + ".flv" + play_safe_url;
        //     }

        //     return url;
        // }
        // public async Task<string> PrivateKey_ali(string host, string stream, int type)
        // {
        //     var configpri = await _commonService.getConfigPri();

        //     var push = configpri.push_url;
        //     var pull = configpri.pull_url;
        //     var key_push = configpri.auth_key_push;
        //     var length_push = configpri.auth_length_push;
        //     var key_pull = configpri.auth_key_pull;
        //     var length_pull = configpri.auth_length_pull;
        //     string domain = "";
        //     long time;
        //     string auth_key = "";
        //     string url = "";
        //     if (type == 1)
        //     {
        //         domain = host + "://" + push;
        //         time = Utils.time() + (long)length_push;
        //     }
        //     else
        //     {
        //         domain = host + "://" + pull;
        //         time = Utils.time() + (long)length_pull;
        //     }
        //     var filename = "/5showcam/" + stream;
        //     if (type == 1)
        //     {
        //         if (key_push != "")
        //         {
        //             var sstring = filename + "-" + time + "-0-0-" + key_push;
        //             var md5 = Utils.MD5Hash(sstring);
        //             auth_key = "auth_key=" + time + "-0-0-" + md5;
        //         }
        //         if (auth_key != null || !String.IsNullOrEmpty(auth_key) || !String.IsNullOrWhiteSpace(auth_key))
        //         {
        //             auth_key = "?" + auth_key;
        //         }
        //         url = domain + filename + auth_key;
        //     }
        //     else
        //     {
        //         if (key_pull != "")
        //         {
        //             var sstring = filename + "-" + time + "-0-0-" + key_pull;
        //             var md5 = Utils.MD5Hash(sstring);
        //             auth_key = "auth_key=" + time + "-0-0-" + md5;
        //         }
        //         if (auth_key != null || !String.IsNullOrEmpty(auth_key) || !String.IsNullOrWhiteSpace(auth_key))
        //         {
        //             auth_key = "?" + auth_key;
        //         }
        //         url = domain + filename + auth_key;
        //     }
        //     return url;

        // }


        public async Task<UserInfo> getUserInfo(string? lan, ulong uid, int type = 0)
        {
            var info = new UserInfo();
            if (uid == 0)
            {
                info = new UserInfo()
                {
                    coin = 0,
                    sex = 1,
                    signature = "",
                    province = "",
                    city = "",
                    birthday = "",
                    issuper = 0,
                    votestotal = 0,
                    consumption = 0,
                    location = "",
                    user_status = 1,
                };
                if (uid == 0)//code base is string "goodsorder_admin"
                {

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


            }
            else
            {
                var user = cacheManager.GetCacheString("userinfos_" + uid);
                if (user == null)
                {
                    info = await context.CmfUsers1.Where(x => x.Id == uid && x.UserType == 2).Select(x => new UserInfo
                    {
                        id = uid,
                        user_nicename = x.UserNicename,
                        avatar = x.Avatar.Contains("https") ? x.Avatar : Utils.get_upload_path(x.Avatar),
                        avatar_thumb = x.AvatarThumb.Contains("https") ? x.AvatarThumb : Utils.get_upload_path(x.AvatarThumb),
                        sex = x.Sex,
                        signature = x.Signature,
                        consumption = x.Consumption,
                        votestotal = x.Votestotal,
                        province = x.Province,
                        city = x.City,
                        birthday = x.Birthday == 0 ? "0" : Utils.UnixTimeToDateTime(x.Birthday ?? 0).ToString("yyyy-MM-dd"),
                        user_status = x.UserStatus,
                        issuper = x.Issuper ? 1 : 0,
                        location = x.Location,
                    }).FirstOrDefaultAsync();

                    if (type == 1)
                    {
                        return new UserInfo();
                    }
                    if (info == null)
                    {
                        info = new UserInfo()
                        {
                            id = uid,
                            user_nicename = "用户不存在",
                            avatar = "/default.jpg",
                            avatar_thumb = "/default_thumb.jpg",
                            sex = 0,
                            signature = "",
                            consumption = 0,
                            votestotal = 0,
                            province = "",
                            city = "",
                            birthday = "",
                            issuper = 0
                        };

                    }
                    else
                    {
                        info.level = _commonService.getLevel(info.consumption).Result;
                        info.level_anchor = _commonService.getLevelAnchor(info.votestotal).Result;
                        info.vip = _commonService.getUserVip(uid).Result;
                        info.liang = _commonService.getUserLiang(uid).Result;
                        info.birthday = info.birthday == "0" ? "" : info.birthday;
                        await cacheManager.SetCacheString("userinfo_" + uid, JsonConvert.SerializeObject(info));
                    }

                }
                else
                {
                    info = JsonConvert.DeserializeObject<UserInfo>(user) ?? new UserInfo();
                    info.level = _commonService.getLevel(info.consumption).Result;
                    info.level_anchor = _commonService.getLevelAnchor(info.votestotal).Result;
                    info.vip = _commonService.getUserVip(uid).Result;
                    info.liang = await _commonService.getUserLiang(uid);
                    if (info.birthday == "" || info.birthday == "0")
                    {
                        info.birthday = "";
                    }
                }
            }
            //   info.follows = info.follows ?? "0";
            //   info.fans = info.fans ??"0";
            //   info.sign = "";
            //   info.contribute = new List<ContributeModel>();
            //   info.liverecord = new List<LiveRecordModel>();
            //   info.guardlist = new List<UserInfo2>();
            //   info.shop = new getShopModel();
            //   info.label = new List<CmfLabel>();
            //   info.videolist = new List<VideoModel>();
            return info;
        }


    }
}
