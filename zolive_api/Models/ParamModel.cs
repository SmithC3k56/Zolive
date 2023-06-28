namespace zolive_api.Models
{
    public class ParamModel
    {
        public string Key { get; set; }
        public dynamic Value { get; set; }
    }
    public class ResultBaseInfo{
        public int code { get; set; }
        public string msg { get; set; }
        public dynamic info { get; set; }
    }
}
