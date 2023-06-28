namespace zolive_api.Models.Home
{
  public class profitListResultModel
  {
    public decimal totalcoin { get; set; }
    public ulong uid { get; set; }
  }
  public class PrivateKeyModel
  {
      public string cdn {get;set;}
      public string stream {get;set;}
  }
  public class ProfitModel
  {
    public string? avatar { get; set; }
    public string? avatar_thumb { get; set; }
    public string? user_nicename { get; set; }
    public sbyte sex { get; set; }
    public uint level { get; set; }
    public uint level_anchor { get; set; }
    public int totalcoin { get; set; }
    public sbyte isAttention { get; set; }
    public ulong uid { get; set; }
  }
}
