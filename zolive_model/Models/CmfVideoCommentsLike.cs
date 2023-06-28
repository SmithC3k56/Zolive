using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoCommentsLike
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 评论ID
        /// </summary>
        public int Commentid { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 被喜欢的评论者id
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 评论所属视频id
        /// </summary>
        public int Videoid { get; set; }
    }
}
