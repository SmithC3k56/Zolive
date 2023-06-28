using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 全站配置表
    /// </summary>
    public partial class CmfOption
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 是否自动加载;1:自动加载;0:不自动加载
        /// </summary>
        public byte Autoload { get; set; }
        /// <summary>
        /// 配置名
        /// </summary>
        public string OptionName { get; set; } = null!;
        /// <summary>
        /// 配置值
        /// </summary>
        public string? OptionValue { get; set; }
    }
}
