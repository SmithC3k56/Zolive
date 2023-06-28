using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersVideoComment
    {
        public int Id { get; set; }
        public int? Uid { get; set; }
        public int? Touid { get; set; }
        public int? Videoid { get; set; }
        public int? Commentid { get; set; }
        public int? Parentid { get; set; }
        public string? Content { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int? Likes { get; set; }
        public int? Addtime { get; set; }
        /// <summary>
        /// 评论时被@用户的信息（json串）
        /// </summary>
        public string? AtInfo { get; set; }
    }
}
