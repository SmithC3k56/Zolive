namespace zolive_api.src
{
  public class Hub
  {
    public static string RTMPPublishURL(string domain, string hub, string streamKey, long expireAfterSeconds, string accessKey, string secretKey)
    {
      var expire = Utils.time() + expireAfterSeconds;
      var path = "/" + hub + "/" + streamKey + "?e=" + expire;
      var token = accessKey + ":" + Utils.sign(secretKey, path);
      return "rtmp://" + domain + path + "&token=" + token;
    }
    public static string HDLPlayURL(string domain, string hub, string streamKey)
    {
      return "http://" + domain + "/" + hub + "/" + streamKey + ".flv";
    }
    public static string HLSPlayURL(string domain, string hub, string streamKey)
    {
      return "http://" + domain + "/" + hub + "/" + streamKey + ".m3u8";
    }

    public static string RTMPPlayURL(string domain, string hub, string streamKey)
    {
        return "rtmp://"+domain+"/" + hub + "/" + streamKey ;
    }

  }
}
