using zolive_api.Models.User;

namespace zolive_api.Models.Live
{
 public class SendBarrageModel{
    public ulong uid{get;set;} 
    public string content{get;set;} ="";
    public ulong giftid{get;set;} 
    public ulong totalcoin{get;set;}
    public int giftcount{get;set;}
    public string giftname{get;set;} ="";
    public string gifticon{get;set;} ="";
    public uint level{get;set;}
    public ulong coin{get;set;} 
    public ulong votestotal{get;set;}
    public string barragetoken{get;set;} ="";
 }
  public class CreateRoomResult
  {
    public Liang liang { get; internal set; }
    public Vip vip { get; internal set; }
    public dynamic userlist_time { get; internal set; }
    public dynamic barrage_fee { get; internal set; }
    public dynamic chatserver { get; internal set; }
    public ulong votestotal { get; internal set; }
    public string stream { get; internal set; }
    public string push { get; internal set; }
    public string pull { get; internal set; }
    public dynamic game_switch { get; internal set; }
    public string game_bankerid { get; internal set; }
    public string game_banker_name { get; internal set; }
    public string game_banker_avatar { get; internal set; }
    public string game_banker_coin { get; internal set; }
    public dynamic game_banker_limit { get; internal set; }
    public int guard_nums { get; internal set; }
    public dynamic tx_appid { get; internal set; }
    public string jackpot_level { get; internal set; }
    public string[] sensitive_words { get; internal set; }
    public string thumb { get; internal set; }
  }
  public class CreateRoomModel
  {
    public string? title { get; set; }
    public ulong? uid {get;set;}
    public string? token { get; set; }
    public string? province { get; set; }
    public int? type { get; set; }
    public string? type_val { get; set; }
    public string? city { get; set; }
    public string? lng { get; set; }
    public string? lat { get; set; }
    public string? anyway { get; set;}
    public string? deviceinfo { get; set; }
    public bool? isshop {get;set;}
    public ulong? liveclassid{get;set;}
  }
  public class StopRoomModel
  {
    public long Endtime;

    public ulong uid { get; set; }
    public int showid { get; set; }
    public ulong starttime { get; set; }
    public string title { get; set; }
    public string province { get; set; }
    public string city { get; set; }
    public string stream { get; set; }
    public string lng { get; set; }
    public string lat { get; set; }
    public int type { get; set; }
    public string type_val { get; set; }
    public int liveclassid { get; set; }
    public string Time { get; set; }
    public decimal votes { get; set; }
    public long nums { get; set; }
  }
  public class checkLiveResult
  {
    public int type { get; set; }
    public string type_msg { get; set; }
    public string type_val { get; set; }

  }


  public class GetAdminListModel
  {
    public List<UserInfo> list { get; set; }
    public int nums { get; set; }
    public int total { get; set; }
  }
}
