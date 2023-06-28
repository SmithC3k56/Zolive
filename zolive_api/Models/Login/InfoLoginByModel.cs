namespace zolive_api.Models
{
    public class InfoLoginByModel
    {
        public ulong id { get; set; }
        public string user_nicename { get; set; }
        public string avatar { get; set; }
        public string avatar_thumb { get; set; }
        public sbyte sex { get; set; }
        public string signature { get; set; }
        public ulong coin { get; set; }
        public ulong consumption { get; set; }
        public ulong votestotal { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string birthday { get; set; }
        public string login_type { get; set; }
        public string location { get; set; }
        public int isreg { get; set; }
        public int isagent { get; set; }
        public uint level { get; set; }
        public uint level_anchor { get; set; }
        public int last_login_time { get; set; }
        public string token { get; set; }

    }
    public class TokenInfo
    {
        public ulong uid { get; set; }
        public string token { get; set; }
        public int expiretime { get; set; }
    }
    public class UserLogin
    {
        public short code { get; set; }
        public InfoLoginByModel data { get; set; }
    }


}
