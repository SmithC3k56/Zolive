using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 系统钩子表
    /// </summary>
    public partial class CmfHook
    {
        public uint Id { get; set; }
        /// <summary>
        /// 钩子类型(1:系统钩子;2:应用钩子;3:模板钩子;4:后台模板钩子)
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 是否只允许一个插件运行(0:多个;1:一个)
        /// </summary>
        public byte Once { get; set; }
        /// <summary>
        /// 钩子名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 钩子
        /// </summary>
        public string Hook { get; set; } = null!;
        /// <summary>
        /// 应用名(只有应用钩子才用)
        /// </summary>
        public string App { get; set; } = null!;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = null!;
    }
}
