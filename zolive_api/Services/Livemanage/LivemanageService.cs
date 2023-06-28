using Microsoft.EntityFrameworkCore;
using zolive_api.Models.Livemanage;
using zolive_api.Services.Interface;
using zolive_db.Models;

namespace zolive_api.Services.Livemanage
{
    public class LivemanageService : ILivemanage
    {
        private readonly newliveContext context;
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly IHomeService _homeService;
        public LivemanageService(newliveContext context, IHomeService _homeService)
        {
            this.context = context;
            this._homeService = _homeService;
        }
        public async Task<List<GetRoomListModel>> getKickList(string lan, ulong liveuid)
        {
            var list = await context.CmfLiveKicks.Where(x => x.Liveuid == liveuid).OrderByDescending(x => x.Id).Select(x => x.Uid).ToListAsync();
            var rss = new List<GetRoomListModel>();
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
                    rss.Add(obj);
                }
            }
            return rss;
        }
        public async Task<List<GetRoomListModel>> getShutList(string lan, ulong liveuid)
        {
            var list = await context.CmfLiveShuts.Where(x => x.Liveuid == liveuid).OrderByDescending(x => x.Id).Select(x => x.Uid).ToListAsync();
            var rss = new List<GetRoomListModel>();
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
                    rss.Add(obj);
                }
            }
            return rss;
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
