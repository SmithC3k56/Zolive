using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoComment
    {
        public int Id { get; set; }
        /// <summary>
        /// 评论用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 被评论的用户ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public int Videoid { get; set; }
        /// <summary>
        /// 所属评论ID
        /// </summary>
        public int Commentid { get; set; }
        /// <summary>
        /// 上级评论ID
        /// </summary>
        public int Parentid { get; set; }
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
        public int Addtime { get; set; }
        /// <summary>
        /// 评论时被@用户的信息（json串）
        /// </summary>
        public string AtInfo { get; set; } = null!;
    }
}
