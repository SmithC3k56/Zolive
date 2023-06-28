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
using System.Threading.Tasks;
using zolive_api.src;
using zolive_api.Models.Home;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Text;
using zolive_api.Services.Interface;
using System.Threading;

namespace zolive_unit_test
{
    public class Tests
    {
        public static IConfiguration InitConfiguration()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }
        private ICommonService _commonService;
        [SetUp]
        public void Setup()
        {
            var config = InitConfiguration();

            ConfigNew.Configuration = config;
        }

        [Test]
        public static void MainThread()
        {
            Console.WriteLine("Application executing on thread {0}",
                              Thread.CurrentThread.ManagedThreadId);
            var asyncTask = Task.Run(() =>
            {
                Console.WriteLine("Task {0} (asyncTask) executing on Thread {1}",
                                  Task.CurrentId,
                                  Thread.CurrentThread.ManagedThreadId);
                long sum = 0;
                for (int ctr = 1; ctr <= 1000000; ctr++)
                    sum += ctr;
                return sum;
            });
            var syncTask = new Task<long>(() =>
            {
                Console.WriteLine("Task {0} (syncTask) executing on Thread {1}",
                                   Task.CurrentId,
                                   Thread.CurrentThread.ManagedThreadId);
                long sum = 0;
                for (int ctr = 1; ctr <= 1000000; ctr++)
                    sum += ctr;
                return sum;
            });
            syncTask.RunSynchronously();
            Console.WriteLine();
            Console.WriteLine("Task {0} returned {1:N0}", syncTask.Id, syncTask.Result);
            Console.WriteLine("Task {0} returned {1:N0}", asyncTask.Id, asyncTask.Result);
        }

