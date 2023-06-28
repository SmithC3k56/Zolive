using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfDynamicComment
    {
        public uint Id { get; set; }
        /// <summary>
        /// 评论用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 被评论用户ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 动态ID
        /// </summary>
        public int Dynamicid { get; set; }
        /// <summary>
        /// 评论iD
        /// </summary>
        public int Commentid { get; set; }
        /// <summary>
        /// 上级评论ID
        /// </summary>
        public int Parentid { get; set; }
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
        public int Addtime { get; set; }
        /// <summary>
        /// 类型，0文字1语音
        /// </summary>
        public bool Type { get; set; }
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
