namespace zolive_api.Models.Buyer
{
        //ModelNewList
    public class ModelNewList
    {
        public  List<V1Model> list { get; set; }
        public  string date { get; set; }
    }
    public class V1Model
    {
        public string goods_name { get; set; }
        public string goods_thumb { get; set; }
        public string addtime { get; set; }
        public int goods_status { get; set; }
        public sbyte type { get; set; }
        public string href { get; set; }
        public string original_price { get; set; }
        public string goods_price { get; set; }
        public string time_format { get; set; }
    }
    public class GetHomeModel
    {
        public int wait_payment { get; set; }
        public int wait_shipment { get; set; }
        public int wait_receive { get; set; }
        public int wait_evaluate { get; set; }
        public int refund { get; set; }
        public int apply_status { get; set; }
        public string apply_reason { get; set; }
    }
    public class getShopApplyInfoModel
    {
        public int apply_status { get; set; }
        public applyInfoModel apply_info { get; set; }
    }
    public class applyInfoModel
    {
        public string certificate_format { get; set; }
        public string other_format { get; set; }
        public string reason { get; set; }
        public List<int> goods_classid { get; set; }
        public int status { get; set; }
    }

    public class handleGoodsModel
    {
        public string one_class_name { get; set; }
        public string two_class_name { get; set; }
        public string three_class_name { get; set; }
        public string hits { get; set; }
        public string sale_nums { get; set; }
        public string video_url_format { get; set; }
        public string video_thumb_format { get; set; }
   
        public List<string> thumbs_format { get; set; }
        public List<dynamic> specs_format { get; set; }
        public string specs { get; set; }
        public string pictures { get; set; }
        public List<string> pictures_format { get; set; }
        public string postage { get; set; }
    }

}
