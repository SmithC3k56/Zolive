using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户点赞表
    /// </summary>
    public partial class CmfUserLike
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户 id
        /// </summary>
        public ulong UserId { get; set; }
        /// <summary>
        /// 内容原来的主键id
        /// </summary>
        public uint ObjectId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 内容以前所在表,不带前缀
        /// </summary>
        public string TableName { get; set; } = null!;
        /// <summary>
        /// 内容的原文地址，不带域名
        /// </summary>
        public string Url { get; set; } = null!;
        /// <summary>
        /// 内容的标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumbnail { get; set; } = null!;
        /// <summary>
        /// 内容的描述
        /// </summary>
        public string? Description { get; set; }
    }
}
