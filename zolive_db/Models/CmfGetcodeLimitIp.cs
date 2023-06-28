using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGetcodeLimitIp
    {
        /// <summary>
        /// ip地址
        /// </summary>
        public long Ip { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Date { get; set; } = null!;
        /// <summary>
        /// 次数
        /// </summary>
        public sbyte Times { get; set; }
    }
}
