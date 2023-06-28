using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户操作积分等奖励日志表
    /// </summary>
    public partial class CmfUserScoreLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户 id
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public int CreateTime { get; set; }
        /// <summary>
        /// 用户操作名称
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 更改积分，可以为负
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 更改金币，可以为负
        /// </summary>
        public int Coin { get; set; }
    }
}
