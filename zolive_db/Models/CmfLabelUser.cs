using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLabelUser
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Id { get; set; }
        public ulong Uid { get; set; }
        /// <summary>
        /// 对方ID
        /// </summary>
        public ulong Touid { get; set; }
        /// <summary>
        /// 选择的标签
        /// </summary>
        public string Label { get; set; } = null!;
        /// <summary>
        /// 添加时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public long Uptime { get; set; }
    }
}