        [Test]
        public void Test1()
        {
            newliveContext context = new newliveContext();
            var user = context.CmfUsers.Find((ulong)1L);
            var fileName = @"C:\xampp\php\php.ini";
            var ext = Path.GetExtension(fileName);
            Assert.Pass();
        }
        public async Task<string> PrivateKeyA(string host, string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var cdn_switch = configpri.cdn_switch;
            string url = "";
            switch (cdn_switch)
            {
                case "1":
                    url = await PrivateKey_ali(host, stream, type);
                    break;
                case "2":
                    url = await PrivateKey_tx(stream, type);
                    break;
                case "3":
                    url = await PrivateKey_qn(stream, type);
                    break;
                case "4":
                    url = await PrivateKey_ws(host, stream, type);
                    break;
                case "5":
                    url = await PrivateKey_wy(stream, type);
                    break;
                case "6":
                    url = await PrivateKey_ady(host, stream, type);
                    break;

            }
            return url;
        }
        public async Task<string> PrivateKey_ali(string host, string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var push = configpri.push_url.Value;
            var pull = configpri.pull_url.Value;
            var key_push = configpri.auth_key_push.Value;
            var length_push = configpri.auth_length_push.Value;
            var key_pull = configpri.auth_key_pull.Value;
            var length_pull = configpri.auth_length_pull.Value;
            var domain = "";
            var time = "";
            var url = new PrivateKeyModel();
            var stream_a = stream.Split(".");
            if (type == 1)
            {
                domain = host + "://" + push;
                time = Utils.time() + int.Parse(length_push);
            }
            else
            {
                domain = host + "://" + pull;
                time = Utils.time() + int.Parse(length_pull);
            }

            var filename = "/5showcam/" + stream;
            var sstring = "";
            var md5 = "";
            var auth_key = "";
            if (type == 1)
            {
                if (!string.IsNullOrEmpty(key_pull))
                {
                    sstring = filename + "-" + time + "-0-0-" + key_push;
                    md5 = Utils.MD5Hash(sstring);
                    auth_key = "auth_key=" + time + "-0-0-" + md5;
                }
                if (!String.IsNullOrEmpty(auth_key))
                {
                    auth_key = "?" + auth_key;
                }
                url.cdn = domain + "/5showcam";
                url.stream = stream + auth_key;
            }
            else
            {
                if (!string.IsNullOrEmpty(key_pull))
                {
                    sstring = filename + "-" + time + "-0-0-" + key_pull;
                    md5 = Utils.MD5Hash(sstring);
                    auth_key = "auth_key=" + time + "-0-0-" + md5;
                }
                if (!String.IsNullOrEmpty(auth_key))
                {
                    auth_key = "?" + auth_key;
                }

                var url_string = domain + filename + auth_key;
                var configpub = await _commonService.getConfigPub();
                var HttpStringValue = await Utils.strstr(configpub.site.Value, "https");
                if (!string.IsNullOrEmpty(HttpStringValue))
                {
                    url_string = url_string.Replace("http", "https");
                }
                if (type == 3)
                {
                    var url_a = url_string.Split("/" + stream);
                    url.cdn = url_a[0];
                    url.stream = stream + url_a[1];
                }

            }
            var rs = JsonConvert.SerializeObject(url);
            return rs;
        }
        public async Task<string> PrivateKey_qn(string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var ak = configpri.qn_ak.Value;
            var sk = configpri.qn_sk.Value;
            var hubName = configpri.qn_hname.Value;
            var push = configpri.qn_push.Value;
            var pull = configpri.qn_pull.Value;
            var stream_a = stream.Split(".");
            var streamKey = stream_a[0];
            var ext = stream_a[1] != null ? stream_a[1] : "";
            var url = new PrivateKeyModel();
            if (type == 1)
            {
                var time = Utils.time() + 60 * 60 * 10;
                var url2 = Hub.RTMPPublishURL(push, hubName, streamKey, time, ak, sk);
                var url_a = url2.Split("/" + streamKey);
                url.cdn = url_a[0];
                url.stream = streamKey + url_a[1];
            }
            else
            {
                var urlString = "";
                if (ext == "flv")
                {
                    pull = pull.Replace("pili-live-rtmp", "pili-live-hdl");
                    urlString = Hub.HDLPlayURL(pull, hubName, streamKey);
                }
                else if (ext == "m3u8")
                {
                    pull = pull.Replace("pili-live-rtmp", "pili-live-hls");
                    urlString = Hub.HLSPlayURL(pull, hubName, streamKey);
                }
                else
                {
                    urlString = Hub.RTMPPlayURL(pull, hubName, streamKey);
                }
                if (type == 3)
                {
                    var url_a = urlString.Split("/" + stream);
                    url.cdn = url_a[0];
                    url.stream = stream + url_a[1];
                }
            }
            var rs = JsonConvert.SerializeObject(url);
            return rs;
        }
        public async Task<string> PrivateKey_tx(string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var push_url_key = configpri.tx_push_key.Value;
            var play_url_key = configpri.tx_play_key.Value;
            var push = configpri.tx_push.Value;
            var pull = configpri.tx_pull.Value;
            var stream_a = stream.Split(".");
            var streamKey = stream_a[0] != null ? stream_a[0] : "";
            var ext = stream_a[1] == null ? stream_a[1] : "";
            var live_code = streamKey;
            var now = Utils.time();
            var now_time = now + 3 * 60 * 60;
            var txTime = Utils.DecimalToHex(now_time);
            var txSecret = Utils.MD5Hash(push_url_key + live_code + txTime);
            var safe_url = "?txSecret=" + txSecret + "&txTime=" + txTime;
            var play_safe_url = "";
            var url = new PrivateKeyModel();
            if (!string.IsNullOrEmpty(configpri.tx_play_key_switch))
            {
                var play_auth_time = now + int.Parse(configpri.tx_play_time.Value);
                var txPlayTime = Utils.DecimalToHex(play_auth_time);
                var txPlaySecret = Utils.MD5Hash(play_url_key + live_code + txPlayTime);
                play_safe_url = "?txSecret=" + txPlaySecret + "&txTime=" + txPlayTime;
            }
            if (type == 1)
            {
                url.cdn = "rtmp://" + push + "/live";
                url.stream = live_code + safe_url;
            }
            else
            {
                var urlAsString = "http://" + pull + "/live/" + live_code + ".flv" + play_safe_url;
                if (!string.IsNullOrEmpty(ext))
                {
                    urlAsString = "http://" + pull + "/live/" + live_code + "." + ext + play_safe_url;
                }
                var configpub = await _commonService.getConfigPub();
                var stringValue = Utils.strstr(configpub.site.Value, "https");
                if (!string.IsNullOrEmpty(stringValue))
                {
                    urlAsString = urlAsString.Replace("http:", "https:");
                }
                if (type == 3)
                {
                    url.cdn = "rtmp://" + pull + "/live";
                    url.stream = live_code;
                }
            }
            var rs = JsonConvert.SerializeObject(url);
            return rs;
        }
        public async Task<string> PrivateKey_ws(string host, string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var stream_a = stream.Split(".");
            var streamKey = stream_a[0] != null ? stream_a[0] : "";
            var domain = "";
            var filename = "";
            var url = new PrivateKeyModel();
            if (type == 1)
            {
                domain = host + "://" + configpri.ws_push.Value;
                filename = "/" + configpri.ws_apn;
                url.cdn = domain + filename;
                url.stream = streamKey;
            }
            else
            {
                domain = host + "://" + configpri.ws_pull.Value;
                filename = "/" + configpri.ws_apn + "/" + stream;
                string urlString = domain + filename;
                if (type == 3)
                {
                    var url_a = urlString.Split("/" + stream);
                    url.cdn = url_a[0];
                    url.stream = stream + url_a[1];
                }
            }
            var rs = JsonConvert.SerializeObject(url);
            return rs;
        }
        public async Task<string> PrivateKey_wy(string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var appkey = configpri.wy_appkey.Value;
            var appSecret = configpri.wy_appsecret.Value;
            var nonce = Utils.rand(1000, 9999);
            var curTime = Utils.time();
            var checkSum = Utils.sha1(appSecret + nonce + curTime);
            var stream_a = stream.Split(".");
            var streamKey = stream_a[0] != null ? stream_a[0] : "";

            var url = "";
            string[] paramarr = { };
            if (type == 1)
            {
                url = "https://vcloud.163.com/app/channel/create";
                paramarr = new string[]
                {
          "name="+ streamKey,
          "type="+ 0
                };

            }
            else
            {
                url = "https://vcloud.163.com/app/address";
                paramarr = new string[] {
              "cid="+streamKey
          };
            }
            var jsonEncode = JsonConvert.SerializeObject(paramarr);
            var data = new StringContent(jsonEncode, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Content-Type", "application/json;charset=utf-8");
            client.DefaultRequestHeaders.Add("AppKey:", appkey);
            client.DefaultRequestHeaders.Add("Nonce", nonce.ToString());
            client.DefaultRequestHeaders.Add("CurTime", curTime.ToString());
            client.DefaultRequestHeaders.Add("CheckSum", checkSum);
            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
        public async Task<string> PrivateKey_ady(string host, string stream, int type)
        {
            var configpri = await _commonService.getConfigPri();
            var stream_a = stream.Split(".");
            var streamKey = stream_a[0] != null ? stream_a[0] : "";
            var ext = stream_a[1] != null ? stream_a[1] : "";
            var url = new PrivateKeyModel();
            var domain = "";
            var filename = "";
            var urlString = "";
            if (type == 1)
            {
                domain = host + "://" + configpri.ady_push.Value;
                filename = "/" + configpri.ady_apn.Value;
                url.cdn = domain + filename;
                url.stream = streamKey;
            }
            else
            {
                if (ext == "m3u8")
                {
                    domain = host + "://" + configpri.ady_hls_pull.Value;
                    filename = "/" + configpri.ady_apn.Value + "/" + stream;
                    urlString = domain + filename;
                }
                else
                {
                    domain = host + "://" + configpri.ady_pull.Value;
                    filename = "/" + configpri.ady_apn.Value + "/" + stream;
                    urlString = domain + filename;
                }

                if (type == 3)
                {
                    var url_a = urlString.Split("/" + stream);
                    url.cdn = url_a[0];
                    url.stream = stream + url_a[1];
                }

            }
            var rs = JsonConvert.SerializeObject(url);
            return rs;
        }

        [Test]
        public void Test2()
        {
            newliveContext context = new newliveContext();
            var user = context.CmfUsers.FirstOrDefault(x => x.Id == 1L);
            Assert.Pass();
        }


        [Test]
        public void TestgetConfigPub()
        {

            Assert.Pass();
        }

        private void get_upload_path()
        {
            //var file = "hello";
            //var it = file.IndexOf("")
        }
        [Test]
        public void GetCacheTest()
        {
            //var configPub = getConfigPub();
            //getConfigPri();
            //getLiveClass();
            //getVideoClass();
            //getLevelList();
            //getLevelAnchorList();
            //getLogin();
            getBaseInfo();
        }


        #region get base info
        private RsBaseInfo getBaseInfo()
        {

            //this uid get from path url in browser
            ulong uid = 45018;
            var token = "44e06fbdec0849aaac9d60a9ea7b8cd8";
            var lan = "Nam";
            var service = "User.getBaseInfo";
            RsBaseInfo rs = new RsBaseInfo();
            BaseInfo info = getInfo(uid);
            CacheManager cacheManager = new CacheManager();
            if (info == null)
            {
                rs.code = 700;
                rs.msg = "Trạng thái đăng nhập không hợp lệ. Vui lòng đăng nhập lại";
                return rs;
            }
            var configpri = getConfigPri();
            var configpub = getConfigPub();

            var agent_switch = configpri.agent_switch;
            var family_switch = configpri.family_switch;
            var service_switch = configpri.service_switch;
            var service_url = configpri.service_url;

            var ios_shelves = configpub.ios_shelves;

            info.agent_switch = agent_switch;
            info.family_switch = family_switch;

            var shop_switch = checkShopIsPass(uid);
            info.shop_switch = shop_switch.ToString();
            info.paidprogram_switch = checkPaidProgramIsPass(uid).ToString();

            cacheManager.SetCacheString("lang:" + uid, lan);

            int version_ios = 0;
            int? shelves = 1;
            if ((version_ios > 0) && version_ios == ios_shelves)
            {
                agent_switch = 0;
                family_switch = 0;
                shelves = 0;
            }
            ListImg list = new ListImg();
            List<ListImg> list1 = new List<ListImg>();
            List<ListImg> list2 = new List<ListImg>();
            List<ListImg> list3 = new List<ListImg>();


            list1 = new List<ListImg>
            {
                new ListImg() { id = 191,name = getVs1("消息"),thumb = "http://live.newlivevn.com/static/1.png", href ="" },
                new ListImg() { id = 192,name = getVs1("钱包"),thumb = "http://live.newlivevn.com/static/2.png", href ="" },
                new ListImg() { id = 193,name = getVs1("明细"),thumb = "http://live.newlivevn.com/static/3.png", href ="" },
                new ListImg() { id = 194,name = getVs1("商城"),thumb = "http://live.newlivevn.com/static/4.png", href ="" },

                new ListImg() { id = 19,name = getVs1("我的视频"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/video.png", href ="" },
                new ListImg() { id = 23,name = getVs1("我的动态"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/dymic.png", href ="" },

                new ListImg() { id = 3,name = getVs1("我的等级"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/level.png", href ="http://live.newlivevn.com/Appapi/Level/index" },
                new ListImg() { id = 11,name = getVs1("我的认证"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/auth.png", href ="http://live.newlivevn.com/Appapi/Auth/index" },

                new ListImg() { id = 22,name = getVs1("直播小店"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/shop.png?t=1", href ="" },
                new ListImg() { id = 24,name = getVs1("付费内容"),thumb = "http://live.newlivevn.com/static/appapi/images/personal/pay.png", href ="" }

            };

            list2.Add(new ListImg() { id = 20, name = getVs1("房间管理"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/room.png", href = "" });

            if (shelves != null)
            {
                list1.Add(new ListImg { id = 1, name = getVs1("我的收益"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/votes.png", href = "" });
                list2.Add(new ListImg { id = 5, name = getVs1("装备中心"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/equipment.png", href = "http://live.newlivevn.com/Appapi/Equipment/index" });
            }
            if (family_switch != null)
            {
                list2.Add(new ListImg { id = 6, name = getVs1("家族中心"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/family.png", href = "http://live.newlivevn.com/Appapi/Family/index2" });
                list2.Add(new ListImg { id = 7, name = getVs1("家族驻地"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/family2.png", href = "http://live.newlivevn.com/Appapi/Family/home" });
            }
            if (agent_switch != null)
            {
                list2.Add(new ListImg { id = 8, name = getVs1("邀请奖励"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/agent.png", href = "http://live.newlivevn.com/Appapi/Agent/index" });
            }
            if (service_switch != null && service_url != null)
            {
                list3.Add(new ListImg { id = 21, name = getVs1("在线客服(Beta)"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/kefu.png", href = "" });
            }
            list3.Add(new ListImg { id = 13, name = getVs1("个性设置"), thumb = "http://live.newlivevn.com/static/appapi/images/personal/set.png", href = "" });

            List<ListImg> lists = new List<ListImg>();
            lists.AddRange(list1);
            lists.AddRange(list2);
            lists.AddRange(list3);

            info.list = lists;
            rs.info = info;
            var json = JsonConvert.SerializeObject(rs);
            return rs;

        }

        private string getVs1(string text)
        {
            var lan = "En";//get value from path in url
            text = text.Trim();

            if (lan == "Zh")
            {
                return text;
            }
            else if (lan == "En")
            {
                switch (text)
                {
                    case "消息": text = "Messages"; break;
                    case "钱包": text = "Wallet"; break;
                    case "明细": text = "Livestream Centre"; break;
                    case "商城": text = "Mall"; break;
                    case "我的视频": text = "Videos"; break;
                    case "我的动态": text = "Moments"; break;
                    case "我的收益": text = "My Earnings"; break;
                    case "我的等级": text = "My Level"; break;
                    case "我的认证": text = "Verification"; break;
                    case "付费内容": text = "Paid Content"; break;
                    case "房间管理": text = "Room Management"; break;
                    case "装备中心": text = "Equipment Centre"; break;
                    case "家族中心": text = "Club Centre"; break;
                    case "家族驻地": text = "Club Room"; break;
                    case "邀请奖励": text = "Invitation Reward"; break;
                    case "在线客服(Beta)": text = "Online Customer Service "; break;
                    case "个性设置": text = "Settings"; break;
                    case "普通": text = "Ordinary"; break;
                    case "入门": text = "Entry level"; break;
                    case "守护": text = "Knight"; break;
                    case "幸运": text = "Lucky"; break;
                    case "延迟3分钟": text = "Delayed by 3 minutes"; break;
                    case "钻石": text = "Diamond"; break;
                    case "立即发放": text = "Issue immediately"; break;
                    case "日榜": text = "Daily List"; break;
                    case "周榜": text = "Weekly Bang"; break;
                    case "月榜": text = "Monthly List"; break;
                    case "总榜": text = "Total List"; break;
                    case "映票": text = "Screening Ticket"; break;
                    case "切换语言": text = "Change Language"; break;
                    case "社区公约": text = "Community Convention"; break;
                    case "隐私政策": text = "Privacy Policy"; break;
                    case "服务条款": text = "Terms Of Service"; break;
                    case "联系我们": text = "Contact Us"; break;
                    case "主播协议": text = "Idol Agreement"; break;
                    case "意见反馈": text = "Feedback"; break;
                    case "修改密码": text = "Change Password"; break;
                    case "清除缓存": text = "Clear Cache"; break;
                    case "注销账号": text = "Delete Account"; break;
                    case "检查更新": text = "Check For Updates"; break;
                    case "有新的版本，是否更新": text = "There is a new version, do you want to update?"; break;
                    case "直播小店": text = "Shop"; break;
                    default: text = ""; break;
                }
            }
            else if (lan == "Nam")
            {
                switch (text)
                {
                    case "消息": text = "Tin nhắn"; break;
                    case "钱包": text = "Ví tiền"; break;
                    case "明细": text = "Chi tiết"; break;
                    case "商城": text = "Trung tâm mua sắm"; break;
                    case "我的视频": text = "Video của tôi"; break;
                    case "我的动态": text = "Hoạt động của tôi"; break;
                    case "我的收益": text = "Thu nhập của tôi"; break;
                    case "我的等级": text = "Cấp độ của tôi"; break;
                    case "我的认证": text = "Xác minh của tôi"; break;
                    case "付费内容": text = "Nội dung trả phí"; break;
                    case "房间管理": text = "Quản lý phòng"; break;
                    case "装备中心": text = "Trung tâm thiết bị"; break;
                    case "家族中心": text = "Trung tâm gia tộc"; break;
                    case "家族驻地": text = "Gia tộc của tôi"; break;
                    case "邀请奖励": text = "Phần thưởng giới thiệu"; break;
                    case "在线客服(Beta)": text = "Dịch vụ khách hàng trực tuyến"; break;
                    case "个性设置": text = "Cài đặt"; break;
                    case "普通": text = "Phổ thông"; break;
                    case "入门": text = "Nhập môn"; break;
                    case "守护": text = "bảo hộ"; break;
                    case "幸运": text = "may mắn"; break;
                    case "延迟3分钟": text = "Bị hoãn 3 phút"; break;
                    case "钻石": text = "kim cương"; break;
                    case "立即发放": text = "Lập tức phát hành"; break;
                    case "日榜": text = "Ngày"; break;
                    case "周榜": text = "Tuần"; break;
                    case "月榜": text = "Tháng"; break;
                    case "总榜": text = "Tổng"; break;
                    case "映票": text = "Phiếu"; break;
                    case "切换语言": text = "Chuyển đổi ngôn ngữ"; break;
                    case "社区公约": text = "Công ước cộng đồng"; break;
                    case "隐私政策": text = "Chính sách bảo mật"; break;
                    case "服务条款": text = "Điều khoản dịch vụ"; break;
                    case "联系我们": text = "Liên hệ chúng tôi"; break;
                    case "主播协议": text = "Thỏa thuận Idol"; break;
                    case "意见反馈": text = "Thông tin phản hồi"; break;
                    case "修改密码": text = "Đổi mật khẩu"; break;
                    case "清除缓存": text = "Xóa bộ nhớ cache"; break;
                    case "注销账号": text = "Xóa tài khoản"; break;
                    case "检查更新": text = "Kiểm tra cập nhật"; break;
                    case "有新的版本，是否更新": text = "Có phiên bản mới, có cập nhật không"; break;
                    case "直播小店": text = "Cửa hàng"; break;
                    default: text = ""; break;
                }
            }
            else
            {
                text = "";
            }
            return text;
        }
        private int checkPaidProgramIsPass(ulong uid)
        {
            newliveContext context = new newliveContext();

            var info = context.CmfPaidprogramApplies.Where(x => x.Uid == (int)uid).FirstOrDefault();

            if (info == null)
            {
                return 0;
            }
            if (info.Status == 0)
            {
                return 0;
            }

            return 1;
        }

        private int checkShopIsPass(ulong uid)
        {
            newliveContext context = new newliveContext();

            var rs = context.CmfShopApplies.Where(x => x.Uid == uid).FirstOrDefault();
            if (rs == null)
            {
                return 0;
            }

            if (rs.Status == 0)
            {
                return 0;
            }
            return 1;
        }

        private BaseInfo getInfo(ulong uid)
        {
            newliveContext context = new newliveContext();

            CmfUser1 info = context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefault() ?? new CmfUser1();
            BaseInfo baseInfo = new BaseInfo();
            baseInfo.avatar = info.Avatar;
            baseInfo.avatar_thumb = info.AvatarThumb;
            baseInfo.level = getLevel(info.Consumption);
            baseInfo.level_anchor = getLevelAnchor(info.Votestotal);
            baseInfo.lives = getLives(uid);
            baseInfo.follows = getFollows(uid).ToString();
            baseInfo.fans = getFans(uid).ToString();
            baseInfo.vip = getUserVip(uid);
            baseInfo.liang = getUserLiang(uid);

            return baseInfo;
        }

        private Liang getUserLiang(ulong uid)
        {
            Liang liang = new Liang() { name = "0" };
            var nowtime = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var key = "liang_" + uid;
            newliveContext context = new newliveContext();
            CacheManager cacheManager = new CacheManager();
            var isexits = cacheManager.GetCacheString(key);
            if (isexits == null || isexits == "")
            {
                var cmfLiang = context.CmfLiangs.Where(x => x.Status.Equals(1) && x.State.Equals(1)).Where(x => (x.Uid == (int)uid)).FirstOrDefault();
                if (cmfLiang != null)
                {
                    cacheManager.SetCacheString(key, JsonConvert.SerializeObject(cmfLiang));
                }
                else
                {
                    cacheManager.DeleteCache(key);
                }

            }
            else
            {
                liang = JsonConvert.DeserializeObject<Liang>(isexits) ?? new Liang();
            }
            return liang;
        }

        private Vip getUserVip(ulong uid)
        {
            Vip vip = new Vip() { type = "0" };
            var nowtime = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var key = "vip_" + uid;
            newliveContext context = new newliveContext();
            CacheManager cacheManager = new CacheManager();
            var isexits = cacheManager.GetCacheString(key);
            if (isexits == null || isexits == "")
            {
                var vipUser = context.CmfVipUsers.Where(x => x.Uid == (int)uid).FirstOrDefault();
                if (vipUser == null || vipUser.Uid == 0)
                {
                    cacheManager.DeleteCache(key);
                }
                else
                {
                    cacheManager.SetCacheString(key, JsonConvert.SerializeObject(vipUser));
                }
            }
            else
            {
                CmfVipUser cmfVipUser = JsonConvert.DeserializeObject<CmfVipUser>(isexits) ?? new CmfVipUser();
                if (cmfVipUser.Endtime <= nowtime)
                {
                    return vip;
                }
                vip = new Vip() { type = "1" };
            }
            return vip;
        }

        private int getFans(ulong uid)
        {
            newliveContext context = new newliveContext();
            var count = context.CmfUserAttentions.Where(x => x.Uid == uid).Count();
            return count;
        }
        private int getFollows(ulong uid)
        {
            newliveContext context = new newliveContext();
            var count = context.CmfUserAttentions.Where(x => x.Uid == uid).Count();
            return count;
        }
        private int getLives(ulong uid)
        {
            newliveContext context = new newliveContext();

            var count1 = context.CmfLives.Where(x => x.Islive == 1 && x.Uid == uid).ToList().Count;
            var count2 = context.CmfLiveRecords.Where(x => x.Uid == uid).ToList().Count;

            return count1 + count2;
        }
        private string getLevelAnchor(ulong experience)
        {
            uint levelid = 1;
            uint level_a = 1;

            var levels = getLevelAnchorList();
            foreach (var level in levels)
            {
                if (level.LevelUp >= experience)
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

            return levelid.ToString();

        }
        private string getLevel(ulong experience)
        {
            uint level_a = 1;
            uint levelid = 1;
            List<CmfLevel> levels = new List<CmfLevel>();

            levels = getLevelList();
            foreach (var level in levels)
            {
                if (level.LevelUp >= experience)
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
            return levelid.ToString();

        }
        private List<CmfLevel> getLevelList()
        {
            newliveContext context = new newliveContext();
            List<CmfLevel> levels = context.CmfLevels.ToList();
            foreach (CmfLevel level in levels)
            {
                if (level.Colour == null || level.Colour == "")
                {
                    level.Colour = "#ffdd00";
                }
                else
                {
                    level.Colour = "#" + level.Colour;
                }
            }
            return levels;
        }
        #endregion
        private dynamic getLogin()
        {
            var info = getConfigPub();

            var str = "login_alert_title";
            var str1 = "login_alert_content";
            var str2 = "login_clause_title";
            var rks = "隐私政策";
            var rks1 = "服务协议";
            var lan = "Nam";// Get value from route paths in url
            if (lan == "En")
            {
                str = "login_alert_title_en";
                str1 = "login_alert_content_en";
                str2 = "login_clause_title_en";
                rks = "Privacy policy";
                rks1 = "Service agreement";
            }
            else if (lan == "Nam")
            {
                str = "login_alert_title_nam";
                str1 = "login_alert_content_nam";
                str2 = "login_clause_title_nam";
                rks = "Điều khoản dịch vụ";
                rks1 = "Chính sách bảo mật";
            }

            var title = info[str2];
            var rskstr = "《" + rks + "》";
            var rskstr1 = "《" + rks1 + "》";
            title = title.Value.ToString().Replace("{a}", rskstr).Replace("{b}", rskstr1);


            LoginAlert login_alert = new LoginAlert();

            login_alert.title = info[str];
            login_alert.content = info[str1];
            login_alert.login_title = title;
            login_alert.message = new List<Message>() {
             new Message(){
                 title = "《"+rks+"》",
                 url = info["login_service_url"]
        },
        new Message() {
            title = "《"+rks1+"》",
            url= info["login_private_url"]
        }

            };
            var loginType = info["login_type"];

            for (var i = 0; i < loginType.Count; i++)
            {
                var item = loginType[i];
                if (item.Value == "ios")
                {

                    break;
                }
            }

            info["login_alert"] = JsonConvert.SerializeObject(login_alert);
            info["login_type"] = JsonConvert.SerializeObject(loginType);
            info["login_type_ios"] = JsonConvert.SerializeObject(loginType);

            return info;

        }

        private List<CmfLevelAnchor> getLevelAnchorList()
        {
            var key = "levelanchor";
            newliveContext context = new newliveContext();
            CacheManager cacheManager = new CacheManager();
            var data = cacheManager.GetCacheString(key);
            List<CmfLevelAnchor> levelAnchors = new List<CmfLevelAnchor>();
            if (data == null || data == "")
            {
                levelAnchors = context.CmfLevelAnchors.ToList();
                if (levelAnchors.Count > 0) { cacheManager.SetCacheString(key, JsonConvert.SerializeObject(levelAnchors)); }
                else { cacheManager.DeleteCache(key); }
            }
            else
            {
                levelAnchors = JsonConvert.DeserializeObject<List<CmfLevelAnchor>>(data) ?? new List<CmfLevelAnchor>();
            }
            return levelAnchors;

        }

        //private List<CmfLevel> getLevelList()
        //{
        //    var key = "level";
        //    newliveContext context = new newliveContext();
        //    CacheManager cacheManager = new CacheManager();
        //    var data = cacheManager.GetCacheString(key);
        //    List<CmfLevel> levels = new List<CmfLevel>();
        //    if (data == null || data == "")
        //    {
        //        levels = context.CmfLevels.ToList();
        //        if (levels.Count > 0) cacheManager.SetCacheString(key, JsonConvert.SerializeObject(levels));
        //    }
        //    else
        //    {
        //        levels = JsonConvert.DeserializeObject<List<CmfLevel>>(data) ?? new List<CmfLevel>();
        //    }
        //    foreach (var level in levels)
        //    {

        //        //read more function upload file in C#
        //        if (level.Colour != null || level.Colour == "")
        //        {
        //            level.Colour = "#" + level.Colour;
        //        }
        //        else
        //        {
        //            level.Colour = "#ffdd00";
        //        }
        //    }
        //    return levels;

        //}

        private List<CmfVideoClass> getVideoClass()
        {
            var key = "getVideoClass";
            newliveContext context = new newliveContext();
            CacheManager cacheManager = new CacheManager();
            var list = cacheManager.GetCacheString(key);
            List<CmfVideoClass> videoClasses;
            if (list == null || list == "")
            {
                videoClasses = context.CmfVideoClasses.ToList();
                var lan = "En";//get from param into path

                for (int i = 0; i < videoClasses.Count; i++)
                {
                    if (lan == "En")
                    {
                        videoClasses[i].Name = videoClasses[i].NameEn;
                    }
                    else if (lan == "Nam")
                    {
                        videoClasses[i].Name = videoClasses[i].NameNam;
                    }
                }
                cacheManager.SetCacheString(key, JsonConvert.SerializeObject(videoClasses));
            }
            else
            {
                videoClasses = JsonConvert.DeserializeObject<List<CmfVideoClass>>(list) ?? new List<CmfVideoClass>();
            }
            return videoClasses;
        }

        private List<CmfLiveClass> getLiveClass()
        {
            var key = "getLiveClass";
            newliveContext context = new newliveContext();
            CacheManager cacheManager = new CacheManager();
            var list = cacheManager.GetCacheString(key);
            List<CmfLiveClass> listLive = new List<CmfLiveClass>();
            if (list == null || list == "")
            {
                listLive = context.CmfLiveClasses.ToList();

                if (listLive.Count > 0)
                {
                    cacheManager.SetCacheString(key, list);
                }

            }
            else
            {
                listLive = JsonConvert.DeserializeObject<List<CmfLiveClass>>(list);
            }
            var lan = "En";//get from param into path
            var k = 0;
            //List<CmfLiveClass> listJson = JsonConvert.DeserializeObject<List<CmfLiveClass>>(list);
            for (int i = 0; i < listLive.Count; i++)
            {
                var live = listLive[i];
                live.Thumb = get_upload_path(live.Thumb);
                if (lan == "Nam")
                {
                    live.Name = live.Nam;
                }
                if (lan == "En")
                {
                    live.Name = live.En;
                }
                listLive[k] = live;

                k++;

            }

            return listLive;
        }

        private string get_upload_path(string file)
        {
            if (file == null || file == "")
            {
                return file;
            }

            return file;
        }

        private dynamic getConfigPub()
        {

            newliveContext context = new newliveContext();
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
            newliveContext context = new newliveContext();
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

        [Test]
        public void GetRuleTest()
        {
            Getarr();
        }
        private dynamic Getarr()
        {

            JArray jarr = new JArray();
            P pGetHot = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            GetHot getHot = new GetHot() { p = pGetHot };

            Uid uidFollow = new Uid() { name = "uid", type = "int", min = 1, require = true, desc = "用户ID" };
            P pFollow = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            GetFollow getFollow = new GetFollow() { uid = uidFollow, p = pFollow };

            Lng lngNew = new Lng() { name = "lng", type = "string", desc = "经度值" };
            Lat latnew = new Lat() { name = "lat", type = "string", desc = "纬度值" };
            P pNew = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            GetNew getNew = new GetNew() { lng = lngNew, lat = latnew, p = pNew };

            Uid uidSearch = new Uid() { name = "uid", type = "int", require = true, min = 1, desc = "用户ID" };
            Key keySearch = new Key() { name = "key", type = "string", @default = "", desc = "用户ID" };
            P pSearch = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            Search search = new Search() { uid = uidSearch, key = keySearch, p = pSearch };

            Lng lngNear = new Lng() { name = "lng", type = "string", desc = "经度值" };
            Lat latNear = new Lat() { name = "lat", type = "string", desc = "纬度值" };
            P pNear = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            GetNearby getNearby = new GetNearby { lat = latNear, lng = lngNear, p = pNear };

            Uid uidRecommend = new Uid() { name = "uid", type = "int", require = true, min = 1, desc = "用户ID" };
            GetRecommend getRecommend = new GetRecommend { uid = uidRecommend };

            Uid uidAttentRecommend = new Uid() { name = "uid", type = "int", desc = "用户ID" };
            Touid touid = new Touid() { name = "touid", type = "string", desc = "关注用户ID，多个用,分隔" };
            AttentRecommend attentRecommend = new AttentRecommend() { uid = uidAttentRecommend, touid = touid };

            Uid uidProfitList = new Uid() { name = "uid", type = "int", min = 1, require = true, desc = "用户ID" };
            P pProfitList = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            Type typeProfitList = new Type { name = "type", type = "string", @default = "day", desc = "参数类型，day表示日榜，week表示周榜，month代表月榜，total代表总榜" };
            ProfitList profitList = new ProfitList { uid = uidProfitList, p = pProfitList, type = typeProfitList };

            Uid uidConsumeList = new Uid() { name = "uid", type = "int", min = 1, require = true, desc = "用户ID" };
            P pConsumeList = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            Type typeConsumeList = new Type { name = "type", type = "string", @default = "day", desc = "参数类型，day表示日榜，week表示周榜，month代表月榜，total代表总榜" };
            ConsumeList consumeList = new ConsumeList() { uid = uidConsumeList, p = pConsumeList, type = typeConsumeList };

            Liveclassid liveclassid = new Liveclassid { name = "liveclassid", type = "int", @default = "0", desc = "直播分类ID" };
            P pClassLive = new P { name = "p", type = "int", @default = "1", desc = "页数" };
            GetClassLive getClassLive = new GetClassLive() { liveclassid = liveclassid, p = pClassLive };

            Data data = new Data
            {
                getHot = getHot,
                getFollow = getFollow,
                getNew = getNew,
                search = search
            ,
                getNearby = getNearby,
                getRecommend = getRecommend,
                attentRecommend = attentRecommend,
                profitList = profitList,
                consumeList = consumeList,
                getClassLive = getClassLive,
                msg = ""
            };
            string output = JsonConvert.SerializeObject(data);


            return output;
        }

        [Test]
        public void getLoginTest()
        {
            var str = "login_alert_title";
            var str1 = "login_alert_content";
            var str2 = "login_clause_title";
            var rks = "隐私政策";
            var rks1 = "服务协议";

        }

    }


}