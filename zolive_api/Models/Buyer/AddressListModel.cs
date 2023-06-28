namespace zolive_api.Models.Buyer
{

    public class AddressListModel
    {
        public ulong id { get; set; }
        public string name { get; set; }
        public string? country { get; set; }
        public string? province { get; set; }
        public string? city { get; set; }
        public string? area { get; set; }
        public string address { get; set; }
        public int country_code { get; set; }
        public string phone { get; set; }
        public bool is_default { get; set; }
        public string? receiver_country { get; set; }
    }
}
