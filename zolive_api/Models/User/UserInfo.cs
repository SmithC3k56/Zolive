using zolive_api.Models.Buyer;
using zolive_api.Models.Video;
using zolive_db.Models;

namespace zolive_api.Models.User
{
    public class GetUserlabelModel
    {
        public uint id { get; set; }
        public string name { get; set; }
        public int list_order { get; set; }
        public string colour { get; set; }
        public string colour2 { get; set; }
        public int ifcheck { get; set; }
    }
    public class Paylist
    {
        public string id { get; set; }
        public string name { get; set; }
        public string thumb { get; set; }
        public string href { get; set; }
    }
    public class getChargeRulesModel
    {
        public uint id { get; set; }
        public int coin { get; set; }
        public int coin_ios { get; set; }
        public decimal money { get; set; }
        public string product_id { get; set; }
        public int give { get; set; }
    }
    public class getBalanceModel
    {
        public ulong coin { get; set; }
        public long score { get; set; }
        public IList<getChargeRulesModel> rules { get; set; }
        public int aliapp_switch { get; set; }
        public string aliapp_partner { get; set; }
        public string aliapp_seller_id { get; set; }
        public string aliapp_key_android { get; set; }
        public string aliapp_key_ios { get; set; }
        public int wx_switch { get; set; }
        public string wx_appid { get; set; }
        public string wx_appsecret { get; set; }
        public string wx_mchid { get; set; }
        public string wx_key { get; set; }
        public List<Paylist> paylist { get; set; }
        public string tip_t { get; set; }
        public string tip_d { get; set; }
    }
    public class UidInfo
    {
        public string user_nicename { get; set; } = "";
        public string avatar { get; set; } = "";
        public string avatar_thumb { get; set; } = "";
        public string signature { get; set; } = "";
        public string province { get; set; } = "";
        public string city { get; set; } = "";
        public string birthday { get; set; } = "";
        public Vip? vip { get; set; }
        public Liang? liang { get; set; }
        public uint level_anchor { get;  set; }
        public uint level { get;  set; }
        public string location { get;  set; } = "";
        public int issuper { get;  set; }
        public byte user_status { get;  set; }
        public ulong votestotal { get;  set; }
        public ulong consumption { get;  set; }
        public sbyte sex { get;  set; }
        public ulong id { get;  set; }
        public sbyte utot { get;  set; }
        public sbyte ttou { get;  set; }
    }
    public class UserInfo
    {
        public ulong id { get; set; }
        public string user_nicename { get; set; } = "";
        public string avatar { get; set; } = "";
        public string avatar_thumb { get; set; }="";
        public sbyte sex { get; set; }
        public string signature { get; set; } = "";
        public ulong coin { get; set; }
        public decimal votes { get; set; }
        public ulong consumption { get; set; }
        public ulong votestotal { get; set; }
        public string province { get; set; }="";
        public string city { get; set; }="";
        public string birthday { get; set; }="0";
        public int issuper { get; set; }
        public string location { get; set; }="";
        public byte user_status { get; set; }
        public uint level { get; set; }
        public uint level_anchor { get; set; }
        public int lives { get; set; }
        public string follows { get; set; }="0";
        public string fans { get; set; } ="0";
        public string isattention { get; set; }="0";
        public string isblack { get; set; }="0";
        public IList<VideoModel> videolist { get; set; } = new List<VideoModel>();
        public IList<CmfLabel> label { get; set; } = new List<CmfLabel>();
        public string isblack2 { get; set; }="0";
        public int islive { get; set; }
        public int videonums { get; set; }
        public int dynamicnums { get; set; }
        public int livenums { get; set; }
        public int usertype { get; set; }
        public string sign { get; set; }="";
        public int type { get; set; }
        //public int contribute { get; set; }
        public IList<ContributeModel> contribute { get; set; } = new List<ContributeModel>();
        public Vip? vip { get; set; }
        public Liang? liang { get; set; }
        public IList<LiveRecordModel> liverecord { get; set; } = new List<LiveRecordModel>();
        public IList<UserInfo2> guardlist { get; set; } = new List<UserInfo2>();
        public int isshop { get; set; }
        public getShopModel? shop { get; set; }
    }
    public class UserInfo2
    {
        public ulong id { get; set; }
        public string user_nicename { get; set; }
        public string avatar { get; set; }
        public string avatar_thumb { get; set; }
        public sbyte sex { get; set; }
        public string signature { get; set; }
        public ulong coin { get; set; }
        public decimal votes { get; set; }
        public ulong consumption { get; set; }
        public ulong votestotal { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string birthday { get; set; }
        public bool issuper { get; set; }
        public string location { get; set; }
        public byte user_status { get; set; }
        public uint level { get; set; }
        public uint level_anchor { get; set; }
        public int lives { get; set; }
        public string follows { get; set; }
        public string fans { get; set; }
        public string isattention { get; set; }
        public string isblack { get; set; }
        public string isblack2 { get; set; }
        public int islive { get; set; }
        public int videonums { get; set; }
        public int dynamicnums { get; set; }
        public int livenums { get; set; }
        public int type { get; set; }
        public int contribute { get; set; }
        public Vip vip { get; set; }
        public Liang liang { get; set; }
        public List<LiveRecordModel> liverecord { get; set; }
    }
    public class LiveRecordModel
    {
        public string datestarttime { get; set; }
        public string dateendtime { get; set; }
        public string lenth { get; set; }
        public ulong id { get; set; }
        public ulong uid { get; set; }
        public ulong nums { get; set; }
        public string title { get; set; }
        public string city { get; internal set; }
        //public ulong  { get; set; }

    }
    public class ContributeModel
    {
        public ulong uid { get; set; }
        public string avatar { get; set; }
        public string user_nicename { get; set; }
        public decimal total { get; set; }
    }
}
