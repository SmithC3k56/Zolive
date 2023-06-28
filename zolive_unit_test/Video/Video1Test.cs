using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Video
{
    public class Video1Test
    {
        public readonly newliveContext context = new newliveContext();
        public readonly CacheManager cacheManager = new CacheManager();
        Random rnd = new Random();
        public IConfiguration InitConfiguration()
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
            await setAttent(40219, 41201);
        }
        #region getHomeVideo
        public async Task getHomeVideo(ulong uid , ulong touid,int p)
        {
            if(p<1)p=1;
            var nums = 21;
            var start = (p - 1) * nums;
            List<CmfVideo> video = new List<CmfVideo>();
            if(uid == touid)
            {
                video = await context.CmfVideos.Where(x => x.Uid == uid && x.Isdel == false && x.Status == true && x.IsAd == false).OrderByDescending(x => x.Addtime).Skip(start).Take(nums).ToListAsync();
            }else
            {
                //var videoid_s = 
            }


        }
        #endregion
        public async Task<sbyte> setAttent(ulong uid, ulong touid)
        {
            var isexist = await context.CmfUserAttentions.Where(x => x.Uid == uid && x.Touid == touid).FirstOrDefaultAsync();
            if (isexist != null)
            {
                context.CmfUserAttentions.Remove(isexist);
                await context.SaveChangesAsync();
                return 0;
            }
            else
            {
                var userBlacks = await context.CmfUserBlacks.Where(x => x.Uid == uid && x.Touid == touid).FirstOrDefaultAsync();
                if (userBlacks != null) context.CmfUserBlacks.Remove(userBlacks);

                isexist = new CmfUserAttention();
                isexist.Touid = touid;
                isexist.Uid = uid;
                context.CmfUserAttentions.Add(isexist);
                await context.SaveChangesAsync();
                return 1;
            }
        }


    }
}
