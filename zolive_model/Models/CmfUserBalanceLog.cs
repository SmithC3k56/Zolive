using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户余额变更日志表
    /// </summary>
    public partial class CmfUserBalanceLog
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户 id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 更改余额
        /// </summary>
        public decimal Change { get; set; }
        /// <summary>
        /// 更改后余额
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = null!;
    }
}
