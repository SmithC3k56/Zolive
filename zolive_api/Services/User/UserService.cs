using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using zolive_api.Models.Buyer;
using zolive_api.Models.Paidprogram;
using zolive_api.Models.User;
using zolive_api.Models.Video;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db.Models;

namespace zolive_api.Services.User
{
  public class UserService : IUserService
  {
    public readonly newliveContext context;
    public readonly CacheManager cacheManager = new CacheManager();
    public Random rnd = new Random();
    public readonly IHomeService homeService;
    public readonly ICommonService _commonService;
    public readonly IVideoService videoService;


    public UserService(newliveContext context, ICommonService commonService, IHomeService homeService, IVideoService videoService)
    {
      this._commonService = commonService;
      this.context = context;
      this.homeService = homeService;
      this.videoService = videoService;
    }

    public async Task<GetCdnRecordModel?> getCdnRecord(ulong id)
    {
      var result = await context.CmfLiveRecords.Where(x => x.Id == id).Select(x => new GetCdnRecordModel
      {
        id = x.Id,
        starttime = x.Starttime,
        endtime = x.Endtime,
        stream = x.Stream,
        video_url = x.VideoUrl
      }).FirstOrDefaultAsync();
      if (result != null && string.IsNullOrEmpty(result.video_url))
      {
        var configpri = await _commonService.getConfigPri();
        var cdn_switch = configpri.cdn_switch;
        var url = "";
        if (cdn_switch == "1")
        {
          url = await alicdn(result);
        }
        result.video_url = url;
      }
      return result;

    }
    public async Task<string> alicdn(GetCdnRecordModel data)
    {
      var video_url = "";
      var configpri = await _commonService.getConfigPri();

      var access_key_id = configpri.aliy_key_id.Value;
      var access_key_secret = configpri.aliy_key_secret.Value;
      var DomainName = configpri.pull_url.Value;
      var AppName = "5showcam";

      if (string.IsNullOrEmpty(access_key_id) || string.IsNullOrEmpty(access_key_secret) || string.IsNullOrEmpty(DomainName))
      {
        return video_url;
      }

      var live_starttime = data.starttime - 200;
      var live_endtime = data.endtime + 200;
      var StartTime = Utils.UnixTimeToDateTime(live_starttime).ToString(@"yyyy-MM-d\TH:mm:s\Z");
      var EndTime = Utils.UnixTimeToDateTime(live_endtime).ToString(@"yyyy-MM-d\TH:mm:s\Z");
      var StreamName = data.stream;
      var action = "DescribeLiveStreamRecordIndexFiles";
      var specialParameter = new Dictionary<string, string>();
      specialParameter.Add("AccessKeyId", access_key_id);
      specialParameter.Add("Action", action);
      specialParameter.Add("DomainName", DomainName);
      specialParameter.Add("AppName", AppName);
      specialParameter.Add("StreamName", StreamName ?? "");
      specialParameter.Add("StartTime", StartTime);
      specialParameter.Add("EndTime", EndTime);
      var parameter = setParameter(specialParameter);
      var url = getStringToSign(parameter, access_key_secret);
      var res_arr = await curl_get(url);
      if (res_arr["RecordIndexInfoList"]["RecordIndexInfo"] == null)
      {
        return video_url;
      }
      video_url = res_arr["RecordIndexInfoList"]["RecordIndexInfo"][0]["RecordUrl"];
      var liveRecord = await context.CmfLiveRecords.FirstOrDefaultAsync(x => x.Id == data.id);
      if (liveRecord != null)
      {
        liveRecord.VideoUrl = video_url;
        context.CmfLiveRecords.Update(liveRecord);
      }
      await context.SaveChangesAsync();
      return video_url;
    }
    public async Task<JObject> curl_get(string url)
    {
      var httpClient = new HttpClient();
      var response = await httpClient.GetAsync(url);
      var dataFromServer = await response.Content.ReadAsStringAsync();
      JObject json = JObject.Parse(dataFromServer);
      return json;
    }
    public string getStringToSign(Dictionary<string, string> parameter, string access_key_secret)
    {
      parameter = parameter.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
      List<string> str = new List<string>();
      foreach (var v in parameter)
      {
        str.Add(v.Key.UrlEncode() + "=" + v.Value.UrlEncode());
      }
      var ss = "";
      for (var count = 0; count < str.Count; count++)
      {
        if (count < str.Count - 1)
        {
          ss += str[count] + "&";
        }
        else
        {
          ss += str[count];
        }
      }
      var StringToSign = "GET" + "&" + Utils.UrlEncode("/") + "&" + Utils.UrlEncode(ss);
      var signature = Utils.sign(StringToSign, access_key_secret + "&");
      var url = "https://live.aliyuncs.com/?" + ss + "&Signature=" + Utils.UrlEncode(signature);
      return url;
    }
    public Dictionary<string, string> setParameter(Dictionary<string, string> specialParameter)
    {
      var Timestamp = DateTime.UtcNow.ToString(@"yyyy-MM-d\TH:mm:s\Z");
      var signature_nonce = "";
      for (var i = 0; i < 14; i++)
      {
        signature_nonce += Utils.rand(0, 9);
      }
      var publicParameter = new Dictionary<string, string>();
      publicParameter.Add("Format", "JSON");
      publicParameter.Add("Version", "2016-11-01");
      publicParameter.Add("SignatureMethod", "HMAC-SHA1");
      publicParameter.Add("Timestamp", Timestamp);
      publicParameter.Add("SignatureVersion", "1.0");
      publicParameter.Add("SignatureNonce", signature_nonce);

      foreach (var item in specialParameter)
      {
        publicParameter.Add(item.Key, item.Value);
      }
      return publicParameter;
    }

