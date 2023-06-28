using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfDynamicComment
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 评论用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 被评论用户ID
        /// </summary>
        public ulong Touid { get; set; }
        /// <summary>
        /// 动态ID
        /// </summary>
        public ulong Dynamicid { get; set; }
        /// <summary>
        /// 评论iD
        /// </summary>
        public ulong Commentid { get; set; }
        /// <summary>
        /// 上级评论ID
        /// </summary>
        public ulong Parentid { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 类型，0文字1语音
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 语音链接
        /// </summary>
        public string Voice { get; set; } = null!;
        /// <summary>
        /// 时长
        /// </summary>
        public int Length { get; set; }
    }
}
