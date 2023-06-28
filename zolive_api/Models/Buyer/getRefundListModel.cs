namespace zolive_api.Models.Buyer
{
    public class sendTextModel
    {
        public string msg_type { get; set; }
        public msg_bodyModel msg_body { get; set; }
        public int version { get; set; }
        public dynamic target_type { get; set; }
        public dynamic from_type { get; set; }
        public dynamic target_id { get; set; }
        public dynamic from_id { get; set; }
        public string from_name { get; set; }
        public string target_name { get; set; }
        public bool no_offline { get; set; }
        public dynamic target_appkey { get; set; }
        public string title { get; set; }
        public notificationModel notification { get; set; }
        public bool no_notification { get; set; }
    }
    public class msg_bodyModel
    {
        public string text { get; set; }
        // public dynamic extras { get; set; }

    }

    public class buildMessageModel
    {
        public int version { get; set; }
        public dynamic target_type { get; set; }
        public dynamic from_type { get; set; }
        public dynamic target_id { get; set; }
        public dynamic from_id { get; set; }
        public string from_name { get; set; }
        public string target_name { get; set; }
        public bool no_offline { get; set; }
        public dynamic target_appkey { get; set; }
        public string title { get; set; }
        public notificationModel notification { get; set; }
        public bool no_notification { get; set; }
    }
    public class notificationModel
    {
        public string alert { get; set; }
        public string title { get; set; }
    }
    public class getShopEffectiveTimeModel
    {
        public decimal shop_payment_time { get; set; }
        public decimal shop_shipment_time { get; set; }
        public decimal shop_receive_time { get; set; }
        public decimal shop_refund_time { get; set; }
        public decimal shop_refund_finish_time { get; set; }
        public decimal shop_receive_refund_time { get; set; }
        public decimal shop_settlement_time { get; set; }
    }
    public class getRefundListInfo
    {
        public List<getRefundListModel> list { get; set; }
        public BalanceModel user_balance { get; set; }
    }
    public class BalanceModel
    {
        public decimal balance { get; set; }
        public decimal balance_total { get; set; }
    }
    public class getRefundListModel
    {
        public long id { get; set; }
        public long uid { get; set; }
        public long touid { get; set; }
        public string balance { get; set; }
        public short type { get; set; }
        public short action { get; set; }
        public long orderid { get; set; }
        public string addtime { get; set; }
        public string result { get; set; }
    }
}
