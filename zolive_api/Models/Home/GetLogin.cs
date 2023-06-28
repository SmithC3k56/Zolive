namespace zolive_api.Models.Home
{
    public class Message
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class LoginAlert
    {
        public string title { get; set; }
        public string content { get; set; } 
        public string login_title { get; set; }
        public List<Message> message { get; set; }
    }

    public class Info
    {
        public LoginAlert login_alert { get; set; }
        public List<string> login_type { get; set; }
        public List<string> login_type_ios { get; set; }
    }

}
