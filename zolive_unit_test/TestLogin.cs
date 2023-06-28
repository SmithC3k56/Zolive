using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using zolive_db;
using zolive_db.Models;
using System.Linq;
using StackExchange.Redis;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using zolive_api.Models;
using zolive_api.src;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace zolive_unit_test
{
    public class TestLogin
    {
        private readonly newliveContext context = new newliveContext();
        private readonly CacheManager cacheManager = new CacheManager();
        Random rnd = new Random();
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
        public void MainTest()
        {
          
            userLoginByThird("1367972740334488", "facebook", "FACEBOOK_APPLICATION_WEB", "", "android");
        }

        public dynamic userLoginByThird(string openid, string type, string nickname, string avatar, string source)
        {
            InfoLoginByModel info = new InfoLoginByModel();

            var userInfo = context.CmfUsers1.Where(x => x.Openid == openid && x.LoginType == type).FirstOrDefault();
           

            var avatar_thumb = "";
            var configpri = getConfigPri();
            if (userInfo == null)
            {
                var user_pass = "yunbaokeji";
                user_pass = setPass(user_pass);
                DateTime foo = DateTime.Now;
                long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();

                int num = rnd.Next(100, 999);

                var user_login = type + '_' + unixTime + num;
                if (nickname == null || nickname.Trim() == "")
                {

                    nickname = type + "用户-" + openid.Substring(-4);
                }
                else
                {
                    nickname = UrlDecode(nickname);
                }
                if (avatar == null || avatar.Trim() == "")
                {
                    avatar = "/default.jpg";
                    avatar_thumb = "/default_thumb.jpg";
                }
                else
                {
                    avatar = UrlDecode(avatar);
                    avatar_thumb = avatar;
                }
                var reg_reward = configpri.reg_reward;
                CmfUser1 infoNew = new CmfUser1();
                infoNew.UserLogin = user_login;
                infoNew.UserNicename = nickname;
                infoNew.UserPass = user_pass;
                infoNew.Signature = "";
                infoNew.Area = "";
                infoNew.Mobile = "";
                infoNew.UserActivationKey = "";
                infoNew.Province = "";
                infoNew.City = "";
                infoNew.Goodnum = "";
                infoNew.Location = "";
                infoNew.Education = "";
                infoNew.Professional = "";
                infoNew.Url1 = "";
                infoNew.Avatar = avatar;
                infoNew.AvatarThumb = avatar_thumb;
                infoNew.LastLoginIp = "127.0.0.1";
                infoNew.CreateTime = (int)((DateTimeOffset)foo).ToUnixTimeSeconds();
                infoNew.UserStatus = 1;
                infoNew.Openid = openid;
                infoNew.LoginType = type;
                infoNew.UserType = 2;
                infoNew.Source = source;
                infoNew.Coin = reg_reward;


                var rs = context.CmfUsers1.Add(infoNew).Properties.FirstOrDefault();
                context.SaveChanges();
                ulong uid = (ulong)(rs.CurrentValue ?? -1);
                if (true)
                //if(reg_reward > 0 )
                {
                    CmfUserCoinrecord coin = new CmfUserCoinrecord();
                    coin.Type = 1;
                    coin.Action = 11;
                    coin.Uid = uid;
                    coin.Touid = uid;
                    coin.Giftid = 0;
                    coin.Giftcount = 1;
                    coin.Totalcoin = reg_reward;
                    coin.Showid = 0;
                    coin.Addtime = (int)((DateTimeOffset)foo).ToUnixTimeSeconds();

                    var rss = context.CmfUserCoinrecords.Add(coin);
                    context.SaveChanges();
                }
                string code = createCode();
                CmfAgentCode code_info = new CmfAgentCode();
                code_info.Uid = uid;
                code = code ?? createCode();
                var isexist = context.CmfAgentCodes.Where(x => x.Uid == uid).FirstOrDefault();
                if(isexist != null)
                {
                    context.CmfAgentCodes.Update(code_info);
                    context.SaveChanges();
                }
                else
                {
                    context.CmfAgentCodes.Add(code_info);
                    context.SaveChanges();
                }
                userInfo.Id = uid;
                userInfo.UserNicename = infoNew.UserNicename;
                userInfo.Avatar= get_upload_path(infoNew.Avatar);
                userInfo.AvatarThumb= get_upload_path(infoNew.AvatarThumb);
                userInfo.Sex= 2;
                userInfo.Signature= infoNew.Signature;
                userInfo.Coin= 0;
                userInfo.LoginType= infoNew.LoginType;
                userInfo.Province= "";
                userInfo.City= "";
                userInfo.Birthday= 0;
                userInfo.Consumption= 0;
                userInfo.UserStatus = 1;
                userInfo.LastLoginTime = 0;
            }
             info.id = userInfo.Id;
             info.user_nicename = userInfo.UserNicename;
             info.avatar= userInfo.Avatar;
             info.avatar_thumb = userInfo.AvatarThumb;
             info.sex= userInfo.Sex;
             info.signature = userInfo.Signature;
             info.coin = userInfo.Coin;
             info.consumption = userInfo.Consumption;
             info.votestotal = userInfo.Votestotal;
             info.province = userInfo.Province;
             info.city = userInfo.City;
             info.birthday = (userInfo.Birthday??0).ToString();
             info.login_type = userInfo.LoginType;
             info.location = userInfo.Location;
             info.last_login_time = userInfo.LastLoginTime;

            if (userInfo.UserStatus == 0)
            {
                return 1003;
            }
            if(userInfo.EndBantime > (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds())
            {
                return 1002;
            }
            if(userInfo.UserStatus == 3)
            {
                return 1004;
            }
            info.isreg = 0;
            if (info.last_login_time == 0)
            {
                info.isreg = 1;
            }

            info.isagent = 0;
            if(info.isreg == 1)
            {
                 configpri = getConfigPri();
                if((int)(configpri.agent_switch.Value) == 1)
                {
                    info.isagent = 1;
                }
            }
            if(userInfo.Birthday != null || userInfo.Birthday != 0)
            {
                long birth = userInfo.Birthday??0;

                info.birthday = UnixTimeToDateTime(birth).ToString("YYYY-MM-dd");
            }
            else
            {
                userInfo.Birthday = 0;
            }
            info.level = getLevel(info.consumption);
            //info.level_anchor = getLevelAnchor(info.votestotal);
            var token = Utils.MD5Hash(Utils.MD5Hash(info.id + userInfo.Openid + (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()));
            
            info.token = token;
            info.avatar = get_upload_path(info.avatar);
            info.avatar_thumb = get_upload_path(info.avatar_thumb);

            updateToken(info.id, token);
            var v = JsonConvert.SerializeObject(info);
            return info;
        }

        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
        private void updateToken(ulong uid,string token)
        {
            var nowtime = (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            var expiretime = nowtime + (60 * 60 * 24 * 300);
            var user = context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefault();
            
            user.LastLoginTime = nowtime;
            user.LastLoginIp = "127.0.0.1";
            context.CmfUsers1.Update(user);
            context.SaveChanges();

            var isok = context.CmfUserTokens.Where(x => x.UserId == uid).FirstOrDefault();
            isok.Token = token;
            isok.ExpireTime = (uint)expiretime;
            isok.CreateTime = (uint)nowtime;
            context.CmfUserTokens.Update(isok);

            TokenInfo token_info = new TokenInfo();
            token_info.token = token;
            token_info.uid= uid;
            token_info.expiretime= expiretime;

            cacheManager.SetCacheString("token_"+uid,JsonConvert.SerializeObject(token_info));

        }
        [Test]
        public async Task  m()
        {
            await getLevelAnchor(2222);
        }
        private  async Task<uint> getLevelAnchor(ulong experience)
        {
            uint level_a = 1;
            uint levelid = 1;

            var levels = await getLevelAnchorList();

            foreach (var level in levels)
            {
                if(level.LevelUp >= experience)
                {
                    levelid = level.Levelid;
                    break;
                }
                else
                {
                    level_a = level.Levelid;
                }
            }
            levelid = levelid < level_a ? level_a:levelid;

            return levelid;
        }
        private async Task<List<CmfLevelAnchor>> getLevelAnchorList()
        {
            var key = "levelanchor";
            var levels = cacheManager.GetCacheString(key);
            List<CmfLevelAnchor> levelAnchors = new List<CmfLevelAnchor>();
            if (levels == null || levels.Trim() == "")
            {
                 levelAnchors = await context.CmfLevelAnchors.ToListAsync();
                if(levelAnchors.Count > 0)
                {
                    await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(levelAnchors));
                }
            }
            else
            {
                levelAnchors = JsonConvert.DeserializeObject<List<CmfLevelAnchor>>(levels)?? new List<CmfLevelAnchor>();
            }
            foreach (var level in levelAnchors)
            {
                level.Thumb = get_upload_path(level.Thumb);
                level.ThumbMark = get_upload_path(level.ThumbMark);
                level.Bg = get_upload_path(level.Bg);
            }
            return levelAnchors;
        }

        private uint getLevel(ulong experience)
        {
            uint level_a = 1;
            uint levelid = 1;
            var levels = getLevelList();
            foreach(var level in levels)
            {
                if(level.LevelUp >= experience)
                {
                    levelid = level.Levelid;
                    break;
                }
                else
                {
                    level_a = level.Levelid;
                }
            }
            levelid = levelid < level_a ? level_a : levelid;
            return levelid;
        }
        private List<CmfLevel> getLevelList()
        {
            var key = "level";
            var levels = context.CmfLevels.ToList();
            for(int i = 0;i < levels.Count; i++)
            {
                var level = levels[i];
                level.Thumb = (level.Thumb);
                level.ThumbMark= get_upload_path(level.ThumbMark);
                level.Bg = get_upload_path(level.Bg);
                if(level.Colour != null)
                {
                    level.Colour = "#"+level.Colour;
                }
                else
                {
                    level.Colour = "#ffdd00";
                }
            }
            return levels;

        }
        public string get_upload_path(string file)
        {
            if (file == null || file == "") return "";

            var BaseUrl = "https://zolivenew.m99.club";
            file = BaseUrl + file;
            return file;
        }

        private string createCode(int len = 6, string format = "ALL2")
        {
            var is_abc = 0;
            var is_numer = 0;
            var password = "";
            var tmp = "";

            var chars = "";
            switch (format)
            {
                case "ALL":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
                case "ALL2":
                    chars = "ABCDEFGHJKLMNPQRSTUVWXYZ0123456789";
                    break;
                case "CHAR":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    break;
                case "NUMBER":
                    chars = "0123456789";
                    break;
                default:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    break;
            }
            while (password.Length < len)
            {
          
                var nmt = rnd.Next(1,chars.Length);
                tmp = chars.Substring(nmt, 1);
                Regex rgn = new Regex(@"^[0-9]$");
                if (is_numer != 1 && rgn.IsMatch(tmp) && long.Parse(tmp) > 0 || format == "CHAR")
                {
                    is_numer = 1;
                }
                Regex rgx = new Regex(@"^[a-zA-Z]$");
             
                if (is_abc != 1 && rgx.IsMatch(tmp) || format == "NUMBER")
                {
                    is_abc = 1;
                }

                password = password + tmp;
            }
            if (is_numer != 1 || is_abc != 1 || String.IsNullOrEmpty(password))
            {
                password = createCode(len, format);

            }
            if (password != "")
            {
                var oneinfo = context.CmfAgentCodes.Where(x => x.Code == password).Select(x => x.Uid).FirstOrDefault();
                if (oneinfo == 0 || oneinfo == null)
                {
                    return password;
                }
            }
            password = createCode(len, format);

            return password;
        }
        private static string UrlDecode(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }
        private string setPass(string pass)
        {
            var authcode = "rCt52pF2cnnKNB3Hkp";
            var hashcode = Utils.MD5Hash(Utils.MD5Hash(authcode + pass));
            var passString = "###" + hashcode;
            return passString;
        }

        private dynamic getConfigPub()
        {

 
            CacheManager cacheManager = new CacheManager();
            var getConfigPub = cacheManager.GetCacheString("getConfigPub");
            getConfigPub = null;
            if (getConfigPub == null)
            {
                var options = context.CmfOptions.FirstOrDefault(x => x.OptionName == "site_info");
                getConfigPub = options.OptionValue;
                var result = cacheManager.SetCacheString("getConfigPub", getConfigPub).Result;
                //var result = cacheManager.DeleteCache("getConfigPub").Result;
            }

            dynamic stuff = JsonConvert.DeserializeObject(getConfigPub);

            var live_time_coin = stuff.live_time_coin;

            if (live_time_coin == null)
            {
                live_time_coin = new string[0];
            }
            else
            {

                string[] word_list = live_time_coin.ToString().Split(new Char[] { ',', '\\', '\n' },
                                     StringSplitOptions.RemoveEmptyEntries);
                stuff.live_time_coin = JArray.FromObject(word_list);
            }

            var login_type = stuff.login_type;

            if (login_type == null)
            {
                login_type = new string[0];
            }
            else
            {
                string[] word_list = login_type.ToString().Split(new Char[] { ',', '\\', '\n' },
                                     StringSplitOptions.RemoveEmptyEntries);
                stuff.login_type = JArray.FromObject(word_list);

            };


            var share_type = stuff.share_type;

            if (share_type == null)
            {
                share_type = new string[0];
            }
            else
            {

                string[] word_list = share_type.ToString().Split(new Char[] { ',', '\\', '\n' },
                                     StringSplitOptions.RemoveEmptyEntries);
                stuff.share_type = JArray.FromObject(word_list);

            };

            var live_type = stuff.live_type;

            if (live_type == null)
            {
                live_type = new string[0];
            }
            else
            {

                string[] word_list = live_type.ToString().Split(new Char[] { ',', '\\', '\n' },
                                     StringSplitOptions.RemoveEmptyEntries);
                JArray jArray = new JArray();
                foreach (var item in word_list)
                {
                    jArray.Add(JArray.FromObject(item.Split(new Char[] { ';', '\\', '\n' },
                                     StringSplitOptions.RemoveEmptyEntries)));
                }



                stuff.live_type = jArray;

            };
            var jsondata = JsonConvert.SerializeObject(stuff);


            //newliveContext context = new newliveContext();
            //var options = context.CmfOptions.FirstOrDefault(x => x.OptionName == "site_info");
            //string optionValues = options.OptionValue;
            //var compare = getConfigPub.Equals(optionValues);
            //Console.WriteLine(getConfigPub);
            return stuff;
        }

        private dynamic getConfigPri()
        {
           
            CacheManager cacheManager = new CacheManager();
            var key = "getConfigPri";
            var config = cacheManager.GetCacheString(key);

            if (config == null || config == "")
            {
                var option = context.CmfOptions.FirstOrDefault(x => x.OptionName == "configpri");
                if (option != null) option = new CmfOption();
                config = JsonConvert.SerializeObject(option.OptionValue);
            }
            dynamic stuff = JsonConvert.DeserializeObject<dynamic>(config);
            if (stuff == null) stuff = "";
            if (stuff.game_switch != null || stuff.game_switch != "")
            {
                if (stuff.game_switch.Value != null || stuff.game_switch.Value == "")
                {
                    stuff.game_switch = JsonConvert.SerializeObject(stuff.game_switch.Value.ToString().Split(new Char[] { ',', '\\', '\n' }, StringSplitOptions.RemoveEmptyEntries));

                }
                else
                {
                    stuff.game_switch = new string[0];
                }
            }
            else
            {
                stuff.game_switch = new string[0];
            }
            return stuff;
        }
    }


}