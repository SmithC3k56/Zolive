using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zolive_db.Models;

namespace zolive_db.Home
{
    public class GetConfig
    {
        public string maintain_switch { get; set; }
        public string maintain_tips { get; set; }
        public string company_name { get; set; }
        public string company_desc { get; set; }
        public string site_name { get; set; }
        public string site { get; set; }
        public string name_coin { get; set; }
        public string name_score { get; set; }
        public string name_votes { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public string apk_ewm { get; set; }
        public string ipa_ewm { get; set; }
        public string isup { get; set; }
        public string apk_ver { get; set; }
        public string apk_url { get; set; }
        public string apk_des { get; set; }
        public string ipa_ver { get; set; }
        public string ios_shelves { get; set; }
        public string ipa_url { get; set; }
        public string ipa_des { get; set; }
        public string wx_siteurl { get; set; }
        public string share_title { get; set; }
        public string share_title_en { get; set; }
        public string share_title_nam { get; set; }
        public string share_des { get; set; }
        public string share_des_en { get; set; }
        public string share_des_nam { get; set; }
        public string app_android { get; set; }
        public string app_ios { get; set; }
        public string video_share_title { get; set; }
        public string video_share_title_en { get; set; }
        public string video_share_title_nam { get; set; }
        public string video_share_des { get; set; }
        public string video_share_des_en { get; set; }
        public string video_share_des_nam { get; set; }
        public IList<string> live_time_coin { get; set; }
        public string sprout_key { get; set; }
        public string sprout_key_ios { get; set; }
        public string skin_whiting { get; set; }
        public string skin_smooth { get; set; }
        public string skin_tenderness { get; set; }
        public string eye_brow { get; set; }
        public string big_eye { get; set; }
        public string eye_length { get; set; }
        public string eye_corner { get; set; }
        public string eye_alat { get; set; }
        public string face_lift { get; set; }
        public string face_shave { get; set; }
        public string mouse_lift { get; set; }
        public string nose_lift { get; set; }
        public string chin_lift { get; set; }
        public string forehead_lift { get; set; }
        public string lengthen_noseLift { get; set; }
        public string payment_des_en { get; set; }
        public string payment_des_nam { get; set; }
        public string payment_time { get; set; }
        public string payment_percent { get; set; }
        public string login_alert_title { get; set; }
        public string login_alert_title_en { get; set; }
        public string login_alert_title_nam { get; set; }
        public string login_alert_content { get; set; }
        public string login_alert_content_en { get; set; }
        public string login_alert_content_nam { get; set; }
        public string login_clause_title { get; set; }
        public string login_clause_title_en { get; set; }
        public string login_clause_title_nam { get; set; }
        public string login_private_url { get; set; }
        public string login_service_url { get; set; }
        public IList<string> login_type { get; set; }
        public IList<object> share_type { get; set; }
        public IList<IList<string>> live_type { get; set; }
        public IList<CmfLiveClass> liveclass { get; set; }
        public IList<Videoclass> videoclass { get; set; }
        public IList<Level> level { get; set; }
        public IList<Levelanchor> levelanchor { get; set; }
        public string tximgfolder { get; set; }
        public string txvideofolder { get; set; }
        public string txcloud_appid { get; set; }
        public string txcloud_region { get; set; }
        public string txcloud_bucket { get; set; }
        public string cloudtype { get; set; }
        public string qiniu_domain { get; set; }
        public string video_audit_switch { get; set; }
        public string letter_switch { get; set; }
        public Guide guide { get; set; }
        public IList<string> sensitive_words { get; set; }
        public object video_watermark { get; set; }
        public string shopexplain_url { get; set; }
        public string stricker_url { get; set; }
        public string shop_system_name { get; set; }
    }
    public class Guide
    {
        public string @switch { get; set; }
        public string type { get; set; }
        public string time { get; set; }
        public IList<ImgLink> list { get; set; }
    }
    public class ImgLink
    {
        public string thumb { get; set; }
        public string href { get; set; }
    }
    public class Liveclass
    {
        public uint id { get; set; }
        public string name { get; set; }
        public string thumb { get; set; }
        public string des { get; set; }
        public int list_order { get; set; }
        public string en { get; set; }
        public string nam { get; set; }
    }
    public class Videoclass
    {
        public string id { get; set; }
        public string name { get; set; }
        public int list_order { get; set; }
        //public string name_en { get; set; }
        //public string name_nam { get; set; }
    }
    public class Level
    {
        public int levelid { get; set; }
        public string thumb { get; set; }
        public string colour { get; set; }
        public string thumb_mark { get; set; }
        public string bg { get; set; }
    }
    public class Levelanchor
    {
        public int levelid { get; set; }
        public string thumb { get; set; }
        public string thumb_mark { get; set; }
        public string bg { get; set; }
    }
}
