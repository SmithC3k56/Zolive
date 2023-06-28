using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class V1MessageTask
    {
        public int TaskId { get; set; }
        /// <summary>
        /// 任务类型
        /// </summary>
        public string TaskType { get; set; } = null!;
        /// <summary>
        /// 信息内容
        /// </summary>
        public string MessageContent { get; set; } = null!;
        /// <summary>
        /// 信贷员ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 执行时间
        /// </summary>
        public int Time { get; set; }
    }
}
