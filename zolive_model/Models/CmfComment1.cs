using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfComment1
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 评论内容所在表，不带表前缀
        /// </summary>
        public string PostTable { get; set; } = null!;
        /// <summary>
        /// 评论内容 id
        /// </summary>
        public uint PostId { get; set; }
        /// <summary>
        /// 原文地址
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// 发表评论的用户id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 被评论的用户id
        /// </summary>
        public int ToUid { get; set; }
        /// <summary>
        /// 评论者昵称
        /// </summary>
        public string? FullName { get; set; }
        /// <summary>
        /// 评论者邮箱
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 评论类型；1实名评论
        /// </summary>
        public short Type { get; set; }
        /// <summary>
        /// 被回复的评论id
        /// </summary>
        public ulong Parentid { get; set; }
        public string? Path { get; set; }
        /// <summary>
        /// 状态，1已审核，0未审核
        /// </summary>
        public short Status { get; set; }
    }
}
