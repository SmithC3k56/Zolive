using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using zolive_api.Models.Buyer;

namespace zolive_api.src
{
    public static class MessageClass
    {

        public static async Task<JObject> send(sendTextModel options)
        {
            var uri = "https://api.im.jpush.cn/v1/messages";
            var body = options;
            var Cbody = JsonConvert.SerializeObject(body);
            HttpContent c = new StringContent(Cbody, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync("https://api.im.jpush.cn/v1/admins", c);
            var dataFromServer = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(dataFromServer);
            return json;

        }
        public static async Task<JObject> sendText(int version, dynamic from, dynamic target, dynamic msg, dynamic notification, dynamic options)
        {
            var buildMsg = buildMessage(version, from, target, notification, options);

            var opts = new sendTextModel()
            {
                msg_type = "text",
                msg_body = new msg_bodyModel()
                {
                    text = msg.text.ToString()
                },
                version = buildMsg.version,
                target_type = buildMsg.target_type,
                from_type = buildMsg.from_type,
                target_id = buildMsg.target_id,
                from_id = buildMsg.from_id,
                from_name = buildMsg.from_name,
                target_name = buildMsg.target_name,
                no_offline = buildMsg.no_offline,
                target_appkey = buildMsg.target_appkey,
                title = buildMsg.title,
                notification = buildMsg.notification,
                no_notification = buildMsg.no_notification
            };
            var rs = await send(opts);
            return rs;
        }
        public static buildMessageModel buildMessage(int version, dynamic from, dynamic target, dynamic notification, dynamic options)
        {
            var opts = new buildMessageModel()
            {
                version = version,
                target_type = target.type,
                from_type = from.type,
                target_id = target.id,
                from_id = from.id,
            };
            if (from.name != null)
            {
                opts.from_name = from.name.ToString();
            }
            else if (target.name != null)
            {
                opts.target_name = target.name;
            }
            else if (options.offline != null)
            {
                opts.no_offline = !options.offline;
            }
            else if (options.target_appkey != null)
            {
                opts.target_appkey = options.target_appkey;
            }
            else if (notification.notifiable != null)
            {
                opts.no_notification = !(bool)notification.notifiable;
            }
            else if (notification.title != null)
            {
                opts.notification.title = notification.title;
            }
            else if (notification.alert != null)
            {
                opts.notification.alert = notification.alert;
            }
            return opts;
        }

    }
}
