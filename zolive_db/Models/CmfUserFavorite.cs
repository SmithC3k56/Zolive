using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户收藏表
    /// </summary>
    public partial class CmfUserFavorite
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户 id
        /// </summary>
        public ulong UserId { get; set; }
        /// <summary>
        /// 收藏内容的标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumbnail { get; set; } = null!;
        /// <summary>
        /// 收藏内容的原文地址，JSON格式
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// 收藏内容的描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 收藏实体以前所在表,不带前缀
        /// </summary>
        public string TableName { get; set; } = null!;
        /// <summary>
        /// 收藏内容原来的主键id
        /// </summary>
        public uint? ObjectId { get; set; }
        /// <summary>
        /// 收藏时间
        /// </summary>
        public uint? CreateTime { get; set; }
    }
}
