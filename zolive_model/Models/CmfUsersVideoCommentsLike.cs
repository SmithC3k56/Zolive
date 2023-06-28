using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersVideoCommentsLike
    {
        public int Id { get; set; }
        public int? Uid { get; set; }
        public int? Commentid { get; set; }
        public int? Addtime { get; set; }
        /// <summary>
        /// 被喜欢的评论者id
        /// </summary>
        public int? Touid { get; set; }
        /// <summary>
        /// 评论所属视频id
        /// </summary>
        public int? Videoid { get; set; }
    }
}
