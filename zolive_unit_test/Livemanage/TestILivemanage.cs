using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using StackExchange.Redis;
using zolive_api.Models.Live;
using zolive_api.Models.Livemanage;
using zolive_api.Services.Interface;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Livemanage
{
    public class TestILivemanage
    {
        private static readonly newliveContext context = new newliveContext();
        private static readonly CacheManager cacheManager = new CacheManager();
        private readonly IHomeService _homeService;
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
            await getRoomList("En", 45231);
        }
        public async Task<List<GetRoomListModel>> getShutList(string lan,ulong liveuid)
        {
            var list = await context.CmfLiveShuts.Where(x => x.Liveuid == liveuid).OrderByDescending(x=>x.Id).Select(x=>x.Uid).ToListAsync();
            var rss = new  List<GetRoomListModel>();
            foreach (var v in list){
                var userinfo = await _homeService.getUserInfo(lan,v);
                if(userinfo!= null){
                    GetRoomListModel obj = new GetRoomListModel();
                    obj.user_nicename = userinfo.user_nicename;
                    obj.avatar = userinfo.avatar;
                    obj.avatar_thumb = userinfo.avatar_thumb;
                    obj.sex = userinfo.sex;
                    obj.level = userinfo.level;
                    rss.Add(obj);
                }
            }
            return rss;
        }
        public async Task<GetAdminListModel> getAdminList(string lan, ulong liveuid)
        {
            var rs = await context.CmfLiveManagers.Where(x => x.Liveuid == liveuid).Select(x => x.Uid).ToListAsync();
            var result = new GetAdminListModel();
            foreach (var v in rs)
            {
                var userinfo = await _homeService.getUserInfo(lan, v);
                if (userinfo != null) result.list.Add(userinfo);
            }
            result.nums = result.list.Count;
            result.total = 5;
            return result;
        }
        public async Task<List<GetRoomListModel>> getRoomList(string lan, ulong uid)
        {
            var list = await context.CmfLiveManagers.Where(x => x.Uid == uid).Select(x => x.Liveuid).ToListAsync();
            List<GetRoomListModel> rs = new List<GetRoomListModel>();
            foreach (var v in list)
            {
                var userinfo = await _homeService.getUserInfo(lan, v);
                if (userinfo != null)
                {
                    GetRoomListModel obj = new GetRoomListModel();
                    obj.user_nicename = userinfo.user_nicename;
                    obj.avatar = userinfo.avatar;
                    obj.avatar_thumb = userinfo.avatar_thumb;
                    obj.sex = userinfo.sex;
                    obj.level = userinfo.level;
                    rs.Add(obj);
                }
            }
            return rs;
        }

    }
}
