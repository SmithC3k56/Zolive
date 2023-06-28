namespace zolive_api.Models.User
{
    public class HandleLiveModel
    {
        public int id { get; set; }
        public ulong uid { get; set; }
        public string avatar { get; set; }
        public string avatar_thumb { get; set; }
        public string user_nicename { get; set; }
        public string nums { get; set; }
        public sbyte sex { get; set; }
        public uint level { get; set; }
        public uint level_anchor { get; set; }
        public string thumb { get; set; }
        public string isvideo { get; set; }
        public string pull { get; set; }
        public string stream { get; set; }
        public string type { get; set; }
        public string type_val { get; set; }
        public string game { get; set; }
        public string game_action { get; set; }
    }
}
