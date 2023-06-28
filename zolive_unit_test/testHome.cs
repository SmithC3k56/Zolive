using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_db;
using zolive_db.Models;
using System;
using StackExchange.Redis;

namespace zolive_unit_test
{
    public class testHome
    {
        public static IConfiguration InitConfiguration()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
        public static readonly newliveContext context = new newliveContext();
        public static readonly CacheManager cacheManager = new CacheManager();
        public static readonly IRedis redis;
        public static Random rnd = new Random();

        [SetUp]
        public void Setup()
        {
            var config = InitConfiguration();

            ConfigNew.Configuration = config;
        }


        [Test]
        public async Task MainTest()
        {
           
        }

        public async Task profitList(ulong uid, string type,int p)
        {
            if (p < 1)
            {
                p = 0;
            }
            var pnum = 50;
            var start = (p - 1) * pnum;
            switch (type)
            {
                //case "day":

            }


        }
        //[Test]
        //public void GuideTest()
        //{
        //    newliveContext context = new newliveContext();

        //    var optionValue = context.CmfOptions.Where(x => x.OptionName == "guide").Select(x => x.OptionValue).FirstOrDefault();

        //    if (optionValue == null) optionValue = "0";

        //    var config = JsonConvert.DeserializeObject<dynamic>(optionValue);

        //    if (config == null) return;

        //    var where = ((int)config.type) ==0?false:true ;

        //    var guides = context.CmfGuides.Where(x => x.Type == where).ToList();

        //    List<ThumbImgs> listImgs= new List<ThumbImgs>();
        //    foreach (var guide in guides)
        //    {
        //        ThumbImgs obj = new ThumbImgs();

        //        obj.thumb= get_upload_path(guide.Thumb);
        //        obj.href = UrlDecode(guide.Href);

        //        listImgs.Add( obj );

        //    }
        //    Guildes guildes = new Guildes();

        //    guildes.list = listImgs;
        //    guildes.time = config.time;
        //    guildes.type = config.type;
        //    guildes.@switch = config.@switch;

        //}
        private static string UrlDecode(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }

        public string get_upload_path(string file)
        {
            if (file.Trim() == "") return "";

            var BaseUrl = "https://zolivenew.m99.club";
            file = BaseUrl + file;
            return file;
        }

    }
}
