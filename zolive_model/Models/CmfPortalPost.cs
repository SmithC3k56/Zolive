using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// portal应用 文章表
    /// </summary>
    public partial class CmfPortalPost
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public ulong ParentId { get; set; }
        /// <summary>
        /// 类型,1:文章;2:页面
        /// </summary>
        public byte PostType { get; set; }
        /// <summary>
        /// 内容格式;1:html;2:md
        /// </summary>
        public byte PostFormat { get; set; }
        /// <summary>
        /// 发表者用户id
        /// </summary>
        public ulong UserId { get; set; }
        /// <summary>
        /// 状态;1:已发布;0:未发布;
        /// </summary>
        public byte PostStatus { get; set; }
        /// <summary>
        /// 评论状态;1:允许;0:不允许
        /// </summary>
        public byte CommentStatus { get; set; }
        /// <summary>
        /// 是否置顶;1:置顶;0:不置顶
        /// </summary>
        public byte IsTop { get; set; }
        /// <summary>
        /// 是否推荐;1:推荐;0:不推荐
        /// </summary>
        public byte Recommended { get; set; }
        /// <summary>
        /// 查看数
        /// </summary>
        public ulong PostHits { get; set; }
        /// <summary>
        /// 收藏数
        /// </summary>
        public uint PostFavorites { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public ulong PostLike { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public ulong CommentCount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public uint UpdateTime { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public uint PublishedTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public uint DeleteTime { get; set; }
        /// <summary>
        /// post标题
        /// </summary>
        public string PostTitle { get; set; } = null!;
        /// <summary>
        /// seo keywords
        /// </summary>
        public string PostKeywords { get; set; } = null!;
        /// <summary>
        /// post摘要
        /// </summary>
        public string PostExcerpt { get; set; } = null!;
        /// <summary>
        /// 转载文章的来源
        /// </summary>
        public string PostSource { get; set; } = null!;
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumbnail { get; set; } = null!;
        /// <summary>
        /// 文章内容
        /// </summary>
        public string? PostContent { get; set; }
        /// <summary>
        /// 处理过的文章内容
        /// </summary>
        public string? PostContentFiltered { get; set; }
        /// <summary>
        /// 扩展属性,如缩略图;格式为json
        /// </summary>
        public string? More { get; set; }
        /// <summary>
        /// 页面类型，0单页面，2关于我们
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        public string PostTitleEn { get; set; } = null!;
        public string PostTitleNam { get; set; } = null!;
        public string PostContentEn { get; set; } = null!;
        public string PostContentNam { get; set; } = null!;
    }
}
