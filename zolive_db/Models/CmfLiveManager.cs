using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLiveManager
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public ulong Liveuid { get; set; }
    }
}
