using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zolive_unit_test
{
    public class P
    {
        public string name { get; set; }
        public string type { get; set; }
        public string @default { get; set; }
        public string desc { get; set; }
    }

    public class GetHot
    {
        public P p { get; set; }
    }

    public class Uid
    {
        public string name { get; set; }
        public string type { get; set; }
        public int min { get; set; }
        public bool require { get; set; }
        public string desc { get; set; }
    }

    public class GetFollow
    {
        public Uid uid { get; set; }
        public P p { get; set; }
    }

    public class Lng
    {
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
    }

    public class Lat
    {
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
    }

    public class GetNew
    {
        public Lng lng { get; set; }
        public Lat lat { get; set; }
        public P p { get; set; }
    }

    public class Key
    {
        public string name { get; set; }
        public string type { get; set; }
        public string @default { get; set; }
        public string desc { get; set; }
    }

    public class Search
    {
        public Uid uid { get; set; }
        public Key key { get; set; }
        public P p { get; set; }
    }

    public class GetNearby
    {
        public Lng lng { get; set; }
        public Lat lat { get; set; }
        public P p { get; set; }
    }

    public class GetRecommend
    {
        public Uid uid { get; set; }
    }

    public class Touid
    {
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
    }

    public class AttentRecommend
    {
        public Uid uid { get; set; }
        public Touid touid { get; set; }
    }

    public class Type
    {
        public string name { get; set; }
        public string type { get; set; }
        public string @default { get; set; }
        public string desc { get; set; }
    }

    public class ProfitList
    {
        public Uid uid { get; set; }
        public P p { get; set; }
        public Type type { get; set; }
    }

    public class ConsumeList
    {
        public Uid uid { get; set; }
        public P p { get; set; }
        public Type type { get; set; }
    }

    public class RsBaseInfo
    {
        public int code { get; set; }
        public string msg { get; set; }
        public BaseInfo info { get; set; }
    }

    public class Liveclassid
    {
        public string name { get; set; }
        public string type { get; set; }
        public string @default { get; set; }
        public string desc { get; set; }
    }

    public class GetClassLive
    {
        public Liveclassid liveclassid { get; set; }
        public P p { get; set; }
    }

    public class Data
    {
        public GetHot getHot { get; set; }
        public GetFollow getFollow { get; set; }
        public GetNew getNew { get; set; }
        public Search search { get; set; }
        public GetNearby getNearby { get; set; }
        public GetRecommend getRecommend { get; set; }
        public AttentRecommend attentRecommend { get; set; }
        public ProfitList profitList { get; set; }
        public ConsumeList consumeList { get; set; }
        public GetClassLive getClassLive { get; set; }
        public string msg { get; set; }
    }

    public class Debug
    {
        public List<object> stack { get; set; }
        public List<object> sqls { get; set; }
        public string version { get; set; }
    }

    public class Root
    {
        public int ret { get; set; }
        public Data data { get; set; }
        public string msg { get; set; }
        public Debug debug { get; set; }
    }

    #region Get login
    public class Message
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class LoginAlert
    {
        public string title { get; set; }
        public string content { get; set; }
        public string login_title { get; set; }
        public List<Message> message { get; set; }
    }

    public class Info
    {
        public LoginAlert login_alert { get; set; }
        public List<string> login_type { get; set; }
        public List<string> login_type_ios { get; set; }
    }
    #endregion
    #region get base info

    public class ListImg
    {
        public int id { get; set; }
        public string name { get; set; }
        public string thumb { get; set; }
        public string href { get; set; }
    }
    public class Vip
    {
        public string type { get; set; }
    }

    public class Liang
    {
        public string name { get; set; }
    }

    public class BaseInfo
    {
        public string id { get; set; }
        public string user_nicename { get; set; }
        public string avatar { get; set; }
        public string avatar_thumb { get; set; }
        public string sex { get; set; }
        public string signature { get; set; }
        public string coin { get; set; }
        public string votes { get; set; }
        public string consumption { get; set; }
        public string votestotal { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string birthday { get; set; }
        public string location { get; set; }
        public string level { get; set; }
        public string level_anchor { get; set; }
        public int lives { get; set; }
        public string follows { get; set; }
        public string fans { get; set; }
        public Vip vip { get; set; }
        public Liang liang { get; set; }
        public string agent_switch { get; set; }
        public string family_switch { get; set; }
        public string shop_switch { get; set; }
        public string paidprogram_switch { get; set; }
        public List<ListImg> list { get; set; }
    }

    #endregion


}
