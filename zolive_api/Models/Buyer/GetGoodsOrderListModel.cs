using zolive_api.Models.User;

namespace zolive_api.Models.Buyer
{
    public class GetGoodsOrderListModel
    {
        public long id { get; set; }
        public long uid { get; set; }
        public long shop_uid { get; set; }
        public long goodsid { get; set; }
        public string goods_name { get; set; }
        public string spec_name { get; set; }
        public string spec_thumb { get; set; }
        public string status_name{ get; set; }
        public long nums { get; set; }
        public decimal price { get; set; }
        public decimal total { get; set; }
        public sbyte status { get; set; }
        public bool? is_append_evaluate { get; set; }
        public short refund_status { get; set; }
        public int addtime { get; set; }
        public int paytime { get; set; }
        public string shop_name { get; set; }
        public getShopModel shop_info { get; set; }
    }
}
