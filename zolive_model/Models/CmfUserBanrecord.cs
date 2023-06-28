using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserBanrecord
    {
        public uint Id { get; set; }
        /// <summary>
        /// 被禁用原因
        /// </summary>
        public string? BanReason { get; set; }
        /// <summary>
        /// 用户禁用时长：单位：分钟
        /// </summary>
        public int? BanLong { get; set; }
        /// <summary>
        /// 禁用 用户ID
        /// </summary>
        public int? Uid { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public int? Addtime { get; set; }
        /// <summary>
        /// 禁用到期时间
        /// </summary>
        public int? EndTime { get; set; }
    }
}
