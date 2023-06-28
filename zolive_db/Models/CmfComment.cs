using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 评论表
    /// </summary>
    public partial class CmfComment
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 被回复的评论id
        /// </summary>
        public ulong ParentId { get; set; }
        /// <summary>
        /// 发表评论的用户id
        /// </summary>
        public uint UserId { get; set; }
        /// <summary>
        /// 被评论的用户id
        /// </summary>
        public uint ToUserId { get; set; }
        /// <summary>
        /// 评论内容 id
        /// </summary>
        public uint ObjectId { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public uint LikeCount { get; set; }
        /// <summary>
        /// 不喜欢数
        /// </summary>
        public uint DislikeCount { get; set; }
        /// <summary>
        /// 楼层数
        /// </summary>
        public uint Floor { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public uint DeleteTime { get; set; }
        /// <summary>
        /// 状态,1:已审核,0:未审核
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 评论类型；1实名评论
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 评论内容所在表，不带表前缀
        /// </summary>
        public string TableName { get; set; } = null!;
        /// <summary>
        /// 评论者昵称
        /// </summary>
        public string FullName { get; set; } = null!;
        /// <summary>
        /// 评论者邮箱
        /// </summary>
        public string Email { get; set; } = null!;
        /// <summary>
        /// 层级关系
        /// </summary>
        public string Path { get; set; } = null!;
        /// <summary>
        /// 原文地址
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 扩展属性
        /// </summary>
        public string? More { get; set; }
    }
}
