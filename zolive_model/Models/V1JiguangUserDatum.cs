using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class V1JiguangUserDatum
    {
        public int JgId { get; set; }
        public string JiguangId { get; set; } = null!;
        public int UserId { get; set; }
        public string AppType { get; set; } = null!;
        /// <summary>
        /// 判定是都接受app推送，默认1是推送 2是不推送
        /// </summary>
        public int IsSent { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 性别 1为男 0为女
        /// </summary>
        public int? UserSex { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string? Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string? Latitude { get; set; }
        /// <summary>
        /// 地区tag
        /// </summary>
        public string? RegionTag { get; set; }
    }
}
