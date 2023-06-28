using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_api.Models.MsgModel;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Messagess
{
    public class TestMessage
    {
        public static readonly newliveContext context = new newliveContext();
        public static readonly CacheManager cacheManager = new CacheManager();
        public static readonly IRedis redis;
        public static Random rnd = new Random();
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
            await getList(45231,1);
        }
        public async Task<List<MsgModel>> getList(ulong uid, int p)
        {
            if(p<1)p=1;
            var pnum = 50;
            var start = (p - 1) * pnum;

            var list = await context.CmfPushrecords.Where(x => (x.Type == false &&
            (x.Touid == "" || (x.Touid != "" && (x.Touid.Equals(uid) || x.Touid.Contains(uid.ToString()))))) ||
            (x.Type == true && x.Touid == uid.ToString())).Skip(start).Take(pnum).Select(x => new
            {
                content = x.Content,
                addtime = x.Addtime
            }).OrderByDescending(x => x.addtime).ToListAsync();
            List<MsgModel> rs = new List<MsgModel>();
            foreach (var item in list)
            {
                MsgModel obj = new MsgModel();
                obj.content = item.content;
                obj.addtime = Utils.UnixTimeToDateTime((long)item.addtime).ToString("yyyy-MM-dd HH:mm");
                rs.Add(obj);
            }
            return rs;
        }
    }
}
