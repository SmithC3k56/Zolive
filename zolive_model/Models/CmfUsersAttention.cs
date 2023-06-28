using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersAttention
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 关注人ID
        /// </summary>
        public int Touid { get; set; }
    }
}
