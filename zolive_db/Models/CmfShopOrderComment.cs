using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopOrderComment
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 商品订单ID
        /// </summary>
        public long Orderid { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long Goodsid { get; set; }
        /// <summary>
        /// 店铺用户id
        /// </summary>
        public long ShopUid { get; set; }
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 评论图片列表
        /// </summary>
        public string Thumbs { get; set; } = null!;
        /// <summary>
        /// 视频封面
        /// </summary>
        public string VideoThumb { get; set; } = null!;
        /// <summary>
        /// 视频地址
        /// </summary>
        public string VideoUrl { get; set; } = null!;
        /// <summary>
        /// 是否匿名 0否 1是
        /// </summary>
        public bool IsAnonym { get; set; }
        /// <summary>
        /// 商品描述评分
        /// </summary>
        public bool QualityPoints { get; set; }
        /// <summary>
        /// 服务态度评分
        /// </summary>
        public bool ServicePoints { get; set; }
        /// <summary>
        /// 物流速度评分
        /// </summary>
        public bool ExpressPoints { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 是否是追评0 否 1 是
        /// </summary>
        public bool IsAppend { get; set; }
    }
}
