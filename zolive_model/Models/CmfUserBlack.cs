using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserBlack
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 被拉黑人ID
        /// </summary>
        public int Touid { get; set; }
    }
}
