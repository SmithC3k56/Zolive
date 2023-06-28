using zolive_api.Models.User;

namespace zolive_api.Models.Livemanage
{
  public class LivemanageModel
  {
  }
  public class GetRoomListModel
  {
    public string? user_nicename { get; set; }
    public string? avatar { get; set; }
    public string? avatar_thumb { get; set; }
    public sbyte? sex { get; set; }
    public uint level { get; set; }
  }
  public class GetCodeModel
  {
    public ulong uid { get; set; }
    public string href { get; set; }
    public string qr { get; set; }
    public string code { get; set; } = null!;
  }
}
