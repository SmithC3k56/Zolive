using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 系统钩子插件表
    /// </summary>
    public partial class CmfHookPlugin
    {
        public uint Id { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 状态(0:禁用,1:启用)
        /// </summary>
        public sbyte Status { get; set; }
        /// <summary>
        /// 钩子名
        /// </summary>
        public string Hook { get; set; } = null!;
        /// <summary>
        /// 插件
        /// </summary>
        public string Plugin { get; set; } = null!;
    }
}
