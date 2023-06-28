using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfDynamicCommentsLike
    {
        public uint Id { get; set; }
        /// <summary>
        /// 点赞用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 评论ID
        /// </summary>
        public int Commentid { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 被喜欢的评论者id
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 评论所属动态id
        /// </summary>
        public int Dynamicid { get; set; }
    }
}
