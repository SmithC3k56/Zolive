using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace zolive_api.src
{
    public static class AdminClass
    {
        public static async Task<JObject> register(dynamic body)
        {
            var Cbody = JsonConvert.SerializeObject(body);
            HttpContent c = new StringContent(Cbody, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync("https://api.im.jpush.cn/v1/admins", c);
            var dataFromServer = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(dataFromServer);
            return json;
        }
    }
}
