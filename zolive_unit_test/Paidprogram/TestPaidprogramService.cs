using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using StackExchange.Redis;
using zolive_api.Models.Paidprogram;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Paidprogram
{
    public class TestPaidprogramService
    {
        public static readonly newliveContext context = new newliveContext();
        public static readonly CacheManager cacheManager = new CacheManager();
        public static readonly IHomeService homeService;
        public static readonly ICommonService _commonService;
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
            //await getPaidProgramList("En", 45231, 1);
            await apply(45231);
        }
        #region apply
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

        #endregion

        #region getPaidProgramList
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
        #endregion
    }
}
