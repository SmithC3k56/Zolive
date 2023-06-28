using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using zolive_api.Models.Paidprogram;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.Paidprogram
{
    public class PaidprogramService : IPaidprogram
    {

        private readonly newliveContext context;
        private readonly CacheManager cacheManager = new CacheManager();
        private readonly IHomeService homeService;
        private readonly ICommonService _commonService;

        public PaidprogramService(newliveContext context,ICommonService commonService, IHomeService homeService)
        {
            this._commonService = commonService;
            this.context = context;
            this.homeService = homeService;
        }
        public async Task<int> apply(ulong uid)
        {
            var info = await context.CmfPaidprogramApplies.Where(x => x.Uid == (long)uid).FirstOrDefaultAsync();
            var now = Utils.time();
            var configpub = await _commonService.getConfigPub();
            if (info != null)
            {
                var status = info.Status;
                if (status == 1)
                {
                    return 1001;
                }
                else if (status == 0) { return 1002; }
                else if (status == -1)
                {
                    var res = await context.CmfPaidprogramApplies.Where(x => x.Uid == (long)uid).FirstOrDefaultAsync();
                    if (res != null)
                    {
                        res.Status = 0;
                        context.CmfPaidprogramApplies.Update(res);
                        await context.SaveChangesAsync();
                    }
                }
            }
            else
            {
                try
                {


                    info = new CmfPaidprogramApply();
                    info.Uid = (long)uid;
                    info.Status = 0;
                    info.Addtime = Utils.time();
                    info.Percent = configpub.payment_percent;
                    context.CmfPaidprogramApplies.Add(info);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 1004;
                }
            }
            return 1;
        }

        public async Task<int> getApplyStatus(ulong uid)
        {
            var apply_status = 0;
            var info = await context.CmfPaidprogramApplies.Where(x => x.Uid == (long)uid).FirstOrDefaultAsync();
            if (info == null)
            {
                apply_status = -2;
            }
            else
            {
                apply_status = info.Status;
            }
            if (apply_status == -1) { return -2; }
            return apply_status;
        }
        public async Task<List<PaidProgramModel>> getPaidProgramList(string lan, ulong uid, int p)
        {
            if (p < 1)
            {
                p = 1;
            }
            var pnums = 50;
            var start = (p - 1) * pnums;
            var list = await context.CmfPaidprogramOrders.Where(x => x.Uid == (long)uid && x.Status == true && x.Isdel == false).OrderBy(x => x.Addtime).Select(x => new
            {
                object_id = x.ObjectId,
                touid = x.Touid
            }).Skip(start).Take(pnums).ToListAsync();
            var reasult = new List<PaidProgramModel>();
            foreach (var v in list)
            {
                var info = await context.CmfPaidprograms.Where(x => x.Id == v.object_id).Select(x => new
                {
                    id = x.Id,
                    uid = x.Uid,
                    title = x.Title,
                    thumb = x.Thumb,
                    type = x.Type,
                    videos = x.Videos
                }).FirstOrDefaultAsync();
                if (info != null)
                {
                    PaidProgramModel obj = new PaidProgramModel();
                    obj.thumb = Utils.get_upload_path(info.thumb);
                    obj.title = info.title;
                    var user_info = await homeService.getUserInfo(lan, (ulong)v.touid);
                    obj.userinfo = user_info;
                    obj.avatar = user_info.avatar;
                    obj.user_nicename = user_info.user_nicename;
                    if (info.type == false)
                    {
                        obj.video_num = "付费视频|共1集";
                        if (lan == "En") obj.video_num = "1 episode in total";
                        if (lan == "Nam") obj.video_num = "Tổng 1 tập";
                    }
                    else
                    {
                        var video_arr = JsonConvert.DeserializeObject<dynamic>(info.videos) ?? new List<dynamic>();
                        var count = video_arr.ToArray().Count;
                        obj.video_num = "共" + count + "集";
                        if (lan == "En") obj.video_num = count + " episodes in total";
                        if (lan == "Nam") obj.video_num = "Tổng " + count + " tập";
                    }
                    reasult.Add(obj);
                }

            }
            return reasult;
        }

    }
}
