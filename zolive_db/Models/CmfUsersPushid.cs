using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersPushid
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public uint Uid { get; set; }
        /// <summary>
        /// 用户对应极光registration_id
        /// </summary>
        public string Pushid { get; set; } = null!;
    }
}
