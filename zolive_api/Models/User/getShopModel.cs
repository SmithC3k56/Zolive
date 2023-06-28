namespace zolive_api.Models.User
{
  public class GetPerSettingModel
  {
    public int id { get; set; }
    public string name { get; set; }
    public string thumb { get; set; }
    public string href { get; set; }
  }
  public class GetCdnRecordModel
  {
    public ulong id { get; set; }
    public long starttime { get; set; }
    public long endtime { get; set; }
    public string? stream { get; set; }
    public string? video_url { get; set; }
  }
  public class HandleGoodsListModel
  {
    public ulong id { get; set; }
    public string name { get; set; }
    public string thumb { get; set; }
    public long sale_nums { get; set; }
    public Dictionary<string, string> specs { get; set; }
    public int hits { get; set; }
    public bool issale { get; set; }
    public sbyte type { get; set; }
    public decimal original_price { get; set; }
    public decimal price { get; set; }
    public int status { get; set; }
    public bool live_isshow { get; set; }

  }
  public class getShopModel
  {
    public ulong uid { get; set; }
    public string sale_nums { get; set; }
    public string quality_points { get; set; }
    public string service_points { get; set; }
    public string express_points { get; set; }
    public string certificate { get; set; }
    public string other { get; set; }
    public string service_phone { get; set; }
    public string province { get; set; }
    public string city { get; set; }
    public string area { get; set; }
    public string user_nicename { get; set; }
    public string name { get; set; }
    public string avatar { get; set; }
    public string composite_points { get; set; }
    public string address_format { get; set; }
    public string certificate_desc { get; set; }
    public int goods_nums { get; set; }
    public sbyte isattention { get; set; }
    public int nums { get; set; }
  }
}
