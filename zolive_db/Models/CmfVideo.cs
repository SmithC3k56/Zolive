using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideo
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 封面图片
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 封面小图
        /// </summary>
        public string ThumbS { get; set; } = null!;
        /// <summary>
        /// 视频地址
        /// </summary>
        public string Href { get; set; } = null!;
        /// <summary>
        /// 水印视频
        /// </summary>
        public string HrefW { get; set; } = null!;
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Likes { get; set; }
        /// <summary>
        /// 浏览数（涉及到推荐排序机制，所以默认为1）
        /// </summary>
        public int Views { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int Comments { get; set; }
        /// <summary>
        /// 踩总数
        /// </summary>
        public int Steps { get; set; }
        /// <summary>
        /// 分享数量
        /// </summary>
        public int Shares { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 维度
        /// </summary>
        public string Lat { get; set; } = null!;
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng { get; set; } = null!;
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; } = null!;
        /// <summary>
        /// 是否删除 1删除（下架）0不下架
        /// </summary>
        public bool Isdel { get; set; }
        /// <summary>
        /// 视频状态 0未审核 1通过 2拒绝
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 背景音乐ID
        /// </summary>
        public long MusicId { get; set; }
        /// <summary>
        /// 下架原因
        /// </summary>
        public string XiajiaReason { get; set; } = null!;
        /// <summary>
        /// 审核不通过时间（第一次审核不通过时更改此值，用于判断是否发送极光IM）
        /// </summary>
        public int NopassTime { get; set; }
        /// <summary>
        /// 视频完整看完次数(涉及到推荐排序机制，所以默认为1)
        /// </summary>
        public int WatchOk { get; set; }
        /// <summary>
        /// 是否为广告视频 0 否 1 是
        /// </summary>
        public bool IsAd { get; set; }
        /// <summary>
        /// 广告显示到期时间
        /// </summary>
        public long AdEndtime { get; set; }
        /// <summary>
        /// 广告外链
        /// </summary>
        public string AdUrl { get; set; } = null!;
        /// <summary>
        /// 权重值，数字越大越靠前
        /// </summary>
        public int Orderno { get; set; }
        /// <summary>
        /// 视频绑定类型 0 未绑定 1 商品  2 付费内容
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public ulong Goodsid { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int Classid { get; set; }
    }
}
