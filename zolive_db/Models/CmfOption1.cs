using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfOption1
    {
        public ulong OptionId { get; set; }
        /// <summary>
        /// 配置名
        /// </summary>
        public string OptionName { get; set; } = null!;
        /// <summary>
        /// 配置值
        /// </summary>
        public string OptionValue { get; set; } = null!;
        /// <summary>
        /// 是否自动加载
        /// </summary>
        public int Autoload { get; set; }
    }
}
