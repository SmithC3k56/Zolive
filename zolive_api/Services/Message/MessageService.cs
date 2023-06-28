using Microsoft.EntityFrameworkCore;
using zolive_api.Models.MsgModel;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Message
{
    public class MessageService: IMessageService
    {
        private readonly newliveContext context;
        private readonly CacheManager cacheManager = new CacheManager();
        public MessageService(newliveContext context)
        {
            this.context = context;
        }

        public async Task<List<MsgModel>> getList(ulong uid, int p)
        {
            if (p < 1) p = 1;
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