    public async Task<IList<HandleGoodsListModel>> getGoodsList(ulong uid, int status, int p)
    {
      return await handleGoodsList(uid, status, p);
    }

    public async Task<IList<HandleGoodsListModel>> handleGoodsList(ulong uid, int status, int p)
    {
      if (p < 1) p = 1;
      var nums = 50;
      var start = (p - 1) * nums;
      var list = await context.CmfShopGoods.Where(x => x.Uid == uid && x.Status == status).Select(x => new HandleGoodsListModel
      {
        id = x.Id,
        name = x.Name,
        thumb = x.Thumbs.Split(new char[] { ',' })[0],
        sale_nums = x.SaleNums,
        price = x.Type == 1 ? x.PresentPrice : (decimal.Parse((JsonConvert.DeserializeObject<Dictionary<string, string>>(x.Specs) ?? new Dictionary<string, string>())["price"])),
        hits = x.Hits,
        issale = x.Issale,
        type = x.Type,
        original_price = x.OriginalPrice,
        specs = x.Type == 1 ? new Dictionary<string, string>() : (JsonConvert.DeserializeObject<Dictionary<string, string>>(x.Specs) ?? new Dictionary<string, string>()),
        status = x.Status,
        live_isshow = x.LiveIsshow
      }).OrderByDescending(x => x.id).Skip(start).Take(nums).ToListAsync();

      if (list == null)
      {
        return new List<HandleGoodsListModel>();
      }
      return list;


    }

    public async Task<IList<UserInfo>> getFollowsList(string lan, ulong uid, ulong touid, int p)
    {
      if (p < 1) p = 1;
      var pnum = 50;
      var start = (p - 1) * pnum;
      var touids = await context.CmfUserAttentions.Where(x => x.Uid == touid).Select(x => x.Touid).Skip(start).Take(pnum).ToArrayAsync();
      var result = new List<UserInfo>();
      foreach (var v in touids)
      {
        var userinfo = await homeService.getUserInfo(lan, v);
        if (userinfo != null)
        {
          if (uid == touid)
          {
            userinfo.isattention = "1";
          }
          else
          {
            userinfo.isattention = (await _commonService.isAttention(uid, v)).ToString();

          }
          result.Add(userinfo);
        }
        else
        {
          var userAttention = await context.CmfUserAttentions.FirstOrDefaultAsync(x => x.Uid == touid || x.Touid == touid);
          if (userAttention != null)
          {
            context.CmfUserAttentions.Remove(userAttention);
            await context.SaveChangesAsync();
          }
        }
      }
      return result;
    }
    public async Task<IList<UserInfo>> getFansList(string lan, ulong uid, ulong touid, int p)
    {
      if (p < 1) p = 1;
      var pnum = 50;
      var start = (p - 1) * pnum;
      var touids = await context.CmfUserAttentions.Where(x => x.Touid == touid).Select(x => x.Uid).Skip(start).Take(pnum).ToListAsync();
      var rs = new List<UserInfo>();
      foreach (var v in touids)
      {
        var obj = await homeService.getUserInfo(lan, v);
        if (obj != null)
        {
          obj.isattention = (await _commonService.isAttention(uid, v)).ToString();
          rs.Add(obj);
        }
        else
        {
          var userAttention = await context.CmfUserAttentions.FirstOrDefaultAsync(x => x.Uid == v || x.Touid == v);
          if (userAttention != null)
          {
            context.CmfUserAttentions.Remove(userAttention);
            await context.SaveChangesAsync();
          }
        }
      }
      return rs;

    }
    public async Task<int> setUserLabel(ulong uid, ulong touid, string labels)
    {
      try
      {
        var nowtime = Utils.time();
        var isexist = await context.CmfLabelUsers.FirstOrDefaultAsync(x => x.Uid == uid && x.Touid == touid);
        if (isexist != null)
        {
          isexist.Label = labels;
          isexist.Uptime = nowtime;
          context.CmfLabelUsers.Update(isexist);
        }
        else
        {
          var data = new CmfLabelUser()
          {
            Uid = uid,
            Touid = touid,
            Label = labels,
            Addtime = nowtime,
            Uptime = nowtime
          };
          await context.CmfLabelUsers.AddAsync(data);
        }
        await context.SaveChangesAsync();
        return 1;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return 0;
      }
    }
    public async Task<CmfLabelUser?> getUserLabel(ulong uid, ulong touid)
    {
      return await context.CmfLabelUsers.FirstOrDefaultAsync(x => x.Uid == uid && x.Touid == touid); ;
    }
    public async Task<int> setBlack(ulong uid, ulong touid)
    {
      var isexist = await context.CmfUserBlacks.FirstOrDefaultAsync(x => x.Uid == uid && x.Touid == touid);
      if (isexist != null)
      {
        context.CmfUserBlacks.Remove(isexist);
        await context.SaveChangesAsync();
        return 0;
      }
      else
      {
        var userAttention = await context.CmfUserAttentions.FirstOrDefaultAsync(x => x.Uid == uid && x.Touid == touid);
        if (userAttention != null)
        {
          context.CmfUserAttentions.Remove(userAttention);
        }
        var userBlack = new CmfUserBlack()
        {
          Uid = uid,
          Touid = touid
        };
        context.CmfUserBlacks.Add(userBlack);
        await context.SaveChangesAsync();
        return 1;
      }
    }
    public async Task<int> setAttent(ulong uid, ulong touid)
    {
      var isexist = await context.CmfUserAttentions.FirstOrDefaultAsync(x => x.Uid == uid && x.Touid == touid);
      if (isexist != null)
      {
        context.CmfUserAttentions.Remove(isexist);
        await context.SaveChangesAsync();
        return 0;
      }
      else
      {
        var userBlack = await context.CmfUserBlacks.FirstOrDefaultAsync(x => x.Uid == uid && x.Touid == touid);
        if (userBlack != null)
        {
          context.CmfUserBlacks.Remove(userBlack);
        }
        var userAttention = new CmfUserAttention()
        {
          Uid = uid,
          Touid = touid
        };
        await context.CmfUserAttentions.AddAsync(userAttention);
        await context.SaveChangesAsync();
        return 1;
      }
    }

