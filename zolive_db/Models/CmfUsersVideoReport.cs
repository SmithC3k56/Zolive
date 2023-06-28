using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersVideoReport
    {
        public uint Id { get; set; }
        public int? Uid { get; set; }
        public int? Touid { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public int? Videoid { get; set; }
        public string? Content { get; set; }
        /// <summary>
        /// 0处理中 1已处理  2审核失败
        /// </summary>
        public bool? Status { get; set; }
        public int? Addtime { get; set; }
        public int? Uptime { get; set; }
    }
}
