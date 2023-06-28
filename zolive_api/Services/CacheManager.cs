using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zolive_api
{
  public class CacheManager
  {
    public CacheManager()
    {
      ConfigurationOptions config = new ConfigurationOptions
      {
        EndPoints =
    {
        { "172.18.19.91", 6379 }
        //            ,
        //{ "redis1", 6380 }
    },
        CommandMap = CommandMap.Create(new HashSet<string>
    { // EXCLUDE a few commands
        "INFO", "CONFIG", "CLUSTER",
        "PING", "ECHO", "CLIENT"
    }, available: false),
        KeepAlive = 180,
        DefaultVersion = new Version(2, 8, 8),
        Password = "qq123123"
      };

      //var conn = ConnectionMultiplexer.Connect("172.18.19.91:6379,password=1111,allowAdmin=true");
      var conn = ConnectionMultiplexer.Connect(config);
      db = conn.GetDatabase();
      string getConfigPub = db.StringGet("getConfigPub");
      string getConfigPri = db.StringGet("getConfigPri");
      var dbb = db.ExecuteAsync("ZCARD", "NameEntity").Result;
    }
    IDatabase db;
    public SortedSetEntry[] zRevRangeWithScore(string key, int start, int end, int pnum)
    {
      //filter zRevRange by something

      var rs = db.SortedSetRangeByScoreWithScores(key, start, end, Exclude.None, Order.Ascending, 0, pnum, CommandFlags.None);
      return rs;
    }
    public async Task<long> ZCard(String name)
    {
      var zcard = await db.ExecuteAsync("ZCARD ", name);
      return ((long)zcard);
    }
  
  public long rPush(string key,string value)
  {
      var rPush = db.ListRightPush(key,value);
      return rPush;
  }
  public string GetCacheString(String key)
  {
    return db.StringGet(key);
  }
  public async Task<long> SCard(string key)
  {
    var sCard = await db.ExecuteAsync("SCARD ", key);
    return ((long)sCard);
  }
  public Task<bool> DeleteHash(string key, string cacheSubKey)
  {
    if (string.IsNullOrEmpty(key))
      throw new ArgumentNullException("key");

    return db.HashDeleteAsync(key, cacheSubKey);
  }
  public Task<bool> SetCacheString(String key, String value)
  {
    return db.StringSetAsync(key, value);
  }
  public Task<bool> SetCacheStrings(String key, String value, TimeSpan time)
  {
    return db.StringSetAsync(key, value, time);
  }

  public Task<bool> DeleteCache(String key)
  {
    return db.KeyDeleteAsync(key);
  }
}
}
