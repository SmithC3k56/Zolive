using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zolive_unit_test
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
      //var ZCard = db.ExecuteAsync("SELECT COUNT(DISTINCT column_name) FROM table_name;",);
    }
    IDatabase db;

    public async Task<long> SCard(string key)
    {
      var sCard  = await db.ExecuteAsync("SCARD ", key);
      return ((long)sCard);
      }
    public async Task<long> ZCard(String name)
    {
      var zcard = await db.ExecuteAsync("ZCARD ", name);
      return ((long)zcard);
    }
    public string GetCacheString(String key)
    {
      return db.StringGet(key);
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

    public Task<bool> DeleteCache(String key)
    {
      return db.KeyDeleteAsync(key);
    }
  }
}
