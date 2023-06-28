using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfDynamic
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 图片地址：多张图片用分号隔开
        /// </summary>
        public string? Thumb { get; set; }
        /// <summary>
        /// 视频封面
        /// </summary>
        public string? VideoThumb { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string? Href { get; set; }
        /// <summary>
        /// 语音链接
        /// </summary>
        public string? Voice { get; set; }
        /// <summary>
        /// 语音时长
        /// </summary>
        public int? Length { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int Comments { get; set; }
        /// <summary>
        /// 动态类型：0：纯文字；1：文字+图片；2：文字+视频；3：文字+语音
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 是否删除 1删除（下架）0不下架
        /// </summary>
        public bool Isdel { get; set; }
        /// <summary>
        /// 视频状态 0未审核 1通过 2拒绝
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 审核不通过时间（第一次审核不通过时更改此值，用于判断是否发送极光IM）
        /// </summary>
        public int? Uptime { get; set; }
        /// <summary>
        /// 下架原因
        /// </summary>
        public string? XiajiaReason { get; set; }
        /// <summary>
        /// 维度
        /// </summary>
        public string? Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string? Lng { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 详细地理位置
        /// </summary>
        public string? Address { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 审核原因
        /// </summary>
        public string? FailReason { get; set; }
        /// <summary>
        /// 曝光值
        /// </summary>
        public int ShowVal { get; set; }
        /// <summary>
        /// 推荐值
        /// </summary>
        public int? RecommendVal { get; set; }
        public string ThumbArs { get; set; } = null!;
    }
}
