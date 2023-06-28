using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersReport
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 对方ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
    }
}
