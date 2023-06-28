using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfAgentCode
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 邀请码
        /// </summary>
        public string Code { get; set; } = null!;
    }
}
