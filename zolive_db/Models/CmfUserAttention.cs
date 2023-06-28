using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    [Keyless]
    public partial class CmfUserAttention
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Id { get; set; }
        public ulong Uid { get; set; }
        /// <summary>
        /// 关注人ID
        /// </summary>
        public ulong Touid { get; set; }
    }
}
