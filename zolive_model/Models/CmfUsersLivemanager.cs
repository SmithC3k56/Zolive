using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersLivemanager
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public int Liveuid { get; set; }
    }
}
