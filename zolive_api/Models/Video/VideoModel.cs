using zolive_api.Models.User;

namespace zolive_api.Models.Video
{

  public class ResultComment
  {
    public int comments { get; set; }
    public List<VideoCommentModel> commentlist { get; set; }
  }
  public class VideoModel
  {
    public ulong id { get; set; }
    public ulong uid { get; set; }
    public string title { get; set; }
    public string thumb { get; set; }
    public string thumb_s { get; set; }
    public string href { get; set; }
    public string href_w { get; set; }
    public string likes { get; set; }
    public int views { get; set; }
    public string comments { get; set; }
    public string steps { get; set; }
    public int shares { get; set; }
    public string addtime { get; set; }
    public long ad_endtime { get; set; }
    public string lat { get; set; }
    public string lng { get; set; }
    public string city { get; set; }
    public long music_id { get; set; }
    public bool is_ad { get; set; }
    public string ad_url { get; set; }
    public int type { get; set; }
    public ulong goodsid { get; set; }
    public long classid { get; set; }
    public UserInfo userinfo { get; set; }
    public string datetime { get; set; }
    public sbyte islike { get; set; }
    public sbyte isstep { get; set; }
    public sbyte isattent { get; set; }
    public sbyte goods_type { get; set; }
  }
  public class VideoCommentModel
  {
    public ulong id { get; set; }
    public ulong uid { get; set; }
    public ulong videoid { get; set; }
    public ulong commentid { get; set; }
    public ulong parentid { get; set; }
    public string? content { get; set; }
    public long addtime { get; set; }
    public string? at_info { get; set; }
    public UserInfo userinfo { get; set; }
    public string datetime { get; set; }
    public string likes { get; set; }
    public sbyte islike { get; set; }
    public int touid { get; set; }
    public UserInfo? touserinfo { get; set; }
    public int replys { get; set; }
    public List<CommentV1>? replylist { get; set; }
  }
  public class CommentV1
  {
    public ulong id { get; set; }
    public ulong uid { get; set; }
    public ulong touid { get; set; }
    public ulong videoid { get; set; }
    public ulong commentid { get; set; }
    public ulong parentid { get; set; }
    public string? content { get; set; }
    public string? likes { get; set; }
    public string? addtime { get; set; }
    public string? at_info { get; set; }
    public string? datetime { get; set; }
    public sbyte islike { get; set; }
    public UserInfo? touserinfo { get; internal set; }
    public dynamic? tocommentinfo { get; set; }
    public UserInfo? userinfo { get; internal set; }
  }
}