    public async Task<int> updatePass(ulong uid, string oldPass, string newPass)
    {
      var userinfo = await context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == uid);
      if (userinfo == null) return 0;
      oldPass = Utils.setPass(oldPass);
      if (userinfo.UserPass != oldPass)
      {
        return 1003;
      }
      newPass = Utils.setPass(newPass);
      userinfo.UserPass = newPass;
      context.CmfUsers1.Update(userinfo);
      await context.SaveChangesAsync();
      return 1;
    }
    public async Task<IList<GetPerSettingModel>> getPerSetting()
    {
      var list = await context.CmfPortalPosts.Where(x => x.Type == 2).OrderByDescending(x => x.ListOrder).Select(v => new GetPerSettingModel
      {
        id = 0,
        name = v.PostTitle,
        thumb = "",
        href = "http://zolive.m99.club/portal/page/index?id=" + v.Id,
      }).ToListAsync();

      return list;
    }
    public async Task<getProfitModel> getProfit(string lan, ulong uid)
    {

      var rs = await context.CmfUsers1.Where(x => x.Id == uid).Select(x => new getProfitModel
      {
        votes = x.Votes,
        votestotal = x.Votestotal
      }).FirstOrDefaultAsync();

      if (rs != null)
      {
        var config = await _commonService.getConfigPri();
        rs.cash_rate = decimal.Parse(config.cash_rate.Value);
        var cash_start = config.cash_start;
        var cash_end = config.cash_end;
        var cash_max_times = config.cash_max_times;
        rs.total = Math.Floor(rs.votes / rs.cash_rate);
        rs.tips = "";
        if (cash_max_times != null)
        {
          rs.tips = "每月" + cash_start.Value + "-" + cash_end.Value + "号可进行提现申请，每月只可提现" + cash_max_times.Value + "次";
          if (lan == "En") rs.tips = "Please withdraw between " + cash_start.Value + "-" + cash_end.Value + " of every month, and " + cash_max_times.Value + "times at most. ";
          if (lan == "Nam") rs.tips = "Hàng tháng " + cash_start.Value + "-" + cash_end.Value + " có thể rút tiền, và tối đa " + cash_max_times.Value + " lần. ";
        }
        else
        {
          rs.tips = "每月" + cash_start.Value + "-" + cash_end.Value + "号可进行提现申请";
          if (lan == "En") rs.tips = "Please withdrawl within" + cash_start.Value + "-" + cash_end.Value + ".";
          if (lan == "Nam") rs.tips = "Hàng tháng " + cash_start.Value + "-" + cash_end.Value + " có thể rút tiền.";
        }

        return rs;
      }
      else
      {
        return new getProfitModel();
      }

    }
    public async Task<InfoBonus> LoginBonus(ulong uid)
    {
      InfoBonus rs = new InfoBonus();
      var configpri = await _commonService.getConfigPri();
      if (configpri.bonus_switch == null) return rs;

      rs.bonus_switch = configpri.bonus_switch;
      var key = "loginbonus";

      var list = cacheManager.GetCacheString(key);
      if (list == null || list.Trim() == "")
      {
        rs.bonus_list = await context.CmfLoginbonus.Select(x => new BonusList
        {
          day = x.Day,
          coin = x.Coin
        }).ToListAsync();
        if (rs.bonus_list.Count > 0)
        {
          await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(rs.bonus_list));
        }
      }
      else
      {
        rs.bonus_list = JsonConvert.DeserializeObject<List<BonusList>>(list) ?? new List<BonusList>();
      }


