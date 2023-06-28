using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoCommentsLike
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 评论ID
        /// </summary>
        public ulong Commentid { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 被喜欢的评论者id
        /// </summary>
        public ulong Touid { get; set; }
        /// <summary>
        /// 评论所属视频id
        /// </summary>
        public ulong Videoid { get; set; }
    }
}
