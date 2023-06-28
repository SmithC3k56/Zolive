using zolive_api.Models.User;

namespace zolive_api.Models.Paidprogram
{
    public class getProfitModel{
        public decimal votes { get; set; }
        public ulong votestotal { get; set; }
        public decimal total { get; set; }
        public decimal cash_rate { get; set; }
        public string tips { get; set; }

    }
    public class PaidProgramModel
    {
        public string thumb { get; set; }
        public string title { get; set; }
        public string avatar { get; set; }
        public string video_num { get; set; }
        public string user_nicename { get; set; }
        public UserInfo userinfo { get; set; }
    }
    public class GetApplyStatusModel{
        public int apply_status { get; set; }
        public int isauth { get; set; }
        public string title { get; set; }
        public string auth_msg{ get; set; }
        public string desc { get; set; }
        public string payment_title { get; set; }
    }
}
