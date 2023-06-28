using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using zolive_api.Models;
using zolive_api.Models.Home;
using zolive_api.Models.User;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Home;
using zolive_db.Models;

namespace zolive_api.Services.Common
{
  public class CommonService : ICommonService
  {
    private readonly newliveContext context = new newliveContext();
    private readonly CacheManager cacheManager = new CacheManager();
    public CommonService()
    {

    }

    public async Task<bool> checkIsDestroyByUid(ulong uid)
    {
      var user_status = await context.CmfUsers1.Where(x => x.Id == uid).Select(x => x.UserStatus).FirstOrDefaultAsync();
      if (user_status == 3)
      {
        return true;
      }
      return false;
    }
    public async Task<dynamic> getConfigPub()
    {
      var getConfigPub = cacheManager.GetCacheString("getConfigPub");

      if (getConfigPub != null)
      {
        var options = await context.CmfOptions.FirstOrDefaultAsync(x => x.OptionName == "site_info");
        if (options == null)
        {
          if (!String.IsNullOrEmpty(options.OptionValue))
          {
            getConfigPub = options.OptionValue;
            await cacheManager.SetCacheString("getConfigPub", getConfigPub);
          }

        }
      }
      dynamic stuff = JsonConvert.DeserializeObject(getConfigPub ?? "") ?? new string[0];

      var live_time_coin = stuff.live_time_coin;
      if (live_time_coin == null)
      {
        live_time_coin = new string[0];
      }
      else
      {
        string[] word_list = live_time_coin.Value.Split(new Char[] { ',', '\\', '\n' },
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
        login_type = stuff.login_type;
        string[] word_list = login_type.Value.Split(new Char[] { ',', '\\', '\n' },
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
        share_type = stuff.share_type;
        string[] word_list = share_type.Value.Split(new Char[] { ',', '\\', '\n' },
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
        live_type = stuff.live_type;
        string[] word_list = live_type.Value.ToString().Split(new Char[] { ',', '\\', '\n' },
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

      return stuff;
    }
    public async Task<dynamic> getConfigPri()
    {
      var key = "getConfigPri";
      var config = cacheManager.GetCacheString(key);

      if (config == null || config == "")
      {
        var option = await context.CmfOptions.FirstOrDefaultAsync(x => x.OptionName == "configpri");
        if (option != null) option = new CmfOption();
        config = JsonConvert.SerializeObject(option.OptionValue);
      }
      dynamic stuff = JsonConvert.DeserializeObject(config ?? "") ?? new string[0];
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
    public async Task<uint> getLevelAnchor(ulong experience)
    {
      uint level_a = 1;
      uint levelid = 1;

      var levels = await getLevelAnchorList();

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

      return levelid;
    }
    public async Task<IList<CmfLevelAnchor>> getLevelAnchorList()
    {

      var key = "levelanchor";
      var levels = cacheManager.GetCacheString(key);
      List<CmfLevelAnchor> levelAnchors = new List<CmfLevelAnchor>();
      if (levels == null || levels.Trim() == "")
      {
        levelAnchors = await context.CmfLevelAnchors.Select(level => new CmfLevelAnchor
        {
          Levelid = level.Levelid,
          Levelname = level.Levelname,
          LevelUp = level.LevelUp,
          Addtime = level.Addtime,
          Id = level.Id,
          Thumb = level.Thumb,
          ThumbMark = level.ThumbMark,
          Bg = level.Bg,
        }).ToListAsync();

        if (levelAnchors.Count > 0)
        {

          await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(levelAnchors));
        }

      }
      else
      {
        levelAnchors = JsonConvert.DeserializeObject<List<CmfLevelAnchor>>(levels) ?? new List<CmfLevelAnchor>();

      }
      var count = 0;
      foreach (var level in levelAnchors)
      {
        levelAnchors[count].Thumb = Utils.get_upload_path(level.Thumb);
        levelAnchors[count].ThumbMark = Utils.get_upload_path(level.ThumbMark);
        levelAnchors[count].Bg = Utils.get_upload_path(level.Bg);
        count++;
      }
      return levelAnchors;
    }
    public async Task<uint> getLevel(ulong experience)
    {
      uint level_a = 1;
      uint levelid = 1;
      var levels = await getLevelList();
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
      return levelid;
    }
    public async Task<IList<CmfLevel>> getLevelList()
    {

      var levels = await context.CmfLevels.ToListAsync();

      
      for (var count = 0; count < levels.Count; count++)
      {
        if (levels[count].Colour != null)
        {
          levels[count].Colour = "#" + levels[count].Colour;
        }
        else
        {
          levels[count].Colour = "#ffdd00";
        }
    
      }
      return levels;

    }
    public async Task<IList<Videoclass>> getVideoClass(string lan)
    {
      var key = "getVideoClass";
      var list = cacheManager.GetCacheString(key);
      var videoClasses = new List<CmfVideoClass>();
      if (list == null || list == "")
      {
        videoClasses = await context.CmfVideoClasses.ToListAsync();


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
        await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(videoClasses));
      }
      else
      {
        videoClasses = JsonConvert.DeserializeObject<List<CmfVideoClass>>(list) ?? new List<CmfVideoClass>();

      }
      var data = videoClasses.Select(videoClass => new Videoclass
      {

        id = videoClass.Id.ToString(),
        name = videoClass.Name,
        list_order = videoClass.ListOrder,
      }).ToList();
      return data;
    }
    public async Task<IList<CmfLiveClass>> getLiveClass(string lan)
    {
      var key = "getLiveClass";

      var list = cacheManager.GetCacheString(key);
      List<CmfLiveClass> listLive = new List<CmfLiveClass>();
      if (list == null || list == "")
      {
        listLive = await context.CmfLiveClasses.ToListAsync();

        if (listLive.Count > 0)
        {
          await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(listLive));
        }

      }
      else
      {
        listLive = JsonConvert.DeserializeObject<List<CmfLiveClass>>(list)?? new List<CmfLiveClass>();
        
      }

      
      for (int i = 0; i < listLive.Count; i++)
      {
        var live = listLive[i];
        //live.Thumb = Utils.get_upload_path(live.Thumb);
        if (lan == "Nam")
        {
          live.Name = live.Nam;
        }
        if (lan == "En")
        {
          live.Name = live.En;
        }
        listLive[i] = live;

      }


      return listLive;
    }
    public async Task<IList<Levelanchor>> getLevelAnchorList1()
    {
      var key = "levelanchor";

      var data = cacheManager.GetCacheString(key);
      List<CmfLevelAnchor> levelAnchors = new List<CmfLevelAnchor>();
      if (data == null || data == "")
      {
        levelAnchors = await context.CmfLevelAnchors.ToListAsync();
        if (levelAnchors.Count > 0) { await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(levelAnchors)); }
        else { await cacheManager.DeleteCache(key); }
      }
      else
      {
        levelAnchors = JsonConvert.DeserializeObject<List<CmfLevelAnchor>>(data)?? new List<CmfLevelAnchor>();
       
      }
     var rs= levelAnchors.Select(levelAnchor => new Levelanchor{
        levelid = (int)levelAnchor.Levelid,
        thumb = levelAnchor.Thumb,
        thumb_mark = levelAnchor.ThumbMark,
        bg = levelAnchor.Bg,
      }).ToList();
     
      return rs;

    }
    public async Task<IList<Level>> getLevelList1()
    {

      var levels = await context.CmfLevels.Select(level => new Level{
      levelid = (int)level.Levelid,
      colour = string.IsNullOrEmpty(level.Colour) ? "#ffdd00" : "#" + level.Colour,
      thumb = level.Thumb,
      thumb_mark = level.ThumbMark,
      bg = level.Bg
      }).ToListAsync();
      return levels;
    }

    public async Task updateToken(ulong uid, string token)
    {
      var nowtime = (int)((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
      var expiretime = nowtime + (60 * 60 * 24 * 300);
      var user = await context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == uid);
      if (user == null) return ;
      user.LastLoginTime = nowtime;
      user.LastLoginIp = "127.0.0.1";

      var isok = await context.CmfUserTokens.FirstOrDefaultAsync(x => x.UserId == uid);
      if (isok == null) return;
      isok.Token = token;
      isok.ExpireTime = (uint)expiretime;
      isok.CreateTime = (uint)nowtime;

      await context.SaveChangesAsync();

      TokenInfo token_info = new TokenInfo()
      {
        token = token,
        uid = uid,
        expiretime = expiretime
      };


      await cacheManager.SetCacheString("token_" + uid, JsonConvert.SerializeObject(token_info));
    }
    public async Task<Guide> getGuide()
    {
      var optionValue = await context.CmfOptions.Where(x => x.OptionName == "guide").Select(x => x.OptionValue).FirstOrDefaultAsync();

      if (optionValue == null) optionValue = "0";

      var config = JsonConvert.DeserializeObject<dynamic>(optionValue);

      var where = ((int)config.type) == 0 ? false : true;

      var listImgs = await context.CmfGuides.Where(x => x.Type == where).Select(guide => new ImgLink
      {

        thumb = "http://qiniu.vemo.tv/" + guide.Thumb,
        href = Utils.UrlDecode(guide.Href),
      }).ToListAsync();


      Guide guildes = new Guide()
      {
        list = listImgs,
        time = config.time,
        type = config.type,
        @switch = config.@switch
      };

      return guildes;
    }
    public async Task<sbyte> isAttention(ulong uid, ulong touid)
    {

      var like = await context.CmfUserAttentions.AnyAsync(x => x.Uid == uid && x.Touid == touid);
      if (like)
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
      var like = await context.CmfVideoLikes.AnyAsync(x => x.Uid == uid && x.Videoid == videoid);
      if (like)
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
      var like = await context.CmfVideoSteps.AnyAsync(x => x.Uid == uid && x.Videoid == videoid);

      if (like)
      {
        return 1;

      }
      else
      {
        return 0;
      }

    }
    public async Task<string> isBlack(ulong uid, ulong touid)
    {

      var isexist = await context.CmfUserBlacks.AnyAsync(x => x.Uid.Equals(uid) && x.Touid.Equals(touid));
      if (!isexist) return "0";
      return "1";
    }
    public async Task<int> getFollows(ulong uid)
    {
      return await context.CmfUserAttentions.Where(x => x.Uid == uid).CountAsync();
    }
    public async Task<int> getLives(ulong uid)
    {


      var count1 = await context.CmfLives.Where(x => x.Islive == 1 && x.Uid == uid).CountAsync();
      var count2 = await context.CmfLiveRecords.Where(x => x.Uid == uid).CountAsync();

      return count1 + count2;
    }
    public async Task<Vip> getUserVip(ulong uid)
    {

      Vip vip = new Vip() { type = "0" };
      var nowtime = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
      var key = "vip_" + uid;


      var isexits = cacheManager.GetCacheString(key);
      if (isexits == null || isexits == "")
      {
        var vipUser = await context.CmfVipUsers.FirstOrDefaultAsync(x => x.Uid == (int)uid);
        if (vipUser == null || vipUser.Uid == 0)
        {
          await cacheManager.DeleteCache(key);
        }
        else
        {
          await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(vipUser));
        }
      }
      else
      {
        CmfVipUser cmfVipUser = JsonConvert.DeserializeObject<CmfVipUser>(isexits) ?? new CmfVipUser();
        if (cmfVipUser.Endtime <= nowtime)
        {
          return vip;
        }
        vip.type = "1";
      }
      return vip;
    }
    public async Task<Liang> getUserLiang(ulong uid)
    {
      Liang liang = new Liang() { name = "0" };
      var nowtime = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
      var key = "liang_" + uid;


      var isexits = cacheManager.GetCacheString(key);
      if (isexits == null || isexits == "")
      {
        var cmfLiang = await context.CmfLiangs.FirstOrDefaultAsync(x => x.Status.Equals(1) && x.State.Equals(1) && (x.Uid == (int)uid));
        if (cmfLiang != null)
        {
          await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(cmfLiang));
        }
        else
        {
          await cacheManager.DeleteCache(key);
        }

      }
      else
      {
        liang = JsonConvert.DeserializeObject<Liang>(isexits) ?? new Liang();
      }
      return liang;
    }
    public async Task<int> getFans(ulong uid)
    {
      return await context.CmfUserAttentions.Where(x => x.Touid == uid).CountAsync();
    }
    public async Task<BaseInfo> getInfo(ulong uid)
    {
      var info = await context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == uid);
      if (info != null)
      {
        var baseInfo = new BaseInfo();
        baseInfo.id = uid;
        baseInfo.user_nicename = info.UserNicename;
        baseInfo.sex = info.Sex;
        baseInfo.signature = info.Signature;
        baseInfo.coin = info.Coin;
        baseInfo.votes = info.Votes;
        baseInfo.consumption = info.Consumption;
        baseInfo.votestotal = info.Votestotal;
        baseInfo.province = info.Province;
        baseInfo.city = info.City;
        long birthday = info.Birthday ?? 0;
        baseInfo.birthday = Utils.UnixTimeToDateTime(birthday).ToString("yyyy-MM-dd");
        baseInfo.location = info.Location;
        baseInfo.avatar = info.Avatar;
        baseInfo.avatar_thumb = info.AvatarThumb;
        baseInfo.level =  getLevel(info.Consumption).Result;
        baseInfo.level_anchor =  getLevelAnchor(info.Votestotal).Result;
        baseInfo.lives =  getLives(uid).Result;
        var foll =  getFollows(uid).Result;
        baseInfo.follows = foll.ToString();
        var fanl =  getFans(uid).Result;
        baseInfo.fans = fanl.ToString();
        baseInfo.vip =  getUserVip(uid).Result;
        baseInfo.liang = await getUserLiang(uid);
        return baseInfo;
      }
      return new BaseInfo();

    }
    public async Task<int> checkShopIsPass(ulong uid)
    {

      var rs = await context.CmfShopApplies.FirstOrDefaultAsync(x => x.Uid == uid);
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
    public async Task<int> checkPaidProgramIsPass(ulong uid)
    {

      var info = await context.CmfPaidprogramApplies.FirstOrDefaultAsync(x => x.Uid == (int)uid);

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

    public async Task<string> PrivateKeyA(string host, string stream, int type)
    {
      var configpri = await getConfigPri();
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
      var configpri = await getConfigPri();
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
        var configpub = await getConfigPub();
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
      var configpri = await getConfigPri();
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
      var configpri = await getConfigPri();
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
        var configpub = await getConfigPub();
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
      var configpri = await getConfigPri();
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
      var configpri = await getConfigPri();
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
      var configpri = await getConfigPri();
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


  }
}
