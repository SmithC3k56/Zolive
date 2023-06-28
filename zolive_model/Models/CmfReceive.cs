using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 领取任务表
    /// </summary>
    public partial class CmfReceive
    {
        public int Id { get; set; }
        /// <summary>
        /// 领取人ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskId { get; set; }
        /// <summary>
        /// 分享的连接
        /// </summary>
        public string Link { get; set; } = null!;
        /// <summary>
        /// 领取时间
        /// </summary>
        public DateTime ReceiveTime { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime Addtime { get; set; }
    }
}
