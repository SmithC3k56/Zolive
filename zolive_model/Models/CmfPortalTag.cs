using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// portal应用 文章标签表
    /// </summary>
    public partial class CmfPortalTag
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// 状态,1:发布,0:不发布
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 是否推荐;1:推荐;0:不推荐
        /// </summary>
        public byte Recommended { get; set; }
        /// <summary>
        /// 标签文章数
        /// </summary>
        public ulong PostCount { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
