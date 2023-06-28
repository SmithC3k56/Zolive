namespace zolive_api.Models.User
{


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
        public string location { get; set; }
        public uint level { get; set; }
        public uint level_anchor { get; set; }
        public int lives { get; set; }
        public string follows { get; set; }
        public string fans { get; set; }
        public Vip vip { get; set; }
        public Liang liang { get; set; }
        public string agent_switch { get; set; }
        public string family_switch { get; set; }
        public string shop_switch { get; set; }
        public string paidprogram_switch { get; set; }
        public List<List<ListImg>> list { get; set; }
    }

}
