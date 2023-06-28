using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPost
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 发表者id
        /// </summary>
        public ulong? PostAuthor { get; set; }
        /// <summary>
        /// seo keywords
        /// </summary>
        public string? PostKeywords { get; set; }
        /// <summary>
        /// 转载文章的来源
        /// </summary>
        public string? PostSource { get; set; }
        /// <summary>
        /// post创建日期，永久不变，一般不显示给用户
        /// </summary>
        public DateTime? PostDate { get; set; }
        /// <summary>
        /// post内容
        /// </summary>
        public string? PostContent { get; set; }
        /// <summary>
        /// post标题
        /// </summary>
        public string? PostTitle { get; set; }
        /// <summary>
        /// post摘要
        /// </summary>
        public string? PostExcerpt { get; set; }
        /// <summary>
        /// post状态，1已审核，0未审核
        /// </summary>
        public int? PostStatus { get; set; }
        /// <summary>
        /// 评论状态，1允许，0不允许
        /// </summary>
        public int? CommentStatus { get; set; }
        /// <summary>
        /// post更新时间，可在前台修改，显示给用户
        /// </summary>
        public DateTime? PostModified { get; set; }
        public string? PostContentFiltered { get; set; }
        /// <summary>
        /// post的父级post id,表示post层级关系
        /// </summary>
        public ulong? PostParent { get; set; }
        public int? PostType { get; set; }
        public string? PostMimeType { get; set; }
        public long? CommentCount { get; set; }
        /// <summary>
        /// post的扩展字段，保存相关扩展属性，如缩略图；格式为json
        /// </summary>
        public string? Smeta { get; set; }
        /// <summary>
        /// post点击数，查看数
        /// </summary>
        public int? PostHits { get; set; }
        /// <summary>
        /// post赞数
        /// </summary>
        public int? PostLike { get; set; }
        /// <summary>
        /// 置顶 1置顶； 0不置顶
        /// </summary>
        public bool? Istop { get; set; }
        /// <summary>
        /// 推荐 1推荐 0不推荐
        /// </summary>
        public bool? Recommended { get; set; }
        public int? Orderno { get; set; }
        public int? Type { get; set; }
    }
}
