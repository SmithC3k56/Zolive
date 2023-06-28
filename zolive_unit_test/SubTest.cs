using IronBarCode;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using zolive_api.Models;
using zolive_api.Models.User;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test
{
    public class SubTest
    {
        //CacheManager cacheManager = new CacheManager();
        public static readonly newliveContext context = new newliveContext();
        private readonly ICommonService _commonService;
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
        public void MainThread()
        {
            var sum = 0;
            Task task2 = new Task(() =>
            {
                for (int i = 0; i < 2000; i++) sum++;
            });
            Task task = new Task(() =>
            {
               for(int i = 0; i < 1000; i++) sum++;
            });
            task.Start();
            task2.Start();
             Task.WaitAll(task,task2);
        }

        public void DemoThread(string threadIndex)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(threadIndex + " - " + i);
            }
        }

        [Test]
        public void MainTest()
        {
            //var w = Utils.GetWeekNumberOfMonth(DateTime.Now);
            //var first = 1;
            //w = w > 1 ? w - first : 6;
            //var date = DateTime.Now.ToString("yyyyMMdd");
            //var week_start_Value = int.Parse(date) - w;
            //var week_start_dt = DateTime.ParseExact(s: week_start_Value.ToString(), format: "yyyyMMdd", provider: CultureInfo.GetCultureInfo("vi-VN"));

            //var week_end_dt = week_start_dt.AddDays(7);

            //var week_start = Utils.DateTimeToLong(week_start_dt);
            //var week_end = Utils.DateTimeToLong(week_end_dt);

            strstr("NguyenGiangSon", "@");
        }


        public string strstr(string str, string charString)
        {
            var index = str.IndexOf(charString);
            var leng = str.Length;
            if (leng > 0 && index > 0)
            {
                var strNeed = str.Substring(index, leng - index);
                return strNeed;
            }
            str = "";
            return str;

        }


        public string scerweima(string url)
        {
            var key = Utils.MD5Hash(url);
            var filename2 = "/upload/qr/" + key + ".png";
            var filename = "http://zolive.m99.club" + "/../public/upload/qr/" + key + ".png";
            var isExit = File.Exists(filename);
            if (!isExit)
            {
                var value = url;
                var matrixPointSize = 6.2068965517241379310344827586207;
                QRCodeWriter.CreateQrCode(value, (int)matrixPointSize, QRCodeWriter.QrErrorCorrectionLevel.High).SaveAsPng(filename2);
            }
            return filename2;
        }

        [Test]
        public void TimeConvert()
        {
            //var today = DateTime.Today;
            //var startTime = new DateTime(year: today.Year, month: today.Month, day: today.Day, hour: 0, minute: 0, second: 0);
            //var endtime= new DateTime(year: today.Year, month: today.Month, day: today.Day, hour: 23, minute: 59, second: 59);
            //var tsss = startTime.ToUniversalTime;

            //DateTime foo = DateTime.Now;


        }
        [Test]
        public async Task Main()
        {
            var num = 00;
            var numStr = num.ToString("D1");
            ulong uid = 45231;
            var rs = await context.CmfShopApplies.Where(x => x.Uid == uid).FirstOrDefaultAsync();

        }


        public int isban(ulong uid)
        {
            newliveContext context = new newliveContext();
            CacheManager cacheManager = new CacheManager();
            var nowtime = Utils.time();
            var result = context.CmfUsers1.Where(x => x.EndBantime > nowtime && x.Id == uid).FirstOrDefault();
            if (result != null)
            {
                return 0;
            }
            else
            {
                return 1;
            }

        }
        [Test]
        public void TestGetLoginBonus()
        {
            var seconds = getSeconds("En", 45219);
            int[] list = { 1, 2, 3, 4, 5, 6 };
            bool exists = list.Any(x => x == 0);
        }

        public string getSeconds(string lan, decimal cha, int type = 0)
        {
            var iz = Math.Floor(cha / 60);
            var hz = Math.Floor(iz / 60);
            var dz = Math.Floor(hz / 60);
            var s = cha % 60;
            var i = Math.Floor(iz % 60);
            var h = Math.Floor(hz % 60);

            string rs = "";
            string ri = "";
            string rh = "";
            string rhz = "";

            if (type == 1)
            {
                if (s < 10)
                {
                    rs = "0" + s;
                }
                if (i < 10)
                {
                    ri = "0" + i;
                }
                if (h < 10)
                {
                    rh = "0" + h;
                }
                if (hz < 10)
                {
                    rhz = "0" + hz;
                }
                return rhz + ":" + ri + ":" + rs;
            }

            if (cha < 60)
            {
                return cha + " s";
            }
            else if (iz < 60)
            {
                return iz + "m " + s + "s ";
            }
            else if (hz < 24)
            {
                return hz + "h " + i + "m " + s + "s ";
            }
            else
            {
                return dz + "d " + h + "h " + i + "m " + s + "s ";
            }


        }

        public async Task<int> LoginBonus(ulong uid)
        {
            newliveContext context = new newliveContext();
            CacheManager cacheManager = new CacheManager();
            var rs = 0;
            var configpri = await _commonService.getConfigPri();
            if (configpri.bonus_switch == null || configpri.bonus_switch == "")
            {
                return rs;
            }

            var key = "loginbonus";
            var list = cacheManager.GetCacheString(key);
            List<BonusList> bonusLists = new List<BonusList>();
            if (String.IsNullOrEmpty(list))
            {
                var loginBonus = context.CmfLoginbonus.Select(x => new
                {
                    day = x.Day,
                    coin = x.Coin
                }).ToList();
                if (loginBonus.Count > 0)
                {
                    cacheManager.SetCacheString(key, JsonConvert.SerializeObject(loginBonus));
                }

                foreach (var bonus in loginBonus)
                {
                    BonusList obj = new BonusList();
                    obj.day = bonus.day;
                    obj.coin = bonus.coin;
                    bonusLists.Add(obj);
                }
            }
            else
            {
                bonusLists = JsonConvert.DeserializeObject<List<BonusList>>(list) ?? new List<BonusList>();
            }

            foreach (var bonus in bonusLists)
            {

            }
            bool isadd = false;
            SignInfo signInfo = new SignInfo();
            var uss = context.CmfUserSigns.Where(x => x.Uid == uid).Select(x => new
            {
                bonus_day = x.BonusDay,
                bonus_time = x.BonusTime,
                count_day = x.CountDay
            }).FirstOrDefault();

            if (uss == null)
            {
                isadd = true;
                signInfo.bonus_day = 0;
                signInfo.bonus_time = 0;
                signInfo.count_day = 0;
            }
            else
            {
                signInfo.bonus_day = uss.bonus_day;
                signInfo.bonus_time = uss.bonus_time;
                signInfo.count_day = uss.count_day;
            }

            var nowtime = Utils.time();
            if (nowtime > signInfo.bonus_time)
            {
                var bonus_time = nowtime + 60 * 60 * 24;
                var bonus_day = signInfo.bonus_day;
                var count_day = signInfo.count_day;

                if (bonus_day > 6) bonus_day = 0;

                count_day++;

                if (count_day > 7) count_day = 1;

                bonus_day = count_day;

                if (isadd)
                {
                    CmfUserSign sign = new CmfUserSign();
                    sign.Uid = uid;
                    sign.BonusTime = bonus_time;
                    sign.BonusDay = bonus_day;
                    sign.CountDay = count_day;

                    context.CmfUserSigns.Add(sign);
                    context.SaveChanges();
                }
                else
                {
                    var sign = context.CmfUserSigns.Where(x => x.Uid == uid).FirstOrDefault();

                    sign.BonusTime = bonus_time;
                    sign.BonusDay = bonus_day;
                    sign.CountDay = count_day;
                    context.SaveChanges();
                }
                int? coin = 0;

                foreach (var v in bonusLists)
                {
                    if (v.day == bonus_day)
                    {
                        coin = v.coin;
                        break;
                    }
                }
                if (coin != null)
                {
                    var user = context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefault();

                    if (user != null) user.Coin += (ulong)coin;
                    context.SaveChanges();
                }
                rs = 1;

            }

            return rs;
        }
        [Test]
        public void TestZCard()
        {
            CacheManager cacheManager = new CacheManager();

            var rs = cacheManager.ZCard("user_41349_1641001416");
        }
        [Test]
        public async Task TestCurl()
        {
            var configpri = await _commonService.getConfigPri();
            var cdn_switch = configpri.cdn_switch;
            var url = "https://vcloud.163.com/app/channel/create";
            string stream = "ksksks";
            string postData = "name=" + stream + "&type=" + 0;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byte1.Length;
            request.Method = "POST";


            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            WebResponse response = request.GetResponse();
            newStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(newStream);


            sr.Close();
            newStream.Close();
        }
    }
}
