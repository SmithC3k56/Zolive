using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using zolive_api.Models.Paidprogram;
using zolive_api.Models.User;
using zolive_api.Models.Video;
using zolive_api.Services.Interface;
using zolive_api.Services.Video;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.User
{
    public class TestUser
    {
        public IConfiguration InitConfiguration()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
        public static readonly newliveContext context = new newliveContext();
        public static readonly CacheManager cacheManager = new CacheManager();
        public VideoService videoService;
        public ICommonService _commonService;
        public static readonly IRedis redis;
        public static Random rnd = new Random();

        [SetUp]
        public void Setup()
        {
            var config = InitConfiguration();
            ConfigNew.Configuration = config;
        }

        [Test]
        public async Task TestMainAsync()
        {
            //await getUserHome("En", 45231, 45231);
            //await getGuardList("En",83833);
            //await getMyLabel("En", 45231);
            //await getHomeVideo("En", 45231, 45231,1);
            //await getShop("En", 45231);
            //await sensitiveField("ksksksk");
            // await getMyLabel("En", 45231);
            // await setShopCash(45231, 99, 50000);
            //await getProfit("En",45231);
            await getPerSetting();
        }
        public async Task<List<GetPerSettingModel>> getPerSetting(){
            var list = await context.CmfPortalPosts.Where(x => x.Type ==2).OrderByDescending(x=> x.ListOrder).Select(x=>new {
                id = x.Id,
                post_title = x.PostTitle
            }).ToListAsync();
            List<GetPerSettingModel> results = new List<GetPerSettingModel>();
            foreach (var v in list){
                GetPerSettingModel obj = new GetPerSettingModel();
                obj.id = 0;
                obj.name = v.post_title;
                obj.thumb ="";
                obj.href = "http://zolive.m99.club/portal/page/index?id="+v.id;
                results.Add(obj);
            }
            return results;
        }
        #region getProfit
        public async Task<getProfitModel> getProfit(string lan, ulong uid)
        {

            var info = await context.CmfUsers1.Where(x => x.Id == uid).Select(x => new
            {
                votes = x.Votes,
                votestotal = x.Votestotal
            }).FirstOrDefaultAsync();
            var rs = new getProfitModel();
            if (info != null)
            {
                var config = await _commonService.getConfigPri();
                var cash_rate = decimal.Parse(config.cash_rate.Value);
                var cash_start = config.cash_start;
                var cash_end = config.cash_end;
                var cash_max_times = config.cash_max_times;

                var votes = info.votes;
                var total = Math.Floor(votes / cash_rate);
                var tips = "";
                if (cash_max_times != null)
                {
                     tips = "每月" + cash_start.Value + "-" + cash_end.Value + "号可进行提现申请，每月只可提现" + cash_max_times.Value + "次";
                    if (lan == "En") tips = "Please withdraw between " + cash_start.Value + "-" + cash_end.Value + " of every month, and " + cash_max_times.Value + "times at most. ";
                    if (lan == "Nam") tips = "Hàng tháng " + cash_start.Value + "-" + cash_end.Value + " có thể rút tiền, và tối đa " + cash_max_times.Value + " lần. ";
                }
                else
                {
                     tips = "每月" + cash_start.Value + "-" + cash_end.Value + "号可进行提现申请";
                    if (lan == "En") tips = "Please withdrawl within" + cash_start.Value + "-" + cash_end.Value + ".";
                    if (lan == "Nam") tips = "Hàng tháng " + cash_start.Value + "-" + cash_end.Value + " có thể rút tiền.";
                }
                rs = new getProfitModel()
                {
                    votes = info.votes,
                    votestotal = info.votestotal,
                    total = total,
                    cash_rate = cash_rate,
                    tips = tips

                };

            }
            return rs;

        }
        #endregion

        #region setShopCash
        public async Task<int> setShopCash(ulong uid, int accountId, ulong money)
        {

            var configpri = await _commonService.getConfigPri();
            var balance_cash_start = int.Parse(configpri.balance_cash_start.Value);
            var balance_cash_end = int.Parse(configpri.balance_cash_end.Value);
            var balance_cash_max_times = int.Parse(configpri.balance_cash_max_times.Value);

            var day = DateTime.Now.Day;
            if (day < balance_cash_start || day > balance_cash_end)
            {
                return 1005;
            }

            var month_end = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month + 1, day: 1));
            var month_start = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: 1));
            if (balance_cash_max_times != 0)
            {
                var count = await context.CmfUserBalanceRecords.Where(x => x.Uid == (long)uid && x.Addtime > month_start && x.Addtime < month_end).CountAsync();
                if (count >= balance_cash_max_times)
                {
                    return 1006;
                }
            }
            var accountinfo = await context.CmfCashAccounts.Where(x => x.Id == accountId && x.Uid == uid).FirstOrDefaultAsync();
            if (accountinfo == null)
            {
                return 1007;
            }
            var balance_cash_min = ulong.Parse(configpri.balance_cash_min.Value);
            if (money < balance_cash_min)
            {
                return 1004;
            }
            var ifok = await context.CmfUsers1.Where(x => x.Id == uid && x.Balance >= money).FirstOrDefaultAsync();
            if (ifok == null)
            {
                return 1001;
            }
            var data = new CmfUserBalanceCashrecord()
            {
                Addtime = Utils.DateTimeToLong(DateTime.Now),
                Uid = uid,
                Money = money,
                Status = false,
                Type = accountinfo.Type,
                Orderno = uid + "_" + Utils.DateTimeToLong(DateTime.Now) + Utils.rand(100, 999),
                AccountBank = accountinfo.AccountBank,
                Account = accountinfo.Account,
                Name = accountinfo.Name,
            };

            try
            {
                await context.CmfUserBalanceCashrecords.AddAsync(data);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return 1002;
            }
            return 0;
        }

        #endregion

        #region updateFields
        public async Task MainUpdateFields(string lan, ulong uid, string token, string fields)
        {
            var m = "Sửa thành công";
            if (lan == "En") m = "Modified successfully";

        }
        #endregion
        #region getLabel

        public async Task<List<LabelInfoModel>> getMyLabel(string lan, ulong uid)
        {
            string[] label = new string[0];
            var list = await context.CmfLabelUsers.Where(x => x.Touid == uid).ToListAsync();

            List<LabelInfoModel> rs = new List<LabelInfoModel>();
            foreach (var item in list)
            {
                var v_a = Regex.Split(item.Label, ",|，");
                v_a = v_a.Where(x => !String.IsNullOrEmpty(x)).ToArray();

                if (v_a.Length > 0) label = v_a;
            }

            if (label == null) return rs;

            var label_nums = label.GroupBy(x => x).ToDictionary(g => uint.Parse(g.Key), g => g.Count());
            var label_key = label_nums.Select(x => x.Key).ToArray();
            var labels = await getImpressionLabel(lan);
            List<int> order_nums = new List<int>();
            foreach (var v in labels)
            {
                LabelInfoModel obj = new LabelInfoModel();
                if (label_key.Contains(v.Id))
                {
                    foreach (var k in label_nums)
                    {
                        if (k.Key == v.Id)
                        {
                            obj.nums = k.Value;
                            order_nums.Add(obj.nums);
                        }
                    }
                    obj.Id = v.Id;
                    obj.NameEn = v.NameEn;
                    obj.Name = v.Name;
                    obj.NameNam = v.NameNam;
                    obj.Colour = v.Colour;
                    obj.Colour2 = v.Colour2;

                    rs.Add(obj);
                }
            }
            order_nums.Sort();
            rs = rs.OrderByDescending(x => x.Id).ToList();
            return rs;
        }
        #endregion
        #region uploadfield
        [Test]
        public async Task MainTest()
        {
            await userUpdate(45231, "%7B%22user_nicename%22%3A%22Smith%22%7D");
        }
        public async Task<bool> userUpdate(ulong uid, string fields)
        {
            try
            {
                await cacheManager.DeleteCache("userinfo_" + uid);
                if (fields == null) return false;
                var rs = await context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefaultAsync();
                if (rs == null) return false;

                var url = Utils.UrlDecode(fields);
                var json_decode_field = JsonConvert.DeserializeObject<dynamic>(url) ?? new List<dynamic>();
                foreach (var field in json_decode_field)
                {
                    switch (field.Name)
                    {
                        case "user_nicename":
                            rs.UserNicename = field.Value.Value;
                            break;
                        case "sex":
                            rs.Sex = field.Value.Value;
                            break;
                        case "signature":
                            rs.Signature = field.Value.Value;
                            break;
                        case "birthday":
                            rs.Birthday = field.Value.Value;
                            break;
                        case "location":
                            rs.Location = field.Value.Value;
                            break;
                        case "city":
                            rs.City = field.Value.Value;
                            break;
                        default:
                            break;
                    }
                    context.Update(rs);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<sbyte> checkName(ulong uid, string name)
        {
            var isexit = await context.CmfUsers1.Where(x => x.Id != uid && x.UserNicename == name).Select(x => x.Id).FirstOrDefaultAsync();
            if (isexit == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> sensitiveField(string field)
        {
            if (!string.IsNullOrEmpty(field))
            {
                var configpri = await _commonService.getConfigPri();
                var sensitive_words = configpri.sensitive_words;
                var sensitive = sensitive_words.Value.Split(",");

                foreach (var v in sensitive)
                {
                    if (v != "")
                    {
                        if (field.Contains(v))
                        {
                            return 1001;
                        }
                    }
                }
            }
            return 1;
        }
        #endregion
        #region getShop
        public async Task<getShopModel> getShop(string lan, ulong uid)
        {
            var key = "shop" + uid.ToString();
            getShopModel shopInfo = new getShopModel();
            var shop_info = cacheManager.GetCacheString(key);
            if (String.IsNullOrEmpty(shop_info))
            {

                var rs = await context.CmfShopApplies.Where(x => x.Uid == uid).FirstOrDefaultAsync();

                if (rs != null)
                {
                    shopInfo.uid = rs.Uid;
                    shopInfo.sale_nums = rs.SaleNums.ToString();
                    shopInfo.quality_points = rs.QualityPoints.ToString();
                    shopInfo.service_points = rs.ServicePoints.ToString();
                    shopInfo.certificate = rs.Certificate;
                    shopInfo.other = rs.Other;
                    shopInfo.service_phone = rs.ServicePhone;
                    shopInfo.province = rs.Province;
                    shopInfo.city = rs.City;
                    shopInfo.area = rs.Area;
                    await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(shopInfo));
                }
                else
                {
                    return shopInfo;
                }

            }
            else
            {
                shopInfo = JsonConvert.DeserializeObject<getShopModel>(shop_info) ?? new getShopModel();
            }

            var userinfo = await getUserInfo(lan, uid);
            shopInfo.user_nicename = userinfo.user_nicename;
            shopInfo.name = "Cửa hàng của " + userinfo.user_nicename;
            if (lan == "En")
            {
                shopInfo.name = userinfo.user_nicename + "'s Shop";
            }
            if (shopInfo.certificate != null) shopInfo.certificate = Utils.get_upload_path(shopInfo.certificate);

            if (shopInfo.other != null) shopInfo.other = Utils.get_upload_path(shopInfo.other);

            shopInfo.sale_nums = Utils.NumberFormat(lan, long.Parse(shopInfo.sale_nums));
            shopInfo.avatar = Utils.get_upload_path(userinfo.avatar);
            shopInfo.composite_points = (float.Parse(shopInfo.quality_points) + float.Parse(shopInfo.service_points) + (long.Parse(shopInfo.express_points) / 3)).ToString("D1");
            shopInfo.composite_points = shopInfo.composite_points == "0" ? "0.0" : shopInfo.composite_points;
            var m = "Chưa ghi điểm";
            if (lan == "En") m = "No score yet";

            shopInfo.quality_points = float.Parse(shopInfo.quality_points) > 0 ? shopInfo.quality_points : m;
            shopInfo.service_points = float.Parse(shopInfo.service_points) > 0 ? shopInfo.service_points : m;
            shopInfo.express_points = long.Parse(shopInfo.express_points) > 0 ? shopInfo.express_points : m;

            var count = await countGoods(uid, 1);
            shopInfo.goods_nums = count;
            shopInfo.address_format = shopInfo.city + " " + shopInfo.area;
            shopInfo.certificate_desc = "";
            return shopInfo;

        }
        public async Task<int> countGoods(ulong uid, int status)
        {
            var nums = await context.CmfShopGoods.Where(x => x.Uid == uid && x.Status == status).CountAsync();
            return nums;
        }
        #endregion
        #region getHomeVideo
        public async Task<List<VideoModel>> getHomeVideo(string lan, ulong uid, ulong touid, int p)
        {
            if (p < 1) p = 1;
            var nums = 21;
            var start = (p - 1) * nums;
            List<CmfVideo> video = new List<CmfVideo>();
            if (uid == touid)
            {
                video = await context.CmfVideos.Where(x => x.Uid == uid && x.Isdel == false && x.Status == true && x.IsAd == false).OrderByDescending(x => x.Addtime).Skip(start).Take(nums).ToListAsync();
            }
            else
            {
                var videoids_s = await getVideoBlack(uid);
                video = await context.CmfVideos.Where(x => !videoids_s.Contains(x.Id) && x.Uid == touid && x.Isdel == false && x.Status == true && x.IsAd == false).OrderByDescending(x => x.Addtime).Skip(start).Take(nums).ToListAsync();
            }
            List<VideoModel> videolist = new List<VideoModel>();
            foreach (var v in video)
            {
                VideoModel obj = new VideoModel();
                obj.id = v.Id;
                obj.uid = v.Uid;
                obj.title = v.Title;
                obj.thumb = v.Thumb;
                obj.thumb_s = v.ThumbS;
                obj.href = v.Href;
                obj.href_w = v.HrefW;
                obj.likes = v.Likes.ToString();
                obj.views = v.Views;
                obj.comments = v.Comments.ToString();
                obj.steps = v.Steps.ToString();
                obj.shares = v.Shares;
                obj.addtime = v.Addtime.ToString();
                obj.lat = v.Lat;
                obj.lng = v.Lng;
                obj.city = v.City;
                obj.music_id = v.MusicId;
                obj.is_ad = v.IsAd;
                obj.ad_url = v.AdUrl;
                obj.type = v.Type;
                obj.goodsid = v.Goodsid;
                obj.classid = v.Classid;
                obj.ad_endtime = v.AdEndtime;

                obj = await videoService.handleVideo(lan, uid, obj);
                videolist.Add(obj);
            }
            return videolist;
        }
        #endregion
        #region getMyLabel


        public async Task<List<CmfLabel>> getImpressionLabel(string lan)
        {
            var key = "getImpressionLabel" + Utils.time();
            var list = cacheManager.GetCacheString(key);
            List<CmfLabel> rs = new List<CmfLabel>();
            if (list == null)
            {
                rs = await context.CmfLabels.OrderBy(x => x.ListOrder).ThenByDescending(x => x.Id).ToListAsync();
                if (rs != null || rs.Count > 0)
                {
                    await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(rs));
                }
            }
            else
            {
                rs = JsonConvert.DeserializeObject<List<CmfLabel>>(list ?? "") ?? new List<CmfLabel>();
            }

            foreach (var item in rs)
            {
                if (lan == "Nam") item.Name = item.NameNam;
                if (lan == "En") item.Name = item.NameEn;
            }

            return rs;
        }
        #endregion
        #region getGuardList

        public async Task<List<UserInfo2>> getGuardList(string lan, ulong touid)
        {
            var liveuid = touid;
            var nowtime = Utils.time();
            var w = Utils.GetWeekNumberOfMonth(DateTime.Now);
            var first = 1;
            var week_start = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: (DateTime.Now.Day - (w != 0 ? (w - first) : 6))));
            var week = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: (DateTime.Now.Day - (w != 0 ? (w - first) : 6)) + 7, hour: 0, minute: 0, second: 0);
            var week_end = Utils.DateTimeToLong(week);
            var list = await context.CmfGuardUsers.Where(x => x.Liveuid == liveuid && x.Endtime > nowtime).Select(x => new
            {
                uid = x.Uid,
                type = x.Type
            }).ToListAsync();

            List<int> order = new List<int>();
            List<int> order2 = new List<int>();
            List<UserInfo2> rs = new List<UserInfo2>();

            foreach (var v in list)
            {
                var userinfo = await getUserInfo2(lan, v.uid);

                userinfo.type = v.type;
                userinfo.contribute = await getWeekContribute(v.uid, week_start, week_end);
                order.Add(userinfo.contribute);
                order2.Add(userinfo.type);
                rs.Add(userinfo);
            }
            order.Sort();
            order2.Sort();
            rs.Sort();

            return rs;
        }

        public async Task<int> getWeekContribute(ulong uid, long starttime = 0, long endtime = 0)
        {
            var contribute = 0;
            List<int> actionList = new List<int>() { 1, 10 };
            if (uid > 0)
            {
                if (starttime > 0)
                {
                    contribute = await context.CmfUserCoinrecords.Where(x => actionList.Contains(x.Action) && x.Uid == uid && x.Addtime > starttime).SumAsync(x => x.Totalcoin);
                }
                if (endtime > 0)
                {
                    contribute = await context.CmfUserCoinrecords.Where(x => actionList.Contains(x.Action) && x.Uid == uid && x.Addtime > endtime).SumAsync(x => x.Totalcoin);
                }
                if (endtime <= 0 && starttime <= 0)
                {
                    contribute = await context.CmfUserCoinrecords.Where(x => actionList.Contains(x.Action) && x.Uid == uid).SumAsync(x => x.Totalcoin);
                }

            }
            return contribute;
        }

        #endregion
        public async Task getUserHome(string lan, ulong uid, ulong touid)
        {
            var info = await getUserInfo(lan, touid);
            if (info == null) return;

            info.follows = (await _commonService.getFollows(touid)).ToString();
            info.fans = (await _commonService.getFans(touid)).ToString();
            info.isattention = (await _commonService.isAttention(uid, touid)).ToString();
            info.isblack = await _commonService.isBlack(uid, touid);
            info.isblack2 = await _commonService.isBlack(touid, uid);

            var islive = 0;
            var isexist = await context.CmfLives.Where(x => x.Uid == touid && x.Islive == 1).FirstOrDefaultAsync();
            if (isexist != null) islive = 1;
            info.islive = islive;
            List<int> arr = new List<int>() { 1, 2 };
            var rs = await context.CmfUserVoterecords.Where(x => arr.Contains(x.Action) && x.Uid == touid).Take(3).GroupBy(x => x.Fromid).Select(g => new
            {
                uid = g.Key,
                total = g.Sum(x => x.Total)
            }
            ).OrderByDescending(x => x.total).ToListAsync();
            List<ContributeModel> rss = new List<ContributeModel>();
            for (var x = 0; x < rs.Count; x++)
            {
                ContributeModel obj = new ContributeModel();
                var recordss = rs[x];
                var userinfo = await getUserInfo(lan, (ulong)recordss.uid);
                obj.uid = (ulong)recordss.uid;
                obj.total = recordss.total;
                obj.avatar = userinfo.avatar;
                obj.user_nicename = userinfo.user_nicename;
                rss.Add(obj);
            }

            info.contribute = rss;
            int videonums = 0;
            if (uid == touid)
            {
                videonums = await context.CmfVideos.Where(x => x.Uid == uid && x.Isdel == false && x.Status == true && x.IsAd == false).CountAsync();
            }
            else
            {
                var videoids_s = await getVideoBlack(uid);
                videonums = await context.CmfVideos.Where(x => !videoids_s.Contains(x.Id) && x.Uid == touid && x.Isdel == false && x.Status == true && x.IsAd == false).CountAsync();
            }

            info.videonums = videonums;
            int dynamicnums = 0;
            if (uid == touid)
            {
                dynamicnums = await context.CmfDynamics.Where(x => x.Uid == uid && x.Isdel == false && x.Status == true).CountAsync();
            }
            else
            {
                dynamicnums = await context.CmfDynamics.Where(x => x.Uid == touid && x.Isdel == false && x.Status == true).CountAsync();
            }

            info.dynamicnums = dynamicnums;
            var livenums = await context.CmfLiveRecords.Where(x => x.Uid == touid).CountAsync();

            info.livenums = livenums;
            var record = await context.CmfLiveRecords.Select(x => new
            {
                id = x.Id,
                uid = x.Uid,
                nums = x.Nums,
                starttime = x.Starttime,
                endtime = x.Endtime,
                title = x.Title,
                city = x.City
            }).Where(x => x.uid == touid).OrderByDescending(x => x.id).Take(50).ToListAsync();
            List<LiveRecordModel> liveRecordModels = new List<LiveRecordModel>();
            for (int i = 0; i < record.Count; i++)
            {
                LiveRecordModel obj = new LiveRecordModel();
                obj.datestarttime = Utils.UnixTimeToDateTime(record[i].starttime).ToString("yyyy.MM.dd");
                obj.dateendtime = Utils.UnixTimeToDateTime(record[i].endtime).ToString("yyyy.MM.dd");
                var cha = (decimal)(record[i].endtime - record[i].starttime);
                obj.lenth = Utils.getSeconds(cha);
                liveRecordModels.Add(obj);
            }
            info.liverecord = liveRecordModels;
            var json = JsonConvert.SerializeObject(info);
            //return info;
        }
        public async Task<List<ulong>> getVideoBlack(ulong uid)
        {

            var list = await context.CmfVideoBlacks.Where(x => x.Uid == uid).Select(x => x.Videoid).ToListAsync();
            if (list == null) list = new List<ulong>();
            return list;
        }
        public async Task<UserInfo2> getUserInfo2(string? lan, ulong uid, int type = 0)
        {
            UserInfo2 info = new UserInfo2();
            if (uid == 0)
            {
                if (uid == 0)//code base is string "goodsorder_admin"
                {
                    var configpub = await _commonService.getConfigPub();
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
                info.issuper = false;
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
                    var rs = await context.CmfUsers1.Where(x => x.Id == uid && x.UserType == 2).FirstOrDefaultAsync();
                    if (rs != null)
                    {
                        info.id = uid;
                        info.user_nicename = rs.UserNicename;
                        info.avatar = rs.Avatar;
                        info.avatar_thumb = rs.AvatarThumb;
                        info.sex = rs.Sex;
                        info.signature = rs.Signature;
                        info.consumption = rs.Consumption;
                        info.votestotal = rs.Votestotal;
                        info.province = rs.Province;
                        info.city = rs.City;
                        var birthday = rs.Birthday ?? 0;
                        info.birthday = Utils.UnixTimeToDateTime(birthday).ToString("yyyy-MM-dd");
                        info.user_status = rs.UserStatus;
                        info.issuper = rs.Issuper;
                        info.location = rs.Location;

                        await cacheManager.SetCacheString("userinfo_" + uid, JsonConvert.SerializeObject(info));
                    }
                    if (type == 1)
                    {
                        return info;
                    }
                    if (rs == null)
                    {
                        info.id = uid;
                        info.user_nicename = "用户不存在";
                        info.avatar = "/default.jpg";
                        info.avatar_thumb = "/default_thumb.jpg";
                        info.sex = 0;
                        info.signature = "";
                        info.consumption = 0;
                        info.votestotal = 0;
                        info.province = "";
                        info.city = "";
                        info.birthday = "";
                        info.issuper = false;
                    }
                    else
                    {
                        info.level = await _commonService.getLevel(info.consumption);
                        info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
                        info.avatar = info.avatar;
                        info.avatar_thumb = info.avatar_thumb;
                        info.vip = await _commonService.getUserVip(uid);
                        info.liang = await _commonService.getUserLiang(uid);
                        if (info.birthday == "" || info.birthday == "0")
                        {
                            info.birthday = "";
                        }
                    }
                }
                else
                {
                    info = JsonConvert.DeserializeObject<UserInfo2>(user) ?? new UserInfo2();
                    info.level = await _commonService.getLevel(info.consumption);
                    info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
                    info.avatar = info.avatar;
                    info.avatar_thumb = info.avatar_thumb;
                    info.vip = await _commonService.getUserVip(uid);
                    info.liang = await _commonService.getUserLiang(uid);
                    if (info.birthday == "" || info.birthday == "0")
                    {
                        info.birthday = "";
                    }
                }
            }
            return info;
        }
        public async Task<UserInfo> getUserInfo(string? lan, ulong uid, int type = 0)
        {
            UserInfo info = new UserInfo();
            if (uid == 0)
            {
                if (uid == 0)//code base is string "goodsorder_admin"
                {
                    var configpub = await _commonService.getConfigPub();
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
                    var rs = await context.CmfUsers1.Where(x => x.Id == uid && x.UserType == 2).FirstOrDefaultAsync();
                    if (rs != null)
                    {
                        info.id = uid;
                        info.user_nicename = rs.UserNicename;
                        info.avatar = rs.Avatar;
                        info.avatar_thumb = rs.AvatarThumb;
                        info.sex = rs.Sex;
                        info.signature = rs.Signature;
                        info.consumption = rs.Consumption;
                        info.votestotal = rs.Votestotal;
                        info.province = rs.Province;
                        info.city = rs.City;
                        var birthday = rs.Birthday ?? 0;
                        info.birthday = Utils.UnixTimeToDateTime(birthday).ToString("yyyy-MM-dd");
                        info.user_status = rs.UserStatus;
                        info.issuper = rs.Issuper ? 1 : 0;
                        info.location = rs.Location;

                        await cacheManager.SetCacheString("userinfo_" + uid, JsonConvert.SerializeObject(info));
                    }
                    if (type == 1)
                    {
                        return info;
                    }
                    if (rs == null)
                    {
                        info.id = uid;
                        info.user_nicename = "用户不存在";
                        info.avatar = "/default.jpg";
                        info.avatar_thumb = "/default_thumb.jpg";
                        info.sex = 0;
                        info.signature = "";
                        info.consumption = 0;
                        info.votestotal = 0;
                        info.province = "";
                        info.city = "";
                        info.birthday = "";
                        info.issuper = 0;
                    }
                    else
                    {
                        info.level = await _commonService.getLevel(info.consumption);
                        info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
                        info.avatar = info.avatar;
                        info.avatar_thumb = info.avatar_thumb;
                        info.vip = await _commonService.getUserVip(uid);
                        info.liang = await _commonService.getUserLiang(uid);
                        if (info.birthday == "" || info.birthday == "0")
                        {
                            info.birthday = "";
                        }
                    }
                }
                else
                {
                    info = JsonConvert.DeserializeObject<UserInfo>(user) ?? new UserInfo();
                    info.level = await _commonService.getLevel(info.consumption);
                    info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
                    info.avatar = info.avatar;
                    info.avatar_thumb = info.avatar_thumb;
                    info.vip = await _commonService.getUserVip(uid);
                    info.liang = await _commonService.getUserLiang(uid);
                    if (info.birthday == "" || info.birthday == "0")
                    {
                        info.birthday = "";
                    }
                }
            }
            return info;
        }

    }
}