      var signinfodb = await context.CmfUserSigns.Where(x => x.Uid == uid).Select(x => new InfoBonus
      {
        bonus_day = x.BonusDay,
        bonus_time = x.BonusTime,
        count_day = x.CountDay
      }).FirstOrDefaultAsync();

      if (signinfodb == null)
      {
        rs.bonus_day = 0;
        rs.bonus_time = 0;
        rs.count_day = 0;
      }
      else
      {
        rs.bonus_day = signinfodb.bonus_day;
        rs.bonus_time = signinfodb.bonus_time;
        rs.count_day = signinfodb.count_day;
      }

      if (rs.count_day >= 7)
      {
        rs.count_day = 0;
      }

      var nowtime = ((DateTimeOffset)(DateTime.Now)).ToUnixTimeSeconds();

      if (nowtime > rs.bonus_time)
      {
        rs.bonus_day = rs.count_day;
        if (rs.bonus_day == 0)
        {
          rs.bonus_day += 1;
        }
      }
      else
      {
        rs.bonus_day = 0;
      }

      return rs;
    }
    public async Task<int> setShopCash(ulong uid, int accountId, ulong money)
    {
      try
      {
        var configpri = await _commonService.getConfigPri();
        var balance_cash_start = int.Parse(configpri.balance_cash_start.Value);
        var balance_cash_end = int.Parse(configpri.balance_cash_end.Value);
        var balance_cash_max_times = int.Parse(configpri.balance_cash_max_times.Value);

        var day = DateTime.Now.Day;
        if (day < balance_cash_start || day > balance_cash_end)
        {
          return 1005;
        }

        var month_end = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: 1).AddMonths(1));
        var month_start = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: 1));
        if (balance_cash_max_times != 0)
        {
          var count = await context.CmfUserBalanceRecords.CountAsync(x => x.Uid == (long)uid && x.Addtime > month_start && x.Addtime < month_end);
          if (count >= balance_cash_max_times)
          {
            return 1006;
          }
        }
        var accountinfo = await context.CmfCashAccounts.FirstOrDefaultAsync(x => x.Id == accountId && x.Uid == uid);
        if (accountinfo == null)
        {
          return 1007;
        }
        var balance_cash_min = ulong.Parse(configpri.balance_cash_min.Value);
        if (money < balance_cash_min)
        {
          return 1004;
        }
        var ifok = await context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == uid && x.Balance >= money);
        if (ifok == null)
        {
          return 1001;
        }
        var data = new CmfUserBalanceCashrecord()
        {
          Addtime = Utils.DateTimeToLong(DateTime.Now),
          Uid = uid,
          Money = money,
          Status = false,
          Type = accountinfo.Type,
          Orderno = uid + "_" + Utils.DateTimeToLong(DateTime.Now) + Utils.rand(100, 999),
          AccountBank = accountinfo.AccountBank,
          Account = accountinfo.Account,
          Name = accountinfo.Name,
        };


        await context.CmfUserBalanceCashrecords.AddAsync(data);
        await context.SaveChangesAsync();
      }
      catch (Exception e)
      {
        return 1002;
      }
      return 1;
    }

    public async Task<IList<CmfCashAccount>> getUserAccountList(ulong uid)
    {
      return await context.CmfCashAccounts.Where(x => x.Uid == uid).OrderByDescending(x => x.Addtime).ToListAsync();
    }

    public async Task<GetAuthInfoClass> getAuthInfo(ulong uid)
    {
      var info = await context.CmfUserAuths.Where(x => x.Uid == uid && x.Status).Select(x => new GetAuthInfoClass
      {
        real_name = x.RealName,
        cer_no = x.CerNo
      }).FirstOrDefaultAsync();

      return info;
    }
    public async Task<IList<getChargeRulesModel>> getChargeRules()
    {
      var rules = await context.CmfChargeRules.OrderBy(x => x.ListOrder).Select(x => new getChargeRulesModel
      {
        id = x.Id,
        coin = x.Coin,
        coin_ios = x.CoinIos,
        money = x.Money,
        product_id = x.ProductId,
        give = x.Give
      }).ToListAsync();

      return rules;
    }
    public async Task<getBalanceModel> getBalance(ulong uid)
    {
      return await context.CmfUsers1.Where(x => x.Id == uid).Select(x => new getBalanceModel
      {
        coin = x.Coin,
        score = x.Score
      }).FirstOrDefaultAsync() ?? new getBalanceModel();
    }
    public async Task<bool> checkName(ulong uid, string name)
    {
      var isexit = await context.CmfUsers1.AnyAsync(x => x.Id != uid && x.UserNicename == name);
      if (!isexit)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public async Task<int> sensitiveField(string field)
    {
      if (!string.IsNullOrEmpty(field))
      {
        var configpri = await _commonService.getConfigPri();
        var sensitive_words = configpri.sensitive_words;
        var sensitive = sensitive_words.Value.Split(",");

        foreach (var v in sensitive)
        {
          if (v != "")
          {
            if (field.Contains(v))
            {
              return 1001;
            }
          }
        }
      }
      return 1;
    }
    public async Task<bool> userUpdate(ulong uid, string fields)
    {
      try
      {
        await cacheManager.DeleteCache("userinfo_" + uid);
        if (fields == null) return false;
        var rs = await context.CmfUsers1.FirstOrDefaultAsync(x => x.Id == uid);
        if (rs == null) return false;

        var url = Utils.UrlDecode(fields);
        var json_decode_field = JsonConvert.DeserializeObject<dynamic>(url) ?? new List<dynamic>();
        foreach (var field in json_decode_field)
        {
          switch (field.Name)
          {
            case "user_nicename":
              rs.UserNicename = field.Value.Value;
              break;
            case "sex":
              rs.Sex = sbyte.Parse(field.Value.Value);
              break;
            case "signature":
              rs.Signature = field.Value.Value;
              break;
            case "birthday":
              rs.Birthday = Utils.DateTimeToLong(DateTime.Parse(field.Value.Value));
              break;
            case "location":
              rs.Location = field.Value.Value;
              break;
            case "city":
              rs.City = field.Value.Value;
              break;
            default:
              break;
          }
          context.Update(rs);
          await context.SaveChangesAsync();
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
      return true;
    }
    public async Task<int> countGoods(ulong uid, int status)
    {
      return await context.CmfShopGoods.CountAsync(x => x.Uid == uid && x.Status == status); ;
    }
    public async Task<IList<LiveRecordModel>> getLiverecord(ulong touid, int p)
    {
      if (p < 1) p = 1;
      var pnum = 50;
      var start = (p - 1) * pnum;

      return await context.CmfLiveRecords.Where(x => x.Uid == touid).OrderByDescending(x => x.Id).Skip(start).Take(pnum).Select(v => new LiveRecordModel
      {
        datestarttime = Utils.UnixTimeToDateTime(v.Starttime).ToString("yyyy.MM.dd"),
        dateendtime = Utils.UnixTimeToDateTime(v.Endtime).ToString("yyyy.MM.dd"),
        title = v.Title,
        city = v.City,
        nums = v.Nums,
        id = v.Id,
        uid = v.Uid,
        lenth = Utils.getSeconds((v.Endtime - v.Starttime), 0)
      }).ToListAsync(); ;
    }
    public async Task<getShopModel?> getShop(string lan, ulong uid)
    {
      var key = "shop" + uid.ToString();
      var shopInfo = new getShopModel();
      var shop_info = cacheManager.GetCacheString(key);
      if (String.IsNullOrEmpty(shop_info))
      {
        var rs = await context.CmfShopApplies.FirstOrDefaultAsync(x => x.Uid == uid);

        if (rs != null)
        {
          shopInfo.uid = rs.Uid;
          shopInfo.sale_nums = rs.SaleNums.ToString();
          shopInfo.quality_points = rs.QualityPoints.ToString();
          shopInfo.service_points = rs.ServicePoints.ToString();
          shopInfo.certificate = rs.Certificate;
          shopInfo.other = rs.Other;
          shopInfo.service_phone = rs.ServicePhone;
          shopInfo.province = rs.Province;
          shopInfo.city = rs.City;
          shopInfo.area = rs.Area;

          await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(shopInfo));
        }
        else
        {
          return null;
        }

      }
      else
      {
        shopInfo = JsonConvert.DeserializeObject<getShopModel>(shop_info);
      }
      if (shopInfo == null) return null;
      shopInfo.goods_nums = countGoods(uid, 1).Result;
      var userinfo = await homeService.getUserInfo(lan, uid);
      shopInfo.user_nicename = userinfo.user_nicename;

      shopInfo.name = "Cửa hàng của " + userinfo.user_nicename;
      if (lan == "En")
      {
        shopInfo.name = userinfo.user_nicename + "'s Shop";
      }
      if (shopInfo.certificate != null) shopInfo.certificate = Utils.get_upload_path(shopInfo.certificate);

      if (shopInfo.other != null) shopInfo.other = Utils.get_upload_path(shopInfo.other);

      shopInfo.sale_nums = Utils.NumberFormat(lan, decimal.Parse(shopInfo.sale_nums ?? "0"));
      shopInfo.avatar = Utils.get_upload_path(userinfo.avatar);
      shopInfo.composite_points = (float.Parse(shopInfo.quality_points) + float.Parse(shopInfo.service_points) + (long.Parse(shopInfo.express_points) / 3)).ToString("D1");
      shopInfo.composite_points = shopInfo.composite_points == "0" ? "0.0" : shopInfo.composite_points;
      var m = "Chưa ghi điểm";
      if (lan == "En") m = "No score yet";

      shopInfo.quality_points = float.Parse(shopInfo.quality_points) > 0 ? shopInfo.quality_points : m;
      shopInfo.service_points = float.Parse(shopInfo.service_points) > 0 ? shopInfo.service_points : m;
      shopInfo.express_points = long.Parse(shopInfo.express_points) > 0 ? shopInfo.express_points : m;


      shopInfo.address_format = shopInfo.city + " " + shopInfo.area;
      shopInfo.certificate_desc = "";
      return shopInfo;

    }

    public async Task<IList<VideoModel>> getHomeVideo(string lan, ulong uid, ulong touid, int p)
    {
      if (p < 1) p = 1;
      var nums = 21;
      var start = (p - 1) * nums;
      //List<CmfVideo> video = new List<CmfVideo>();
      List<VideoModel> video = new List<VideoModel>();
      if (uid == touid)
      {
        video = await context.CmfVideos.Where(x => x.Uid == uid && x.Isdel == false && x.Status == true && x.IsAd == false).OrderByDescending(x => x.Addtime).Skip(start).Take(nums).Select(x => new VideoModel
        {
          id = x.Id,
          uid = x.Uid,
          title = x.Title,
          thumb = x.Thumb,
          thumb_s = x.ThumbS,
          href = x.Href,
          href_w = x.HrefW,
          likes = x.Likes.ToString(),
          views = x.Views,
          comments = x.Comments.ToString(),
          steps = x.Steps.ToString(),
          shares = x.Shares,
          addtime = x.Addtime.ToString(),
          lat = x.Lat,
          lng = x.Lng,
          city = x.City,
          music_id = x.MusicId,
          is_ad = x.IsAd,
          ad_url = x.AdUrl,
          type = x.Type,
          goodsid = x.Goodsid,
          classid = x.Classid,
          ad_endtime = x.AdEndtime
        }).ToListAsync();
      }
      else
      {
        var videoids_s = await getVideoBlack(uid);
        video = await context.CmfVideos.Where(x => !videoids_s.Contains(x.Id) && x.Uid == touid && x.Isdel == false && x.Status == true && x.IsAd == false).OrderByDescending(x => x.Addtime).Skip(start).Take(nums).Select(x => new VideoModel
        {
          id = x.Id,
          uid = x.Uid,
          title = x.Title,
          thumb = x.Thumb,
          thumb_s = x.ThumbS,
          href = x.Href,
          href_w = x.HrefW,
          likes = x.Likes.ToString(),
          views = x.Views,
          comments = x.Comments.ToString(),
          steps = x.Steps.ToString(),
          shares = x.Shares,
          addtime = x.Addtime.ToString(),
          lat = x.Lat,
          lng = x.Lng,
          city = x.City,
          music_id = x.MusicId,
          is_ad = x.IsAd,
          ad_url = x.AdUrl,
          type = x.Type,
          goodsid = x.Goodsid,
          classid = x.Classid,
          ad_endtime = x.AdEndtime
        }).ToListAsync();
      }
      for (var count = 0; count < video.Count; count++)
      {
        video[count] = await videoService.handleVideo(lan, uid, video[count]);
      }
      return video;
    }
    public async Task<int> getWeekContribute(ulong uid, long starttime = 0, long endtime = 0)
    {
      var contribute = 0;
      List<int> actionList = new List<int>() { 1, 10 };
      if (uid > 0)
      {
        if (starttime > 0)
        {
          contribute = await context.CmfUserCoinrecords.Where(x => actionList.Contains(x.Action) && x.Uid == uid && x.Addtime > starttime).SumAsync(x =>(int) x.Totalcoin);
        }
        if (endtime > 0)
        {
          contribute = await context.CmfUserCoinrecords.Where(x => actionList.Contains(x.Action) && x.Uid == uid && x.Addtime > endtime).SumAsync(x =>(int) x.Totalcoin);
        }
        if (endtime <= 0 && starttime <= 0)
        {
          contribute = await context.CmfUserCoinrecords.Where(x => actionList.Contains(x.Action) && x.Uid == uid).SumAsync(x =>(int)( x.Totalcoin));
        }

      }
      return contribute;
    }
    public async Task<UserInfo2> getUserInfo2(string? lan, ulong uid, int type = 0)
    {
      UserInfo2 info = new UserInfo2();
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
        info.issuper = false;
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
            info.issuper = rs.Issuper;
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
            info.issuper = false;
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
          info = JsonConvert.DeserializeObject<UserInfo2>(user) ?? new UserInfo2();
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
    public async Task<IList<UserInfo2>> getGuardList(string lan, ulong touid)
    {
      var liveuid = touid;
      var nowtime = Utils.time();
      var w = Utils.GetWeekNumberOfMonth(DateTime.Now);
      var first = 1;
      var day = (DateTime.Now.Day - (w != 0 ? (w - first) : 6));
      var week_start = Utils.DateTimeToLong(new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: day));
      var week = new DateTime(year: DateTime.Now.Year, month: DateTime.Now.Month, day: day, hour: 0, minute: 0, second: 0);

      var week_end = Utils.DateTimeToLong(week.AddDays(7));
      var list = await context.CmfGuardUsers.Where(x => x.Liveuid == liveuid && x.Endtime > nowtime).Select(x => new
      {
        uid = x.Uid,
        type = x.Type
      }).ToListAsync();

      List<int> order = new List<int>();
      List<int> order2 = new List<int>();
      List<UserInfo2> rs = new List<UserInfo2>();

      foreach (var v in list)
      {
        var userinfo = await getUserInfo2(lan, v.uid);

        userinfo.type = v.type;
        userinfo.contribute = await getWeekContribute(v.uid, week_start, week_end);
        order.Add(userinfo.contribute);
        order2.Add(userinfo.type);
        rs.Add(userinfo);
      }
      order.Sort();
      order2.Sort();
      rs.Sort();

      return rs;
    }
    public async Task<ulong[]> getVideoBlack(ulong uid)
    {
      return await context.CmfVideoBlacks.Where(x => x.Uid == uid).Select(x => x.Videoid).ToArrayAsync();
    }
    public async Task<UserInfo> getUserHome(string lan, ulong uid, ulong touid)
    {
      var info = await homeService.getUserInfo(lan, touid);
      if (info == null) return new UserInfo();

      info.follows = (await _commonService.getFollows(touid)).ToString();
      info.fans = (await _commonService.getFans(touid)).ToString();
      info.isattention = (await _commonService.isAttention(uid, touid)).ToString();
      info.isblack = await _commonService.isBlack(uid, touid);
      info.isblack2 = await _commonService.isBlack(touid, uid);

      info.islive = 0;
      var isexist = await context.CmfLives.AnyAsync(x => x.Uid == touid && x.Islive == 1);
      if (isexist) info.islive = 1;
      int[] arr = { 1, 2 };
      var rs = await context.CmfUserVoterecords.Where(x => arr.Contains(x.Action) && x.Uid == touid).Take(3).GroupBy(x => x.Fromid).Select(g => new
      {
        uid = g.Key,
        total = g.Sum(x => x.Total)
      }
      ).OrderByDescending(x => x.total).ToListAsync();
      foreach (var recordss in rs)
      {
        var userinfo = await homeService.getUserInfo(lan, (ulong)recordss.uid);
        info.contribute = new List<ContributeModel>();
        info.contribute.Add(new ContributeModel()
        {
          uid = (ulong)recordss.uid,
          total = recordss.total,
          avatar = userinfo.avatar,
          user_nicename = userinfo.user_nicename
        });
      }

      if (uid == touid)
      {
        info.videonums = await context.CmfVideos.CountAsync(x => x.Uid == uid && x.Isdel == false && x.Status == true && x.IsAd == false);
      }
      else
      {
        var videoids_s = await getVideoBlack(uid);
        info.videonums = await context.CmfVideos.CountAsync(x => !videoids_s.Contains(x.Id) && x.Uid == touid && x.Isdel == false && x.Status == true && x.IsAd == false);
      }

      if (uid == touid)
      {
        info.dynamicnums = await context.CmfDynamics.CountAsync(x => x.Uid == uid && x.Isdel == false && x.Status == true);
      }
      else
      {
        info.dynamicnums = await context.CmfDynamics.CountAsync(x => x.Uid == touid && x.Isdel == false && x.Status == true);
      }
      info.livenums = await context.CmfLiveRecords.CountAsync(x => x.Uid == touid);

      info.liverecord = await context.CmfLiveRecords.Where(x => x.Uid == touid).Select(x => new LiveRecordModel
      {
        id = x.Id,
        uid = x.Uid,
        nums = x.Nums,
        datestarttime = Utils.UnixTimeToDateTime(x.Starttime).ToString("yyyy.MM.dd"),
        dateendtime = Utils.UnixTimeToDateTime(x.Endtime).ToString("yyyy.MM.dd"),
        lenth = Utils.getSeconds((decimal)(x.Endtime - x.Starttime), 0),

      }).OrderByDescending(x => x.id).Take(50).ToListAsync(); ;

      return info;
    }
    public async Task<int> getLoginBonus(ulong uid)
    {
      var rs = -1;
      var configpri = await _commonService.getConfigPri();
      if (string.IsNullOrEmpty(configpri.bonus_switch.Value))
      {
        return rs;
      }

      var key = "loginbonus";
      var list = cacheManager.GetCacheString(key);
      List<BonusList> bonus_coin = new List<BonusList>();

      if (list == null)
      {
        bonus_coin = await context.CmfLoginbonus.Select(x => new BonusList
        {
          day = x.Day,
          coin = x.Coin
        }).ToListAsync();
        await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(bonus_coin));

      }
      else
      {
        bonus_coin = JsonConvert.DeserializeObject<List<BonusList>>(list ?? "") ?? new List<BonusList>();
      }
      var isadd = 0;
      var signInfo = await context.CmfUserSigns.Where(x => x.Uid == uid).Select(x => new SignInfo
      {
        bonus_day = x.BonusDay,
        bonus_time = x.BonusTime,
        count_day = x.CountDay
      }).FirstOrDefaultAsync();



      if (signInfo == null)
      {
        isadd = 1;
        signInfo = new SignInfo();
        signInfo.count_day = 0;
        signInfo.bonus_time = 0;
        signInfo.bonus_day = 0;
      }

      var nowtime = Utils.time();
      if (nowtime > signInfo.bonus_time)
      {
        var bonus_time = nowtime + 60 * 60 * 24;
        var bonus_day = signInfo.bonus_day;
        var count_day = signInfo.count_day;

        if (bonus_day > 6)
        {
          bonus_day = 0;
        }
        bonus_day++;
        count_day++;
        if (count_day > 7)
        {
          count_day = 1;
        }
        bonus_day = count_day;

        if (isadd == 1)
        {
          CmfUserSign infonew = new CmfUserSign()
          {
            Uid = uid,
            BonusDay = bonus_day,
            BonusTime = bonus_time,
            CountDay = count_day
          };
          await context.CmfUserSigns.AddAsync(infonew);
        }
        else
        {
          CmfUserSign obj = await context.CmfUserSigns.Where(x => x.Uid == uid).FirstOrDefaultAsync() ?? new CmfUserSign();
          obj.BonusTime = bonus_time;
          obj.CountDay = count_day;
          obj.BonusDay = bonus_day;
          context.SaveChanges();
        }
        int? coin = null;
        foreach (var v in bonus_coin)
        {
          if (v.day == bonus_day)
          {
            coin = v.coin;
          }
        }
        if (coin != null)
        {
          CmfUser1 user = await context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefaultAsync() ?? new CmfUser1();
          user.Coin = user.Coin + (ulong)coin;

          CmfUserCoinrecord obj = new CmfUserCoinrecord()
          {
            Type = 1,
            Action = 3,
            Uid = uid,
            Touid = uid,
            Giftcount = 0,
            Totalcoin = (ulong)(coin ??0),
            Showid = 0,
            Addtime = nowtime
          };

          await context.CmfUserCoinrecords.AddAsync(obj);
          await context.SaveChangesAsync();

        }
        rs = 0;

      }
      return rs;
    }
    public async Task<IList<LabelInfoModel>> getMyLabel(string lan, ulong uid)
    {
      string[] label = new string[0];
      var list = await context.CmfLabelUsers.Where(x => x.Touid == uid).ToListAsync();

      List<LabelInfoModel> rs = new List<LabelInfoModel>();
      foreach (var item in list)
      {
        var v_a = Regex.Split(item.Label, ",|，");
        v_a = v_a.Where(x => !String.IsNullOrEmpty(x)).ToArray();

        if (v_a.Length > 0) label = v_a;
      }

      if (label == null) return rs;

      var label_nums = label.GroupBy(x => x).ToDictionary(g => uint.Parse(g.Key), g => g.Count());
      var label_key = label_nums.Select(x => x.Key).ToArray();
      var labels = await getImpressionLabel(lan);
      List<int> order_nums = new List<int>();
      foreach (var v in labels)
      {
        LabelInfoModel obj = new LabelInfoModel();
        if (label_key.Contains(v.Id))
        {
          foreach (var k in label_nums)
          {
            if (k.Key == v.Id)
            {
              obj.nums = k.Value;
              order_nums.Add(obj.nums);
            }
          }
          obj.Id = v.Id;
          obj.NameEn = v.NameEn;
          obj.Name = v.Name;
          obj.NameNam = v.NameNam;
          obj.Colour = v.Colour;
          obj.Colour2 = v.Colour2;

          rs.Add(obj);
        }
      }
      order_nums.Sort();

      return rs.OrderByDescending(x => x.Id).ToList();
    }
    public async Task<IList<CmfLabel>> getImpressionLabel(string lan)
    {
      var key = "getImpressionLabel" + Utils.time();
      var list = cacheManager.GetCacheString(key);
      List<CmfLabel> rs = new List<CmfLabel>();
      if (list == null)
      {
        rs = await context.CmfLabels.OrderBy(x => x.ListOrder).ThenByDescending(x => x.Id).ToListAsync();
        if (rs != null || rs.Count > 0)
        {
          await cacheManager.SetCacheString(key, JsonConvert.SerializeObject(rs));
        }
      }
      else
      {
        rs = JsonConvert.DeserializeObject<List<CmfLabel>>(list ?? "") ?? new List<CmfLabel>();
      }

      foreach (var item in rs)
      {
        if (lan == "Nam")
        {
          item.Name = item.NameNam;
        }
        if (lan == "En")
        {
          item.Name = item.NameEn;
        }
      }

      return rs;
    }
  }
}
