using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_api.Models.Live;
using zolive_api.Models.User;
using zolive_api.Services.Home;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Live
{
  public class live
  {
    public static readonly newliveContext context = new newliveContext();
    public static readonly CacheManager cacheManager = new CacheManager();
    public static readonly IRedis redis;
    public static Random rnd = new Random();
    private readonly IConfiguration _config;
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
    public async Task main()
    {
      //checkLive("En", 45219, "f96e37026e86f1c020cba2046d486e55", 42629, "42629_1641434921");
      await getLiverecord(45219, 1);

    }

    public async Task<int> createRoom(ulong uid, CmfLive data)
    {
      try
      {
        data.Ishot = false;
        data.Isrecommend = false;
        var userinfo = await context.CmfUsers1.Where(x => x.Id == uid).Select(x => new
        {
          ishot = x.Ishot,
          isrecommend = x.Isrecommend
        }).FirstOrDefaultAsync();
        if (userinfo != null)
        {
          data.Ishot = userinfo.ishot ?? false;
          data.Isrecommend = userinfo.isrecommend;
        }
        var isexist = await context.CmfLives.Where(x => x.Uid == uid).FirstOrDefaultAsync();
        if (isexist != null)
        {
          if (isexist.Isvideo == false && isexist.Islive == 1)
          {
            await stopRoom(uid, isexist.Stream);
            await context.CmfLives.AddAsync(data);
          }
          else
          {
            context.CmfLives.Update(data);
          }
        }
        else
        {
          await context.CmfLives.AddAsync(data);
        }
        await context.SaveChangesAsync();
        return 1;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return 0;
      }
    }

    public async Task<int> stopRoom(ulong uid, string stream)
    {
      var info = await context.CmfLives.Where(x => x.Uid == uid && x.Stream == stream && x.Islive == 1).Select(x => new CmfLiveRecord()
      {
        Uid = x.Uid,
        Showid = x.Showid,
        Starttime = (long)x.Starttime,
        Title = x.Title,
        Province = x.Province,
        City = x.City,
        Stream = x.Stream,
        Lng = x.Lng,
        Lat = x.Lat,
        Type = x.Type,
        TypeVal = x.TypeVal,
        Liveclassid = x.Liveclassid
      }).FirstOrDefaultAsync();

      var pathRoot = _config.GetValue<string>("API_ROOT");
      var path = pathRoot + "Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
      var content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 提交参数信息 info:" + JsonConvert.SerializeObject(info) + "\r\n";
      await Utils.file_put_contents(path, content, "FILE_APPEND");
      if (info != null)
      {
        try
        {
          var isdel = await context.CmfLives.Where(x => x.Uid == uid).FirstOrDefaultAsync();
          if (isdel != null)
          {
            context.CmfLives.Remove(isdel);
            await context.SaveChangesAsync();
          }
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
          return 0;//0 
        }

        var nowtime = Utils.time();
        info.Endtime = nowtime;
        info.Time = Utils.UnixTimeToDateTime(info.Showid).ToString("yyyy-MM-dd");
        var votes = await context.CmfUserVoterecords.Where(x => x.Uid == uid && x.Showid == (ulong)info.Showid).SumAsync(x => x.Total);
        info.Votes = votes.ToString();
        var nums = await cacheManager.ZCard("user_" + stream);
        await cacheManager.DeleteHash("livelist", uid.ToString());
        await cacheManager.DeleteCache(uid + "_zombie");
        await cacheManager.DeleteCache(uid + "_zombie_uid");
        await cacheManager.DeleteCache("attention_" + uid);
        await cacheManager.DeleteCache("user_" + stream);

        nums = await cacheManager.SCard(info.Uid + "_node");

        await cacheManager.DeleteCache(info.Uid + "_cc");
        await cacheManager.DeleteCache(info.Uid + "_node");

        info.Nums = (uint)nums;
        await context.CmfLiveRecords.AddAsync(info);
        await context.SaveChangesAsync();
        var path2 = pathRoot + "/Runtime/stopRoom_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
        var content2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 提交参数信息 result:" + JsonConvert.SerializeObject(info.Id) + "\r\n";
        await Utils.file_put_contents(path2, content2, "FILE_APPEND");

        var list2 = await context.CmfLiveShuts.Where(x => x.Liveuid == uid && x.Showid != 0).Select(x => x.Uid).ToListAsync();
        foreach (var v in list2)
        {
          await cacheManager.DeleteHash(uid + "shutup", v.ToString());
        }

        var game = await context.CmfGames.Where(x => x.Stream == stream && x.Liveuid == uid && x.State == 0).FirstOrDefaultAsync();

        if (game != null)
        {
          var total = await context.CmfGamerecords.Where(x => x.Gameid == game.Id)
          .GroupBy(x => x.Uid).Select(g => new
          {
            uid = g.Key,
            total = g.Sum(x => x.Coin1 + x.Coin2 + x.Coin3 + x.Coin4 + x.Coin5 + x.Coin6)
          }).ToListAsync();

          foreach (var v in total)
          {
            var user = await context.CmfUsers1.Where(x => x.Id == v.uid).FirstOrDefaultAsync();
            if (user != null)
            {
              user.Coin += (ulong)(v.total ?? 0);
              context.CmfUsers1.Update(user);

              var userCoinRecord = new CmfUserCoinrecord()
              {
                Type = 1,
                Action = 20,
                Uid = v.uid,
                Touid = v.uid,
                Giftid = game.Id,
                Giftcount = 1,
                Totalcoin = (ulong)(v.total??0),
                Showid = 0,
                Addtime = nowtime

              };
              await context.CmfUserCoinrecords.AddAsync(userCoinRecord);
            }
            var gamess = await context.CmfGames.Where(x => x.Id == game.Id).FirstOrDefaultAsync();
            if (gamess != null)
            {
              gamess.State = 3;
              gamess.Endtime = Utils.time();
              context.CmfGames.Update(gamess);
            }
            await context.SaveChangesAsync();
            var brandToken = stream + "_" + game.Action + "_" + game.Starttime + "_Game";
            await cacheManager.DeleteCache(brandToken);
          }

        }
      }

      return 1;
    }

    public async Task checkLive(ulong uid, ulong liveuid, string stream)
    {
      var isexist = await context.CmfLiveKicks.Where(x => x.Uid == uid && x.Liveuid == liveuid).FirstOrDefaultAsync();
      if (isexist == null)
      {
        return;//1008
      }
      var islive = await context.CmfLives.Where(x => x.Uid == liveuid && x.Stream == stream).Select(x => new
      {
        islive = x.Islive,
        type = x.Type,
        type_val = x.TypeVal,
        starttime = x.Starttime
      }).FirstOrDefaultAsync();
      if (islive == null || islive.islive == 0)
      {
        return;//1005
      }

    }
    public async Task<List<LiveRecordModel>> getLiverecord(ulong touid, int p)
    {
      if (p < 1) p = 1;
      var pnum = 50;
      var start = (p - 1) * pnum;
      var record = await context.CmfLiveRecords.Where(x => x.Uid == touid).OrderByDescending(x => x.Id).Skip(start).Take(pnum).Select(x => new
      {
        x = x.Id,
        uid = x.Uid,
        nums = x.Nums,
        starttime = x.Starttime,
        endtime = x.Endtime,
        title = x.Title,
        city = x.City
      }).ToListAsync();
      List<LiveRecordModel> results = new List<LiveRecordModel>();
      foreach (var v in record)
      {
        LiveRecordModel obj = new LiveRecordModel();
        obj.datestarttime = Utils.UnixTimeToDateTime(v.starttime).ToString("yyyy.MM.dd");
        obj.dateendtime = Utils.UnixTimeToDateTime(v.endtime).ToString("yyyy.MM.dd");
        var cha = v.endtime - v.starttime;
        obj.lenth = Utils.getSeconds(cha);
        results.Add(obj);
      }
      return results;
    }

  }
}
