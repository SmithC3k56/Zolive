using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using zolive_api.Models;
using zolive_api.Models.Dynamic;
using zolive_api.Models.User;
using zolive_api.Models.Video;
using zolive_api.Services.Home;
using zolive_api.Services.Interface;
using zolive_api.Services.Video;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Video
{
  public class VideoTest
  {
    private readonly newliveContext context = new newliveContext();
    private readonly CacheManager cacheManager = new CacheManager();
    private readonly HomeService homeService;
    private readonly ICommonService _commonService;
    Random rnd = new Random();
    //public VideoTest(HomeService homeService)
    //{
    //    this.homeService = homeService;
    //}
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
    public async Task MainTest()
    {
      //await addView(16); 
      //await setAttent(45018, 41443);
      //await TestGetClassVideo("En", 5, 45219, 1);
      //await TestGetNearby("En", 105.853617, 20.990991, 1);
      //await getComments("En", 45231, 7, 1);
      await addCommentLike("Nam", 45231, 7);
    }

    public async Task<SetCommentModel> setComment(CmfVideoComment data)
    {
      var videoid = data.Videoid;
      var comment = await context.CmfVideos.Where(x => x.Id == videoid).FirstOrDefaultAsync();
      var videoinfo =0;
      if (comment != null)
      {
        comment.Comments++;
        context.CmfVideos.Update(comment);
       videoinfo = comment.Comments;
      }

      await context.CmfVideoComments.AddAsync(data);
      var count = await context.CmfVideoComments.Where(x => x.Commentid == data.Commentid).CountAsync();
      var rs = new SetCommentModel();
      rs.comments= videoinfo;
      rs.replys = count;

      return rs;
    }
    public async Task<LikeModel?> addCommentLike(string lan, ulong uid, ulong commentid)
    {
      var rs = new LikeModel()
      {
        islike = 0,
        likes = "0"
      };
      var commentinfo = await context.CmfVideoComments.Where(x => x.Id == commentid).FirstOrDefaultAsync();
      if (commentinfo == null)
      {
        return null;//1001
      }
      var like = await context.CmfVideoCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
      var videoComment = await context.CmfVideoComments.Where(x => x.Id == commentid && x.Likes > 0).FirstOrDefaultAsync();
      if (like != null)
      {
        var VideoCommentLike = await context.CmfVideoCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
        if (VideoCommentLike != null) context.CmfVideoCommentsLikes.Remove(VideoCommentLike);
        if (videoComment != null)
        {
          videoComment.Likes--;
          context.CmfVideoComments.Update(videoComment);
          rs.islike = 0;
        }
      }
      else
      {
        var VideoCommentLike = new CmfVideoCommentsLike()
        {
          Uid = uid,
          Commentid = commentid,
          Addtime = Utils.time(),
          Touid = commentinfo.Uid,
          Videoid = commentinfo.Videoid
        };
        await context.CmfVideoCommentsLikes.AddAsync(VideoCommentLike);
        if (videoComment != null)
        {
          videoComment.Likes++;
          context.CmfVideoComments.Update(videoComment);
          rs.islike = 1;
        }
      }
      await context.SaveChangesAsync();
      var videolikes = await context.CmfVideoComments.Where(x => x.Id == commentid).Select(x => x.Likes).FirstOrDefaultAsync();

      rs.likes = Utils.NumberFormat(lan, videolikes);
      return rs;
    }
    public async Task<ResultComment> getComments(string lan, ulong uid, ulong videoid, int p)
    {
      if (p < 1) p = 1;
      var nums = 20;
      var start = (p - 1) * nums;
      var comments = await context.CmfVideoComments.Where(x => x.Videoid == videoid && x.Parentid == 0).Skip(start).Take(nums).OrderByDescending(x => x.Addtime).ToListAsync();
      var listComments = new List<VideoCommentModel>();
      foreach (var v in comments)
      {
        var comment = new VideoCommentModel();
        comment.userinfo = await getUserInfo(lan, v.Uid);
        comment.datetime = Utils.datetime(lan, v.Addtime);
        comment.likes = Utils.NumberFormat(lan, v.Likes);
        if (uid > 0)
        {
          comment.islike = await ifCommentLike(uid, v.Id);
        }
        else
        {
          comment.islike = 0;
        }
        var touserinfo = new UserInfo();
        if (v.Touid > 0)
        {
          touserinfo = await getUserInfo(lan, v.Touid);
        }
        if (touserinfo == null)
        {
          touserinfo = new UserInfo();
          comment.touid = 0;
        }
        comment.touserinfo = touserinfo;
        var count = await context.CmfVideoComments.Where(x => x.Commentid == v.Id).CountAsync();
        comment.replys = count;
        var reply = await context.CmfVideoComments.Where(x => x.Commentid == v.Id).OrderByDescending(x => x.Addtime).Take(2).ToListAsync();
        var listReply = new List<CommentV1>();
        foreach (var v1 in reply)
        {
          var obj = new CommentV1();
          // obj.userinfo = await getUserInfo(lan, v1.Uid);
          obj.datetime = Utils.datetime(lan, v1.Addtime);
          obj.likes = Utils.NumberFormat(lan, v1.Likes);
          obj.islike = await ifCommentLike(uid, v1.Id);

          if (v1.Touid > 0)
          {
            // obj.touserinfo = await getUserInfo(lan, v1.Touid);
          }
          else
          {
            // obj.touserinfo = new UserInfo();
            obj.touid = 0;
          }
          if (v1.Parentid > 0 && v1.Parentid != v.Id)
          {
            obj.tocommentinfo = await context.CmfVideoComments.Where(x => x.Id == v1.Parentid).Select(x => new
            {
              content = x.Content ?? "",
              at_info = x.AtInfo
            }).FirstOrDefaultAsync();
          }
          else
          {
            obj.tocommentinfo = new
            {
              content = "",
              at_info = ""
            };
            // obj.touserinfo = new UserInfo();
            obj.touid = 0;
          }
          listReply.Add(obj);
        }
        comment.replylist = listReply;
        listComments.Add(comment);
      }
      var commentnum = await context.CmfVideoComments.Where(x => x.Videoid == videoid).CountAsync();
      var rs = new ResultComment();
      rs.comments = commentnum;
      rs.commentlist = listComments;
      return rs;
    }

    public async Task<sbyte> ifCommentLike(ulong uid, ulong commentid)
    {
      var like = await context.CmfDynamicCommentsLikes.Where(x => x.Uid == uid && x.Commentid == commentid).FirstOrDefaultAsync();
      if (like == null) return 0;

      return 1;
    }
    [Test]
    public void TestMath()
    {
      var lat = 2222.22333;
      var sin = Math.Round(
                  6378.138 * 2 * Math.Asin(
                  Math.Sqrt(
                      Math.Pow(
                          Math.Sin(
                              (
                              lat * Math.PI / 180 - Double.Parse("282828.58584") * Math.PI / 180
                              ) / 2
                          ),
                      2
                      ) + Math.Cos(lat * Math.PI / 180) * Math.Cos(Double.Parse("282828.58584") * Math.PI / 180) * Math.Pow(
                          Math.Sin(
                              (
                              8282828 * Math.PI / 180 - Double.Parse("383838.555") * Math.PI / 180
                              ) / 2
                              ),
                          2
                          )
                      )

                  ) * 1000
                  );
    }

    public async Task TestGetNearby(string lan, double lng, double lat, int p)
    {
      if (p < 1)
      {
        p = 1;
      }
      var pnum = 20;
      var start = (p - 1) * pnum;
      var info = await context.CmfLives.Where(x => x.Islive == 1 && x.Lng != "" && x.Lat != "").Skip(start).Take(pnum).ToListAsync();
      List<NearByModel> results = new List<NearByModel>();
      if (info == null)
      {
        // return 1001;
      }
      else
      {
        foreach (var x in info)
        {
          NearByModel obj = new NearByModel();
          obj.uid = x.Uid;
          obj.title = x.Title;
          obj.city = x.City;
          obj.stream = x.Stream;
          obj.pull = x.Pull;
          obj.thumb = x.Thumb;
          obj.isvideo = x.Isvideo;
          obj.type = x.Type;
          obj.type_val = x.TypeVal;
          obj.goodnum = x.Goodnum;
          obj.starttime = x.Starttime;
          obj.isshop = x.Isshop;
          obj.game_action = x.GameAction;
          obj.province = x.Province;
          obj.distance = Math.Round(
              6378.138 * 2 * Math.Asin(
              Math.Sqrt(
                  Math.Pow(
                      Math.Sin(
                          (
                          lat * Math.PI / 180 - Double.Parse(x.Lat) * Math.PI / 180
                          ) / 2
                      ),
                  2
                  ) + Math.Cos(lat * Math.PI / 180) * Math.Cos(Double.Parse(x.Lat) * Math.PI / 180) * Math.Pow(
                      Math.Sin(
                          (
                          lng * Math.PI / 180 - Double.Parse(x.Lng) * Math.PI / 180
                          ) / 2
                          ),
                      2
                      )
                  )
              ) * 1000
              ).ToString();
          obj = await handleLive(lan, obj);
          if (Double.Parse(obj.distance) > 1000)
          {
            obj.distance = "1000";
          }
          obj.distance = obj.distance + " Km";
          results.Add(obj);
        }
      }
      results = results.OrderBy(x => x.distance).ToList();
      var json = JsonConvert.SerializeObject(results);

    }
    public async Task<NearByModel> handleLive(string? lan, NearByModel v)
    {
      var configpri = await _commonService.getConfigPri();

      var num = await cacheManager.ZCard("user_" + v.stream);
      v.nums = num;
      var userinfo = await getUserInfo(lan, v.uid);
      v.avatar = userinfo.avatar;
      v.avatar_thumb = userinfo.avatar_thumb;
      v.user_nicename = userinfo.user_nicename;
      v.sex = userinfo.sex;
      v.level = userinfo.level;
      v.level_anchor = userinfo.level_anchor;

      if (v.thumb == null || v.thumb == "")
      {
        v.thumb = userinfo.avatar;

      }
      if (v.isvideo == false && configpri.cdn_switch != 5)
      {
        v.pull = await PrivateKeyA("rtmp", v.stream, 0);
      }
      if (v.type == 1)
      {
        v.type_val = "";
      }
      v.game = getGame(v.game_action);
      return v;
    }
    public string getGame(int action)
    {
      List<ParamModel> gameaction = new List<ParamModel>();
      gameaction.Add(new ParamModel() { Key = "0", Value = "" });
      gameaction.Add(new ParamModel() { Key = "1", Value = "智勇三张" });
      gameaction.Add(new ParamModel() { Key = "2", Value = "海盗船长" });
      gameaction.Add(new ParamModel() { Key = "3", Value = "转盘" });
      gameaction.Add(new ParamModel() { Key = "4", Value = "开心牛仔" });
      gameaction.Add(new ParamModel() { Key = "5", Value = "二八贝" });

      var rs = gameaction.Where(x => x.Key == action.ToString()).FirstOrDefault();
      if (rs == null)
      {
        return "";
      }
      else
      {
        return rs.Value;
      }
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
          url = await PrivateKey_tx(host, stream, type);
          break;
        case "3":
          url = await PrivateKey_qn(host, stream, type); //chưa hoàn thiện
          break;
        case "4":
          url = await PrivateKey_ws(host, stream, type);
          break;
        case "5":
          url = await PrivateKey_wy(host, stream, type);
          break;
        case "6":
          url = await PrivateKey_ady(host, stream, type);
          break;

      }
      return url;
    }
    public async Task<string> PrivateKey_ady(string host, string stream, int type)
    {
      string url = "";
      var configpri = await _commonService.getConfigPri();
      var stream_a = stream.Split(".");
      string streamKey = stream_a[0];
      var ext = stream_a[1];
      var domain = "";
      var filename = "";
      if (type == 1)
      {
        domain = host + "://" + configpri.ady_push;
        filename = "/" + configpri.ady_apn + "/" + stream;
        url = domain + filename;

      }
      else
      {
        if (ext == "m3u8")
        {
          domain = host + "://" + configpri.ady_hls_pull;
          filename = "/" + configpri.ady_apn + "/" + stream;
          url = domain + filename;
        }
        else
        {
          domain = host + "://" + configpri.ady_pull;
          filename = "/" + configpri.ady_apn + "/" + stream;
          url = domain + filename;
        }
      }

      return url;
    }
    public async Task<string> PrivateKey_wy(string host, string stream, int type)
    {
      string rs = "";
      string url = "";
      string paramarr = "";
      var configpri = await _commonService.getConfigPri();
      var appkey = configpri.wy_appkey;
      var appSecret = configpri.wy_appsecret;
      var nonce = Utils.rand(1000, 9999);
      var curTime = Utils.time();
      var checkSum = Utils.sha1(appSecret + nonce + curTime);
      var header = new string[] {
            "Content-Type:application/json;charset=utf-8",
            "AppKey:"+appkey,
            "Nonce:"+nonce,
            "CurTime"+curTime,
            "CheckSum"+checkSum
            };
      if (type == 1)
      {
        url = "https://vcloud.163.com/app/channel/create";
        paramarr = "name=" + stream + "& type=" + 0;

      }
      else
      {
        url = "https://vcloud.163.com/app/address";
        paramarr = "cid=" + stream;
        //paramarr.Add(new ParamModel() { Key = "cid", Value = stream });
      }
      //var paramarrjson = JsonConvert.SerializeObject(paramarr);

      ASCIIEncoding encoding = new ASCIIEncoding();
      byte[] byte1 = encoding.GetBytes(paramarr);
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.ContentLength = byte1.Length;
      request.ContentType = "application/x-www-form-urlencoded";
      request.Method = "POST";

      Stream newStream = request.GetRequestStream();
      newStream.Write(byte1, 0, byte1.Length);
      newStream.Close();

      WebResponse response = request.GetResponse();
      newStream = response.GetResponseStream();
      StreamReader sr = new StreamReader(newStream);

      sr.Close();
      newStream.Close();
      rs = JsonConvert.SerializeObject(response.ResponseUri);
      return rs;
    }
    public async Task<string> PrivateKey_ws(string host, string stream, int type)
    {
      var configpri = await _commonService.getConfigPri();
      var domain = "";
      if (type == 1)
      {
        domain = host + "://" + configpri.ws_push;

      }
      else
      {
        domain = host + "://" + configpri.ws_pull;
      }
      var filename = "/" + configpri.ws_apn + "/" + stream;

      var url = domain + filename;
      return url;
    }
    public async Task<string> PrivateKey_qn(string host, string stream, int type)
    {
      var configpri = await _commonService.getConfigPri();
      var ak = configpri.qn_ak;
      var sk = configpri.qn_sk;
      var hubName = configpri.qn_hname;
      var push = configpri.qn_push;
      var pull = configpri.qn_pull;
      var stream_a = stream.Split(".");
      var streamKey = stream_a[0];
      var ext = stream_a[1];
      var url = "";
      if (type == 1)
      {
        var time = Utils.time() + 60 * 60 * 10;

      }
      return url;
    }
    public async Task<string> PrivateKey_tx(string host, string stream, int type)
    {
      string url = "";
      var configpri = await _commonService.getConfigPri();
      var bizid = configpri.tx_bizid;
      var push_url_key = configpri.tx_push_key;
      var play_url_key = configpri.tx_play_key;
      var push = configpri.tx_push;
      var pull = configpri.tx_pull;
      var stream_a = stream.Split(".");
      var streamKey = stream_a[0];
      var ext = stream_a[1];

      var live_code = streamKey;
      var now = Utils.time();
      var now_time = now + 3 * 60 * 60;
      var txTime = Utils.DecimalToHex(now_time);

      var txSecret = Utils.MD5Hash(push_url_key + live_code + txTime);
      var safe_url = "?txSecret=" + txSecret + "&txTime=" + txTime;

      var play_safe_url = "";

      if (configpri.tx_play_key_switch != null || configpri.tx_play_key_switch != "")
      {
        var play_auth_time = now + (int)configpri.tx_play_time;
        var txPlayTime = Utils.DecimalToHex(play_auth_time);
        var txPlaySecret = Utils.MD5Hash(play_url_key + live_code + txPlayTime);
        play_safe_url = "?txSecret=" + txPlaySecret + "&txTime=" + txPlayTime;
      }

      if (type == 1)
      {
        url = "rtmp://" + push + "/live/" + live_code + safe_url;
      }
      else
      {
        url = "http://" + pull + "/live/" + live_code + ".flv" + play_safe_url;
      }

      return url;
    }
    public async Task<string> PrivateKey_ali(string host, string stream, int type)
    {
      var configpri = await _commonService.getConfigPri();

      var push = configpri.push_url;
      var pull = configpri.pull_url;
      var key_push = configpri.auth_key_push;
      var length_push = configpri.auth_length_push;
      var key_pull = configpri.auth_key_pull;
      var length_pull = configpri.auth_length_pull;
      string domain = "";
      long time;
      string auth_key = "";
      string url = "";
      if (type == 1)
      {
        domain = host + "://" + push;
        time = Utils.time() + (long)length_push;
      }
      else
      {
        domain = host + "://" + pull;
        time = Utils.time() + (long)length_pull;
      }
      var filename = "/5showcam/" + stream;
      if (type == 1)
      {
        if (key_push != "")
        {
          var sstring = filename + "-" + time + "-0-0-" + key_push;
          var md5 = Utils.MD5Hash(sstring);
          auth_key = "auth_key=" + time + "-0-0-" + md5;
        }
        if (auth_key != null || !String.IsNullOrEmpty(auth_key) || !String.IsNullOrWhiteSpace(auth_key))
        {
          auth_key = "?" + auth_key;
        }
        url = domain + filename + auth_key;
      }
      else
      {
        if (key_pull != "")
        {
          var sstring = filename + "-" + time + "-0-0-" + key_pull;
          var md5 = Utils.MD5Hash(sstring);
          auth_key = "auth_key=" + time + "-0-0-" + md5;
        }
        if (auth_key != null || !String.IsNullOrEmpty(auth_key) || !String.IsNullOrWhiteSpace(auth_key))
        {
          auth_key = "?" + auth_key;
        }
        url = domain + filename + auth_key;
      }
      return url;

    }

    //public async Task<List<VideoModel>> TestGetClassVideo(string? lan,int videoclassid,ulong uid , int p)
    //{
    //    if (p < 1)
    //    {
    //        p = 1;
    //    }
    //    var nums = 21;
    //    var start = (p-1)* nums;
    //    var listvideos = await context.CmfVideos.Where(x => x.Isdel == false && x.Status == true && x.Classid == videoclassid).Skip(start).Take(nums).ToListAsync();
    //    List<NearByModel> videos = new List<NearByModel>();
    //    foreach(var v in listvideos)
    //    {
    //        NearByModel obj = new NearByModel();

    //        obj.uid = v.Uid;
    //        obj.title = v.Title;
    //        obj.city = v.City;
    //        obj.city = v.;
    //        obj.thumb = v.Thumb;
    //        obj.thumb_s = v.ThumbS;
    //        obj.href = v.Href;
    //        obj.href_w = v.HrefW;
    //        obj.likes = v.Likes.ToString();
    //        obj.views = v.Views;
    //        obj.comments = v.Comments.ToString();
    //        obj.steps = v.Steps.ToString();
    //        obj.shares = v.Shares;
    //        obj.addtime = v.Addtime.ToString();
    //        obj.lat = v.Lat;
    //        obj.lng = v.Lng;
    //        obj.city = v.City;
    //        obj.music_id = v.MusicId;
    //        obj.is_ad = v.IsAd;
    //        obj.ad_url = v.AdUrl;
    //        obj.type = v.Type;
    //        obj.goodsid = v.Goodsid;
    //        obj.classid = v.Classid;
    //        obj.ad_endtime = v.AdEndtime;
    //        obj = await handleVideo(lan, uid, obj);
    //        videos.Add(obj);
    //    }

    //    return videos;
    //}

    [Test]
    public async Task testMain()
    {
      await distanceFormat("En", 999999);
      var jsjs = string.Format("{0:#,0.0}", 90000 / 10);
    }
    public async Task<string> distanceFormat(string lan, int distance)
    {

      if (distance < 1000)
      {
        return distance + "M";
      }
      else
      {
        var numberConvertToDecimal = Convert.ToDecimal(distance / 10);
        if (Math.Floor(numberConvertToDecimal) < 10)
        {
          return string.Format("{0:#,0.0}", distance / 10);
        }
        else
        {
          return "> 10 Km";
        }
      }
    }

    public async Task<VideoModel> handleVideo(string? lan, ulong uid, dynamic v)
    {
      var userinfo = await getUserInfo(lan, v.uid);
      v.userinfo = userinfo;
      v.datetime = Utils.datetime(lan, long.Parse(v.addtime));
      v.addtime = Utils.UnixTimeToDateTime(long.Parse(v.addtime)).ToString("yyyy-MM-dd HH-mm-ss");
      v.comments = Utils.NumberFormat(lan, decimal.Parse(v.comments));
      v.likes = Utils.NumberFormat(lan, decimal.Parse(v.likes));
      v.steps = Utils.NumberFormat(lan, decimal.Parse(v.steps));

      v.islike = 0;
      v.isstep = 0;
      v.isattent = 0;

      if (uid > 0)
      {
        v.islike = await _commonService.ifLike(uid, v.id);
        v.isstep = await _commonService.ifStep(uid, v.id);
      }

      if (uid > 0 && uid != v.uid)
      {
        v.isattent = await _commonService.isAttention(uid, v.uid);
      }

      if (v.ad_endtime < Utils.time())
      {
        v.ad_url = "";
      }

      sbyte goods_type = 0;
      if (v.type == 1)
      {
        ulong numberFormater = ulong.Parse(v.goodsid.ToString());
        goods_type = await context.CmfShopGoods.Where(x => x.Id == numberFormater).Select(x => x.Type).FirstOrDefaultAsync();

      }
      v.goods_type = goods_type;

      return v;

    }
    public async Task<UserInfo> getUserInfo(string? lan, ulong uid, int type = 0)
    {
      UserInfo info = new UserInfo();
      if (uid == 0)
      {
        if (uid == 0)//code base is string "goodsorder_admin"
        {
          var configpub = await _commonService.getConfigPub();
          info.user_nicename = "订单消息";
          if (lan == "En")
          {
            info.user_nicename = "Order message";
          }
          else if (lan == "Nam")
          {
            info.user_nicename = "Thông tin đơn hàng";

          }
          info.avatar = Utils.get_upload_path("/orderMsg.png");
          info.avatar_thumb = Utils.get_upload_path("/orderMsg.png");
          info.id = 0;
        }
        info.coin = 0;
        info.sex = 1;
        info.signature = "";
        info.province = "";
        info.city = "";
        info.birthday = "";
        info.issuper = 0;
        info.votestotal = 0;
        info.consumption = 0;
        info.location = "";
        info.user_status = 1;

      }
      else
      {
        var user = cacheManager.GetCacheString("userinfos_" + uid);
        if (user == null)
        {
          var rs = await context.CmfUsers1.Where(x => x.Id == uid && x.UserType == 2).FirstOrDefaultAsync();
          if (rs != null)
          {
            info.id = uid;
            info.user_nicename = rs.UserNicename;
            info.avatar = rs.Avatar;
            info.avatar_thumb = rs.AvatarThumb;
            info.sex = rs.Sex;
            info.signature = rs.Signature;
            info.consumption = rs.Consumption;
            info.votestotal = rs.Votestotal;
            info.province = rs.Province;
            info.city = rs.City;
            var birthday = rs.Birthday ?? 0;
            info.birthday = Utils.UnixTimeToDateTime(birthday).ToString("yyyy-MM-dd");
            info.user_status = rs.UserStatus;
            info.issuper = rs.Issuper ? 1 : 0;
            info.location = rs.Location;

            await cacheManager.SetCacheString("userinfo_" + uid, JsonConvert.SerializeObject(info));
          }
          if (type == 1)
          {
            return info;
          }
          if (rs == null)
          {
            info.id = uid;
            info.user_nicename = "用户不存在";
            info.avatar = "/default.jpg";
            info.avatar_thumb = "/default_thumb.jpg";
            info.sex = 0;
            info.signature = "";
            info.consumption = 0;
            info.votestotal = 0;
            info.province = "";
            info.city = "";
            info.birthday = "";
            info.issuper = 0;
          }
          else
          {
            info.level = await _commonService.getLevel(info.consumption);
            info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
            info.avatar = info.avatar;
            info.avatar_thumb = info.avatar_thumb;
            info.vip = await _commonService.getUserVip(uid);
            info.liang = await _commonService.getUserLiang(uid);
            if (info.birthday == "" || info.birthday == "0")
            {
              info.birthday = "";
            }
          }
        }
        else
        {
          info = JsonConvert.DeserializeObject<UserInfo>(user) ?? new UserInfo();
          info.level = await _commonService.getLevel(info.consumption);
          info.level_anchor = await _commonService.getLevelAnchor(info.votestotal);
          info.avatar = info.avatar;
          info.avatar_thumb = info.avatar_thumb;
          info.vip = await _commonService.getUserVip(uid);
          info.liang = await _commonService.getUserLiang(uid);
          if (info.birthday == "" || info.birthday == "0")
          {
            info.birthday = "";
          }
        }
      }
      return info;
    }
    private async Task<sbyte> setAttent(ulong uid, ulong touid)
    {
      var isexist = await context.CmfUserAttentions.Where(x => x.Uid == uid && x.Touid == touid).FirstOrDefaultAsync();
      if (isexist != null)
      {
        context.CmfUserAttentions.Remove(isexist);
        await context.SaveChangesAsync();
        return 0;
      }
      else
      {
        var userBlacks = await context.CmfUserBlacks.Where(x => x.Uid == uid && x.Touid == touid).FirstOrDefaultAsync();
        if (userBlacks != null) context.CmfUserBlacks.Remove(userBlacks);

        //CmfUserAttention cmfUserAttention = new CmfUserAttention();
        //cmfUserAttention.Uid = uid;
        //cmfUserAttention.Touid = touid;

        context.CmfUserAttentions.Add(new CmfUserAttention { Uid = uid, Touid = touid });
        await context.SaveChangesAsync();
        return 1;
      }
    }
    public async Task<bool> setConversion(ulong videoid)
    {
      var video = await context.CmfVideos.Where(x => x.Id == videoid && x.Isdel == false && x.Status == true).FirstOrDefaultAsync();
      if (video == null)
      {
        return false;
      }
      else
      {
        video.WatchOk += 1;
        await context.SaveChangesAsync();
        return true;
      }
    }
    public async Task<bool> addView(ulong videoid)
    {
      var video = await context.CmfVideos.Where(x => x.Id == videoid).FirstOrDefaultAsync();
      if (video == null)
      {
        return false;
      }
      else
      {
        video.Views += 1;
        await context.SaveChangesAsync();
        return true;
      }
    }

    //public  async Task<List<VideoModel>> getVideoList(string? lan,ulong uid,int p)
    //{
    //    if (p < 1)
    //    {
    //        p = 1;
    //    }
    //    var nums = 20;
    //    var start = (p - 1) * nums;
    //    var video = await context.CmfVideos.Where(x => x.Isdel == false && x.Status == true && x.IsAd == false).Skip(start).Take(nums).OrderBy(_ => Guid.NewGuid()).ToListAsync();
    //    List<VideoModel> videos = new List<VideoModel>();
    //    foreach (var v in video)
    //    {
    //        VideoModel obj = new VideoModel();
    //        obj.id = v.Id;
    //        obj.uid = v.Uid;
    //        obj.title = v.Title;
    //        obj.thumb = v.Thumb;
    //        obj.thumb_s = v.ThumbS;
    //        obj.href = v.Href;
    //        obj.href_w = v.HrefW;
    //        obj.likes = v.Likes.ToString();
    //        obj.views = v.Views;
    //        obj.comments = v.Comments.ToString();
    //        obj.steps = v.Steps.ToString();
    //        obj.shares = v.Shares;
    //        obj.addtime = v.Addtime.ToString();
    //        obj.lat = v.Lat;
    //        obj.lng = v.Lng;
    //        obj.city = v.City;
    //        obj.music_id = v.MusicId;
    //        obj.is_ad = v.IsAd;
    //        obj.ad_url = v.AdUrl;
    //        obj.type = v.Type;
    //        obj.goodsid = v.Goodsid;
    //        obj.classid = v.Classid;
    //        obj.ad_endtime = v.AdEndtime;
    //        obj = await handleVideo(lan,uid, obj);
    //        videos.Add(obj);
    //    }
    //    var json = JsonConvert.SerializeObject(videos);
    //    return videos;
    //}
    //public async Task<VideoModel> handleVideo(string? lan,ulong uid, VideoModel v)
    //{
    //    var userinfo = await HomeService.getUserInfo(lan,v.uid);
    //    v.userinfo = userinfo;
    //    v.datetime = Utils.datetime(lan,long.Parse(v.addtime));
    //    v.addtime = Utils.UnixTimeToDateTime(long.Parse(v.addtime)).ToString("yyyy-MM-dd HH-mm-ss");
    //    v.comments = Utils.NumberFormat(lan, decimal.Parse(v.comments));
    //    v.likes = Utils.NumberFormat(lan, decimal.Parse(v.likes));
    //    v.steps = Utils.NumberFormat(lan, decimal.Parse(v.steps));

    //    v.islike = 0;
    //    v.isstep = 0;
    //    v.isattent = 0;

    //    if(uid > 0)
    //    {
    //        v.islike = await ifLike(uid, v.id);
    //        v.isstep = await ifStep(uid, v.id);
    //    }

    //    if(uid >0 && uid != v.uid)
    //    {
    //        v.isattent= await isAttention(uid,v.uid);
    //    }

    //    if(v.ad_endtime< Utils.time())
    //    {
    //        v.ad_url = "";
    //    }

    //    sbyte goods_type = 0;
    //    if(v.type == 1)
    //    {
    //        goods_type = await context.CmfShopGoods.Where(x => x.Id == v.goodsid).Select(x=>x.Type).FirstOrDefaultAsync();

    //    }
    //    v.goods_type = goods_type;

    //    return v;

    //}

    public async Task<sbyte> isAttention(ulong uid, ulong touid)
    {
      var like = await context.CmfUserAttentions.Where(x => x.Uid == uid && x.Touid == touid).FirstOrDefaultAsync();
      if (like != null)
      {
        return 1;
      }
      else
      {
        return 0;
      }

    }
    public async Task<sbyte> ifLike(ulong uid, ulong videoid)
    {
      var like = await context.CmfVideoLikes.Where(x => x.Uid == uid && x.Videoid == videoid).FirstOrDefaultAsync();
      if (like != null)
      {
        return 1;
      }
      else
      {
        return 0;
      }

    }
    public async Task<sbyte> ifStep(ulong uid, ulong videoid)
    {
      var like = await context.CmfVideoSteps.Where(x => x.Uid == uid && x.Videoid == videoid).FirstOrDefaultAsync();

      if (like != null)
      {
        return 1;

      }
      else
      {
        return 0;
      }

    }

    [Test]
    public void numformat()
    {
      var str0 = Utils.NumberFormat("En", 999);
      var str = Utils.NumberFormat("En", 1000);
      var str1 = Utils.NumberFormat("En", 10000);
      var str2 = Utils.NumberFormat("En", 1000000);
      var str3 = Utils.NumberFormat("En", 1000000000);
      var str4 = Utils.NumberFormat("En", 1000000000000);
    }

  }
}
