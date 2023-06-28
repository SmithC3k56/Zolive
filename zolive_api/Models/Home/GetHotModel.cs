namespace zolive_api.Models.Home
{
    public class getSlideModel
    {
        public string slide_pic { get; set; }
        public string slide_url { get; set;}
    }
    public class InfoHot
    {
        public IList<getSlideModel> slide { get; set; } = new List<getSlideModel>();
        public IList<GetHotModel> list { get; set; } = new List<GetHotModel>();
    }
 
    public class GetHotModel
    {

        public ulong uid { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string stream { get; set; }
        public string pull { get; set; }
        public string thumb { get; set; }
        public bool isvideo { get; set; }
        public int type { get; set; }
        public string type_val { get; set; }
        public string goodnum { get; set; }
        public int anyway { get; set; }
        public long starttime { get; set; }
        public int isshop { get; set; }
        public int game_action { get; set; }
        public int hotvotes { get; set; }
        public long nums { get; set; }
        public string avatar { get; set; }
        public string avatar_thumb { get; set; }
        public string user_nicename { get; set; }
        public sbyte sex { get; set; }
        public uint level { get; set; }
        public uint level_anchor { get; set; }
        public string game { get; set; }


    }
}
