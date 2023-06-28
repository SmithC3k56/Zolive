using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoComment
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 评论用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 被评论的用户ID
        /// </summary>
        public ulong Touid { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public ulong Videoid { get; set; }
        /// <summary>
        /// 所属评论ID
        /// </summary>
        public ulong Commentid { get; set; }
        /// <summary>
        /// 上级评论ID
        /// </summary>
        public ulong Parentid { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 评论时被@用户的信息（json串）
        /// </summary>
        public string AtInfo { get; set; } = null!;
    }
}
