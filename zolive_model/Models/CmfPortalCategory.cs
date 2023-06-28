using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// portal应用 文章分类表
    /// </summary>
    public partial class CmfPortalCategory
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// 分类父id
        /// </summary>
        public ulong ParentId { get; set; }
        /// <summary>
        /// 分类文章数
        /// </summary>
        public ulong PostCount { get; set; }
        /// <summary>
        /// 状态,1:发布,0:不发布
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public uint DeleteTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 分类描述
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 分类层级关系路径
        /// </summary>
        public string Path { get; set; } = null!;
        public string SeoTitle { get; set; } = null!;
        public string SeoKeywords { get; set; } = null!;
        public string SeoDescription { get; set; } = null!;
        /// <summary>
        /// 分类列表模板
        /// </summary>
        public string ListTpl { get; set; } = null!;
        /// <summary>
        /// 分类文章页模板
        /// </summary>
        public string OneTpl { get; set; } = null!;
        /// <summary>
        /// 扩展属性
        /// </summary>
        public string? More { get; set; }
    }
}
