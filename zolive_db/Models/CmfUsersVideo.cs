using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersVideo
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? Uid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 封面图片
        /// </summary>
        public string? Thumb { get; set; }
        /// <summary>
        /// 封面小图
        /// </summary>
        public string? ThumbS { get; set; }
        /// <summary>
        /// 视频地址
        /// </summary>
        public string? Href { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int? Likes { get; set; }
        /// <summary>
        /// 浏览数（涉及到推荐排序机制，所以默认为1）
        /// </summary>
        public int? Views { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int? Comments { get; set; }
        /// <summary>
        /// 踩总数
        /// </summary>
        public int? Steps { get; set; }
        /// <summary>
        /// 分享数量
        /// </summary>
        public int? Shares { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public int? Addtime { get; set; }
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
        /// 是否删除 1删除（下架）0不下架
        /// </summary>
        public bool? Isdel { get; set; }
        /// <summary>
        /// 视频状态 0未审核 1通过 2拒绝
        /// </summary>
        public bool? Status { get; set; }
        /// <summary>
        /// 背景音乐ID
        /// </summary>
        public int? MusicId { get; set; }
        /// <summary>
        /// 下架原因
        /// </summary>
        public string? XiajiaReason { get; set; }
        /// <summary>
        /// 曝光值
        /// </summary>
        public int? ShowVal { get; set; }
        /// <summary>
        /// 审核不通过时间（第一次审核不通过时更改此值，用于判断是否发送极光IM）
        /// </summary>
        public int? NopassTime { get; set; }
        /// <summary>
        /// 视频完整看完次数(涉及到推荐排序机制，所以默认为1)
        /// </summary>
        public int? WatchOk { get; set; }
        /// <summary>
        /// 是否为广告视频 0 否 1 是
        /// </summary>
        public bool? IsAd { get; set; }
        /// <summary>
        /// 广告显示到期时间
        /// </summary>
        public int? AdEndtime { get; set; }
        /// <summary>
        /// 广告外链
        /// </summary>
        public string? AdUrl { get; set; }
        /// <summary>
        /// 权重值，数字越大越靠前
        /// </summary>
        public int? Orderno { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long Goodsid { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public int? Videoclassid { get; set; }
        /// <summary>
        /// 完整视频地址
        /// </summary>
        public string? AllVideoUrl { get; set; }
    }
}
