using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTerm
    {
        /// <summary>
        /// 分类id
        /// </summary>
        public ulong TermId { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string? Name { get; set; }
        public string? Slug { get; set; }
        /// <summary>
        /// 分类类型
        /// </summary>
        public string? Taxonomy { get; set; }
        /// <summary>
        /// 分类描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 分类父id
        /// </summary>
        public ulong? Parent { get; set; }
        /// <summary>
        /// 分类文章数
        /// </summary>
        public long? Count { get; set; }
        /// <summary>
        /// 分类层级关系路径
        /// </summary>
        public string? Path { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoKeywords { get; set; }
        public string? SeoDescription { get; set; }
        /// <summary>
        /// 分类列表模板
        /// </summary>
        public string? ListTpl { get; set; }
        /// <summary>
        /// 分类文章页模板
        /// </summary>
        public string? OneTpl { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Listorder { get; set; }
        /// <summary>
        /// 状态，1发布，0不发布
        /// </summary>
        public int Status { get; set; }
    }
}
