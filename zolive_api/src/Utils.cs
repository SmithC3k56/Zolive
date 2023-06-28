using IronBarCode;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using zolive_api.Models;
using zolive_api.Models.Buyer;
using zolive_api.Models.Home;
using zolive_api.Models.User;
using zolive_api.Services.Interface;
using zolive_db.Home;
using zolive_db.Models;

namespace zolive_api.src
{
    public static class Utils
    {
        //public static readonly newliveContext context = new newliveContext();
        private static readonly CacheManager cacheManager = new CacheManager();
        private static ICommonService _commonService;
        public static Random rnd = new Random();
        public static async Task<PrivateKeyModel> PrivateKey_ali(string host, string stream, int type)
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
                    md5 = MD5Hash(sstring);
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
                    md5 = MD5Hash(sstring);
                    auth_key = "auth_key=" + time + "-0-0-" + md5;
                }
                if (!String.IsNullOrEmpty(auth_key))
                {
                    auth_key = "?" + auth_key;
                }

                var url_string = domain + filename + auth_key;
                var configpub = await _commonService.getConfigPub();
                var HttpStringValue = await strstr(configpub.site.Value, "https");
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
            return url;
        }
        public static async Task<PrivateKeyModel> PrivateKey_tx(string stream, int type)
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
            var now = time();
            var now_time = now + 3 * 60 * 60;
            var txTime = DecimalToHex(now_time);
            var txSecret = MD5Hash(push_url_key + live_code + txTime);
            var safe_url = "?txSecret=" + txSecret + "&txTime=" + txTime;
            var play_safe_url = "";
            var url = new PrivateKeyModel();
            if (!string.IsNullOrEmpty(configpri.tx_play_key_switch))
            {
                var play_auth_time = now + int.Parse(configpri.tx_play_time.Value);
                var txPlayTime = DecimalToHex(play_auth_time);
                var txPlaySecret = MD5Hash(play_url_key + live_code + txPlayTime);
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
                var stringValue = strstr(configpub.site.Value, "https");
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
            return url;
        }
        public static string Encode(string input, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }
        public static bool checkExt(string fileName)
        {
            string[] config = { "jpg", "png", "jpeg" };
            fileName = strip_tags(fileName);
            var ext = Path.GetExtension(fileName);
            var rs = config.Contains(ext.ToLower());
            return rs;
        }
        public static string strip_tags(this string htmlString)
        {
            var array = new char[htmlString.Length];
            var arrayIndex = 0;
            var inside = false;

            foreach (var @let in htmlString)
            {
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (inside) continue;
                array[arrayIndex] = let;
                arrayIndex++;
            }
            return new string(array, 0, arrayIndex);
        }
        public static string sign(string secret, string data)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(data);
            using (var hmacsha1 = new HMACSHA1(keyByte))
            {
                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
        public static string strstr(string str, string charString)
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
        public static async Task file_put_contents(string path, string content, string flags)
        {
            if (flags == "FILE_APPEND")
            {
                var isExitFile = File.Exists(path);
                if (isExitFile)
                {
                    await File.AppendAllTextAsync(path, content);
                }
                else
                {
                    await File.WriteAllTextAsync(path, content);
                }
            }
        }
        public static string scerweima(string url)
        {
            var key = MD5Hash(url);
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
        public static async Task<getShopEffectiveTimeModel> getShopEffectiveTime()
        {
            var configpri = await _commonService.getConfigPri();
            var shop_payment_time = configpri.shop_payment_time;
            var shop_shipment_time = configpri.shop_shipment_time;
            var shop_receive_time = configpri.shop_receive_time;
            var shop_refund_time = configpri.shop_refund_time;
            var shop_refund_finish_time = configpri.shop_refund_finish_time;
            var shop_receive_refund_time = configpri.shop_receive_refund_time;
            var shop_settlement_time = configpri.shop_settlement_time;

            getShopEffectiveTimeModel data = new getShopEffectiveTimeModel();
            data.shop_payment_time = decimal.Parse(shop_payment_time.Value);
            data.shop_shipment_time = decimal.Parse(shop_shipment_time.Value);
            data.shop_receive_time = decimal.Parse(shop_receive_time.Value);
            data.shop_refund_time = decimal.Parse(shop_refund_time.Value);
            data.shop_refund_finish_time = decimal.Parse(shop_refund_finish_time.Value);
            data.shop_receive_refund_time = decimal.Parse(shop_receive_refund_time.Value);
            data.shop_settlement_time = decimal.Parse(shop_settlement_time.Value);

            return data;
        }
        public static async Task jMessageIM(string test, ulong uid, string adminName)
        {
            var configPri = await _commonService.getConfigPri();
            var appKey = configPri.jpush_key;
            var masterSecret = configPri.jpush_secret;
            if (!string.IsNullOrEmpty(appKey.ToString()) && !string.IsNullOrEmpty(masterSecret.ToString()))
            {
                var nickname = "";
                switch (adminName)
                {
                    case "goodsorder_admin":
                        nickname = "Quản lý đơn hàng";
                        break;
                    default:
                        nickname = "";
                        break;
                }

                var regInfo = new
                {
                    username = adminName,
                    password = adminName,
                    nickname = nickname
                };

                var response = await AdminClass.register(regInfo);
                var Error = response["error"];
                var ErrorCode = (int)(response["error"]["code"]);
                if (Error == null || ErrorCode == 899001)
                {
                    var from = new
                    {
                        id = adminName,
                        type = "admin"
                    };
                    var msg = new
                    {
                        text = test
                    };
                    var notification = new
                    {
                        notifiable = false
                    };
                    var target = new
                    {
                        id = "" + uid,
                        type = "single"
                    };
                    await MessageClass.sendText(1, from, msg, target, notification, new int[0]);

                }
            }
        }
        public static bool checkSign(string[] data, string sign)
        {
            var key = "76576076c1f5f657b634e966c8836a06";
            Array.Sort(data);
            var str = "";
            foreach (var item in data)
            {
                str += item.ToString() + "&";
            }
            str = str + key;
            str = str.Replace(" ", "");

            var newsign = MD5Hash(str);
            if (sign != newsign)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static Dictionary<int, int> array_count_values(dynamic array)
        {
            var dict = new Dictionary<int, int>();

            foreach (var value in array)
            {
                // When the key is not found, "count" will be initialized to 0
                int valueInt = int.Parse(value);
                dict.TryGetValue(valueInt, out int count);
                dict[valueInt] = count + 1;
            }
            return dict;
        }
        public static int GetWeekNumberOfMonth(DateTime date)
        {
            var day = date.Day;
            float value = (float)day / 7;
            var week = (int)(Math.Ceiling(value));
            return week;
        }
        public static bool passcheck(string user_pass)
        {
            Regex rgx = new Regex(@"^(?=.*[A-Za-z])(?=.*[0-9])[a-zA-Z0-9~!@&%#_]{6,20}$");
            var isok = rgx.IsMatch(user_pass);
            return isok;
        }
        public static string getSeconds(decimal cha, int type = 0)
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
                    rs = "0" + (int)s;
                }
                if (i < 10)
                {
                    ri = "0" + (int)i;
                }
                if (h < 10)
                {
                    rh = "0" + (int)h;
                }
                if (hz < 10)
                {
                    rhz = "0" + (int)hz;
                }
                return rhz + ":" + ri + ":" + rs;
            }

            if (cha < 60)
            {
                return (int)cha + " s";
            }
            else if (iz < 60)
            {
                return (int)iz + "m " + (int)s + "s ";
            }
            else if (hz < 24)
            {
                return (int)hz + "h " + (int)i + "m " + (int)s + "s ";
            }
            else
            {
                return (int)dz + "d " + (int)h + "h " + (int)i + "m " + (int)s + "s ";
            }


        }
        public static string getBanSeconds(decimal cha, int type = 0)
        {
            var iz = Math.Floor(cha / 60);
            var hz = Math.Floor(iz / 60);
            var dz = Math.Floor(hz / 60);

            var s = cha % 60;
            var i = Math.Floor(iz % 60);
            var h = Math.Floor(hz / 24);

            string rs, ri, rh, rhz = "";

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
                return hz + ":" + i + ":" + s;
            }
            if (cha < 60)
            {
                return cha + "giây";
            }
            else if (iz < 60)
            {
                return iz + "phút" + s + "giây";
            }
            else if (hz < 24)
            {
                return hz + "giờ" + i + "phút";
            }
            else if (dz < 30)
            {
                return dz + "ngày" + h + "giờ";
            }
            else
            {
                return "";
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        public static string NumberFormat(string? lan, decimal num)
        {
            var numFormatter = "";
            if (lan == "En" || String.IsNullOrEmpty(lan) || String.IsNullOrWhiteSpace(lan))
            {
                if (num >= 1000 && num < 10000)
                {
                    numFormatter = Math.Round(num / 1000, 1) + " Thousand";
                }
                else if (num >= 10000 && num < 1000000)//format numbers to number string < 1 billion
                {
                    numFormatter = Math.Round(num / 1000, 2) + " Thousand";

                }
                else if (num >= 1000000 && num < 1000000000)
                {
                    numFormatter = Math.Round(num / 1000000, 2) + " Million";
                }
                else if (num >= 1000000000 && num < 1000000000000)
                {
                    numFormatter = Math.Round(num / 1000000000, 2) + " Billion";
                }
                else if (num >= 1000000000000)
                {
                    numFormatter = Math.Round(num / 1000000000000, 2) + " Trillion";
                }
                else if (num < 1000 && num >= 0)
                {
                    numFormatter = ((int)num).ToString();
                }
            }
            else if (lan == "Nam")
            {
                if (num >= 1000 && num < 10000)
                {
                    numFormatter = Math.Round(num / 1000, 1) + " Nghìn";
                }
                if (num >= 10000 && num < 1000000)
                {
                    numFormatter = Math.Round(num / 1000, 2) + " Nghìn";
                }
                else if (num >= 1000000 && num < 1000000000)//format numbers to number string < 1 billion
                {
                    numFormatter = Math.Round(num / 1000000, 2) + " Triệu";

                }
                else if (num >= 1000000000 && num < 1000000000000)
                {
                    numFormatter = Math.Round(num / 1000000000, 2) + " Tỉ";
                }
                else if (num >= 1000000000000)
                {
                    numFormatter = Math.Round(num / 1000000000000, 2) + " Nghìn tỉ";
                }
                else if (num < 1000 && num >= 0)
                {
                    numFormatter = ((int)num).ToString();
                }
            }
            else
            {
                if (num >= 1000 && num < 10000)
                {
                    numFormatter = Math.Round(num / 1000, 1) + " Thousand";
                }
                else if (num >= 10000 && num < 1000000)//format numbers to number string < 1 billion
                {
                    numFormatter = Math.Round(num / 1000, 2) + " Thousand";
                }
                else if (num >= 1000000 && num < 1000000000)
                {
                    numFormatter = Math.Round(num / 1000000, 2) + " Million";
                }
                else if (num >= 1000000000 && num < 1000000000000)
                {
                    numFormatter = Math.Round(num / 1000000000, 2) + " Billion";
                }
                else if (num >= 1000000000000)
                {
                    numFormatter = Math.Round(num / 1000000000000, 2) + " Trillion";
                }
                else if (num < 1000 && num >= 0)
                {
                    numFormatter = ((int)num).ToString();
                }
            }
            return numFormatter;
        }
        public static string datetime(string? lan, long time)
        {
            var now = Utils.time();
            var cha = (Decimal)(now - time);
            var iz = Math.Floor(cha / 60);
            var hz = Math.Floor(iz / 60);
            var dz = Math.Floor(hz / 60);

            var one = "s ago";
            var two = "m ago";
            var four = "d ago";
            var three = "h";

            if (lan == "Nam")
            {
                one = "giây trước";
                two = "phút trước";
                three = "giờ";
                four = "ngày trước";
            }
            else if (lan == "Zh")
            {
                one = "秒前";
                two = "分钟前";
                three = "小时";
                four = "天前";
            }
            if (lan == "En")
            {
                one = "s ago";
                two = "m ago";
                four = "d ago";
                three = "h";
            }

            if (cha < 60)
            {
                return cha + one;
            }
            else if (iz < 60)
            {
                return iz + two;
            }
            else if (hz < 24)
            {
                return hz + three;
            }
            else if (dz < 30)
            {
                return dz + four;
            }
            else
            {
                var datetime = UnixTimeToDateTime(time);

                return datetime.ToString("yyy-MM-dd");
            }

        }
        public static string DecimalToHex(decimal dec)
        {
            if (dec < 1) return "0";

            long hex = (long)dec;
            string hexStr = string.Empty;

            while (dec > 0)
            {
                hex =((long) dec) % 16;

                if (hex < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());

                dec /= 16;
            }
            return hexStr;
        }
        public static decimal HexToDecimal(string hexValue)
        {
            long decValue = long.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
            return decValue;
        }
        public static long time()
        {
            var unixTime = DateTime.Now.Subtract(DateTime.UnixEpoch).TotalSeconds;
            var timeStamp = Convert.ToInt64(unixTime);
            return timeStamp;
        }
        public static long DateTimeToLong(DateTime time)
        {
            var unixTime = time.Subtract(DateTime.UnixEpoch).TotalSeconds;
            var timeStamp = Convert.ToInt64(unixTime);
            return timeStamp;
        }
        public static string sha1(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
        public static int rand(int start, int end)
        {

            var num = rnd.Next(start, end);
            return num;
        }

        public static long LongRandom(long min, long max)
        {
            Random rand = new Random();
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return result;
        }
        public static string getVs1(string lan, string text)
        {
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

        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime timestamp = DateTime.UnixEpoch.AddSeconds(unixtime);

            return timestamp;
        }

        public static string get_upload_path(string file)
        {
            if (file == null || file == "") return "";

            var BaseUrl = "https://zolivenew.m99.club";
            file = BaseUrl + file;
            return file;
        }
        public static string createCode(int len = 6, string format = "ALL2")
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

                var nmt = rnd.Next(1, chars.Length);
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
                newliveContext context = new newliveContext();
                var oneinfo = context.CmfAgentCodes.Where(x => x.Code == password).Select(x => x.Uid).FirstOrDefault();
                if (oneinfo == 0 || oneinfo == null)
                {
                    return password;
                }
            }
            password = createCode(len, format);

            return password;
        }
        public static String UrlDecode(String url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }
        public static String UrlEncode(this String str)
        {
            return HttpUtility.UrlEncode(str);
        }
        public static string setPass(string pass)
        {
            var authcode = "rCt52pF2cnnKNB3Hkp";
            var hashcode = MD5Hash(MD5Hash(authcode + pass));
            var passString = "###" + hashcode;
            return passString;
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
