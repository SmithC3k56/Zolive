using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using zolive_api.Models.User;
using zolive_api.Services.Interface;
using zolive_db.Models;

namespace zolive_api.src
{
    public static class AfterLogin
    {
        private static readonly newliveContext context = new newliveContext();
        private static readonly CacheManager cacheManager = new CacheManager();
        private static readonly ICommonService _commonService;
        private static Random rnd = new Random();


        public static async Task<int> isban(ulong uid)
        {
            var nowtime = Utils.time();
            var result = await context.CmfUsers1.Where(x => x.EndBantime > nowtime && x.Id == uid).FirstOrDefaultAsync();
            if (result != null)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        public static async Task<int> isAdmin(ulong uid, ulong liveuid)
        {
            if (uid == liveuid) return 50;
            var issuper = await isSuper(uid);
            if (issuper) return 60;
            var isexits = await context.CmfLiveManagers.Where(x => x.Uid == uid && x.Liveuid == liveuid).FirstOrDefaultAsync();
            if (isexits != null) return 40;
            return 30;
        }
        public static async Task<bool> isSuper(ulong uid)
        {
            var isexist = await context.CmfUserSupers.Where(x => x.Uid == uid).FirstOrDefaultAsync();
            if (isexist == null) return false;
            return true;
        }
        public static async Task<int> CheckToken(ulong? uid, string? token)
        {
            if (uid == null || token == null)
            {
                await cacheManager.DeleteCache("uid");
                await cacheManager.DeleteCache("token");
                await cacheManager.DeleteCache("user");
                return 700;
            }
            var key = "token_" + uid;
            dynamic userinfo = cacheManager.GetCacheString(key);

            if (userinfo == null || userinfo.Trim() == "")
            {

                var usertoken = await context.CmfUserTokens.Where(x => x.UserId == uid).Select(x => new
                {
                    token = x.Token,
                    expire_time = x.ExpireTime
                }).FirstOrDefaultAsync();
                if (usertoken != null)
                {
                    await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(userinfo));
                }
                else
                {
                    await cacheManager.DeleteCache(key);
                    return 700;
                }
            }
            long unixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            userinfo = JsonConvert.DeserializeObject<dynamic>(userinfo);
            if (userinfo == null || userinfo.token != token || userinfo.expire_time < unixTime)
            {
                await cacheManager.DeleteCache("uid");
                await cacheManager.DeleteCache("token");
                await cacheManager.DeleteCache("user");
                return 700;
            }
            else
            {
                return 0;
            }
        }
        
    }
}
