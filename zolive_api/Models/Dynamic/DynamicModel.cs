using zolive_api.Models.User;

namespace zolive_api.Models.Dynamic
{
    public class LikeModel
    {
        public int islike { get; set; }
        public string? likes { get; set; }
    }
    public class SetComment
    {
        public int isattent { get; set; }
        public int u2t { get; set; }
        public int t2u { get; set; }
        public int comments { get; set; }
        public int replys { get; set; }
    }
    public class SetCommentModel
    {
        public int comments { get; set; }
        public int replys { get; set; }
    }
    public class GetCommentModel
    {
        public int comments { get; set; }
        public IList<GetCommentsModel> commentlist { get; set; }
    }
    public class GetCommentsModel
    {
        public UserInfo userinfo { get; set; }
        public string datetime { get; set; }
        public string likes { get; set; }
        public string islike { get; set; }
        public ulong touid { get; set; }
        public UserInfo touserinfo { get; set; }
        public int replys { get; set; }
        public IList<ReplyModel> replylist { get; set; }
    }
    public class ReplyModel
    {
        public UserInfo userinfo { get; set; }
        public string datetime { get; set; }
        public string likes { get; set; }
        public sbyte islike { get; set; }
        public ulong touid { get; set; }
        public string parentid { get; set; }
        public UserInfo touserinfo { get; set; }
        public string tocommentinfo { get; set; }

    }
    public class UserinfoDynamic
    {
        public ulong id { get; set; }
        public string user_nicename { get; set; }
        public string avatar { get; set; }
        public string avatar_thumb { get; set; }
        public sbyte sex { get; set; }
        public sbyte isAttention { get; set; }
    }

    public class DynamicModel
    {
        public ulong id { get; set; }
        public ulong uid { get; set; }
        public string title { get; set; } = "";
        public string thumb { get; set; } = "";
        public string video_thumb { get; set; } = "";
        public string href { get; set; } = "";
        public string voice { get; set; } = "";
        public int? length { get; set; }
        public string likes { get; set; } = "";
        public string comments { get; set; } = "";
        public int type { get; set; }
        public int isdel { get; set; }
        public int status { get; set; }
        public long uptime { get; set; }
        public string xiajia_reason { get; set; } = "";
        public string lat { get; set; } = "";
        public string lng { get; set; } = "";
        public string city { get; set; } = "";
        public string address { get; set; } = "";
        public long addtime { get; set; }
        public string fail_reason { get; set; } = "";
        public int show_val { get; set; }
        public int? recommend_val { get; set; }
        public string[] thumb_ars { get; set; } = new string[0];
        public decimal recomend { get; set; }
        public string datetime { get; set; } = "";
        public string[] thumbs { get; set; } = new string[0];
        public int islike { get; set; }
        public UserinfoDynamic? userinfo { get; set; }
    }
}
