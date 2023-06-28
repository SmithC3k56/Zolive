using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersLabel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 对方ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 选择的标签
        /// </summary>
        public string Label { get; set; } = null!;
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
