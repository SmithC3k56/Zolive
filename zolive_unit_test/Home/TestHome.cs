using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_api.Models.Home;
using zolive_api.Models.User;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Home
{
  public class TestHome
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
    public static readonly IRedis redis;
    public static Random rnd = new Random();
        private static ICommonService _commonService;
    [SetUp]
    public void Setup()
    {
      var config = InitConfiguration();
      ConfigNew.Configuration = config;
    }

    [Test]
    public async Task TestMainAsync()
    {
      await search(45230, "Lena", 1);
    }

    public async Task<List<ProfitModel>?> consumeList(string lan, bool is_resh, ulong uid, string type, int p)
    {
      if (p < 1)
      {
        p = 1;
      }
      var pnum = 50;
      var start = (p - 1) * pnum;

      var caches_key = "comlist" + type + p;
      var dataCache = cacheManager.GetCacheString(caches_key);
      var dataResult = new List<ProfitModel>();
      long dayStart = 0;
      long dayEnd = 0;
      List<profitListResultModel> rslt = new List<profitListResultModel>();
      if (!is_resh)
      {
        var result = await context.CmfUserCoinrecords.Where(x => x.Action == 1 || x.Action == 2).Skip(start).Take(pnum).ToListAsync();
        switch (type)
        {
          case "day":
            var day = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day);
            dayStart = Utils.DateTimeToLong(day);
            dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));

            rslt = result.Where(x => x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new profitListResultModel
            {
              totalcoin = g.Sum(x => x.Totalcoin),
              uid = g.Key
            })
            .OrderByDescending(x => x.totalcoin)
            .ToList();

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

            rslt = result.Where(x => x.Addtime >= week_start && x.Addtime <= week_end).GroupBy(x => x.Uid).Select(g => new profitListResultModel
            {
              totalcoin = g.Sum(x => x.Totalcoin),
              uid = g.Key
            })
                    .OrderByDescending(x => x.totalcoin)
                    .ToList();
            break;

          case "month":
            var month = DateTime.ParseExact(s: (DateTime.Now.ToString("yyyyMM") + "01"), format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("vi-VN"));
            var month_start = Utils.DateTimeToLong(month);
            var month_end = Utils.DateTimeToLong(month.AddMonths(1)) - 1;
            rslt = result.Where(x => x.Addtime >= month_start && x.Addtime <= month_end).GroupBy(x => x.Uid).Select(g => new profitListResultModel
            {
              totalcoin = g.Sum(x => x.Totalcoin),
              uid = g.Key
            })
                    .OrderByDescending(x => x.totalcoin)
                    .ToList();

            break;
          case "total":
            rslt = result.GroupBy(x => x.Uid).Select(g => new profitListResultModel
            {
              totalcoin = g.Sum(x => x.Totalcoin),
              uid = g.Key
            })
                .OrderByDescending(x => x.totalcoin)
                .ToList();

            break;
          default:
            dayStart = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day));
            dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));
            rslt = result.Where(x => x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new profitListResultModel
            {
              totalcoin = g.Sum(x => x.Totalcoin),
              uid = g.Key
            })
                    .OrderByDescending(x => x.totalcoin)
                    .ToList();

            break;
        }

        foreach (var v in result)
        {
          var userinfo = await getUserInfo(lan, v.Uid);
          if (userinfo != null)
          {
            ProfitModel obj = new ProfitModel()
            {
              uid = v.Uid,
              avatar = userinfo.avatar,
              avatar_thumb = userinfo.avatar_thumb,
              user_nicename = userinfo.user_nicename,
              sex = userinfo.sex,
              level = userinfo.level,
              level_anchor = userinfo.level_anchor,
            };

           
            dataResult.Add(obj);
          }
        }
        await cacheManager.SetCacheString(caches_key, JsonConvert.SerializeObject(dataResult));
      }
      else
      {
        dataResult = JsonConvert.DeserializeObject<List<ProfitModel>>(dataCache??"")??new List<ProfitModel>();
      }
      foreach(var v in dataResult ){
         v.isAttention = await _commonService.isAttention(uid, v.uid);
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
        obj.avatar = item.avatar.Contains("https") ? item.avatar : "http://zolive.m99.club/" + item.avatar;
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


    [Test]
    public async Task TestProfitAsync()
    {
      await profitList("Nam", false, 45230, "total", 2);
    }
    public async Task<List<ProfitModel>> profitList(string lan, bool is_resh, ulong uid, string type, int p)
    {
      if (p < 1)
      {
        p = 1;
      }
      var pnum = 50;
      var start = (p - 1) * pnum;

      var caches_key = "prolist" + type + p;
      var dataCache = cacheManager.GetCacheString(caches_key);
      var dataResult = new List<ProfitModel>();
      long dayStart = 0;
      long dayEnd = 0;
      List<profitListResultModel> rslt = new List<profitListResultModel>();
      if (!is_resh)
      {
        var result = await context.CmfUserVoterecords.Where(x => x.Action == 1 || x.Action == 2).Skip(start).Take(pnum).ToListAsync();
        switch (type)
        {
          case "day":
            var day = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day);
            dayStart = Utils.DateTimeToLong(day);
            dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));

            var rs = result.Where(x => x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new
            {
              totalcoin = g.Sum(x => x.Total),
              uid = g.Key
            })
            .OrderByDescending(x => x.totalcoin)
            .ToList();
            foreach (var v in rs)
            {
              profitListResultModel obj = new profitListResultModel();
              obj.uid = v.uid;
              obj.totalcoin = v.totalcoin;
              rslt.Add(obj);
            }

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

            rs = result.Where(x => x.Addtime >= week_start && x.Addtime <= week_end).GroupBy(x => x.Uid).Select(g => new
            {
              totalcoin = g.Sum(x => x.Total),
              uid = g.Key
            })
                    .OrderByDescending(x => x.totalcoin)
                    .ToList();
            foreach (var v in rs)
            {
              profitListResultModel obj = new profitListResultModel();
              obj.uid = v.uid;
              obj.totalcoin = v.totalcoin;
              rslt.Add(obj);
            }
            break;

          case "month":
            var month = DateTime.ParseExact(s: (DateTime.Now.ToString("yyyyMM") + "01"), format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("vi-VN"));
            var month_start = Utils.DateTimeToLong(month);
            var month_end = Utils.DateTimeToLong(month.AddMonths(1)) - 1;
            rs = result.Where(x => x.Addtime >= month_start && x.Addtime <= month_end).GroupBy(x => x.Uid).Select(g => new
            {
              totalcoin = g.Sum(x => x.Total),
              uid = g.Key
            })
                    .OrderByDescending(x => x.totalcoin)
                    .ToList();
            foreach (var v in rs)
            {
              profitListResultModel obj = new profitListResultModel();
              obj.uid = v.uid;
              obj.totalcoin = v.totalcoin;
              rslt.Add(obj);
            }
            break;
          case "total":
            rs = result.GroupBy(x => x.Uid).Select(g => new
            {
              totalcoin = g.Sum(x => x.Total),
              uid = g.Key
            })
                .OrderByDescending(x => x.totalcoin)
                .ToList();
            foreach (var v in rs)
            {
              profitListResultModel obj = new profitListResultModel();
              obj.uid = v.uid;
              obj.totalcoin = v.totalcoin;
              rslt.Add(obj);
            }
            break;
          default:
            dayStart = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day));
            dayEnd = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: DateTime.Now.Day, hour: 23, minute: 59, second: 59));
            rs = result.Where(x => x.Addtime >= dayStart && x.Addtime <= dayEnd).GroupBy(x => x.Uid).Select(g => new
            {
              totalcoin = g.Sum(x => x.Total),
              uid = g.Key
            })
                    .OrderByDescending(x => x.totalcoin)
                    .ToList();
            foreach (var v in rs)
            {
              profitListResultModel obj = new profitListResultModel();
              obj.uid = v.uid;
              obj.totalcoin = v.totalcoin;
              rslt.Add(obj);
            }
            break;
        }

        foreach (var v in result)
        {
          ProfitModel obj = new ProfitModel();
          var userinfo = await getUserInfo(lan, v.Uid);
          if (userinfo != null)
          {
            obj.uid = v.Uid;
            obj.avatar = userinfo.avatar;
            obj.avatar_thumb = userinfo.avatar_thumb;
            obj.user_nicename = userinfo.user_nicename;
            obj.sex = userinfo.sex;
            obj.level = userinfo.level;
            obj.level_anchor = userinfo.level_anchor;
            obj.totalcoin = (int)rslt[0].totalcoin;
            obj.isAttention = await _commonService.isAttention(uid, v.Uid);
            dataResult.Add(obj);

          }
        }
        await cacheManager.SetCacheString(caches_key, JsonConvert.SerializeObject(dataResult));
      }
      else
      {
        dataResult = JsonConvert.DeserializeObject<List<ProfitModel>>(dataCache);
      }
      return dataResult;
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
