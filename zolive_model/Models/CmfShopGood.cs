using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopGood
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 商品一级分类
        /// </summary>
        public int OneClassid { get; set; }
        /// <summary>
        /// 商品二级分类
        /// </summary>
        public int TwoClassid { get; set; }
        /// <summary>
        /// 商品三级分类
        /// </summary>
        public int ThreeClassid { get; set; }
        /// <summary>
        /// 商品视频地址
        /// </summary>
        public string VideoUrl { get; set; } = null!;
        /// <summary>
        /// 商品视频封面
        /// </summary>
        public string VideoThumb { get; set; } = null!;
        /// <summary>
        /// 封面
        /// </summary>
        public string Thumbs { get; set; } = null!;
        /// <summary>
        /// 商品文字内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 商品内容图集
        /// </summary>
        public string Pictures { get; set; } = null!;
        /// <summary>
        /// 商品规格
        /// </summary>
        public string Specs { get; set; } = null!;
        /// <summary>
        /// 邮费
        /// </summary>
        public int Postage { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public long Uptime { get; set; }
        /// <summary>
        /// 点击数
        /// </summary>
        public int Hits { get; set; }
        /// <summary>
        /// 状态，0审核中-1商家下架1通过-2管理员下架 2拒绝
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 推荐，0否1是
        /// </summary>
        public bool Isrecom { get; set; }
        /// <summary>
        /// 总销量
        /// </summary>
        public int SaleNums { get; set; }
        /// <summary>
        /// 商品拒绝原因
        /// </summary>
        public string RefuseReason { get; set; } = null!;
        /// <summary>
        /// 商品是否在直播间销售 0 否 1 是
        /// </summary>
        public bool Issale { get; set; }
        /// <summary>
        /// 商品类型 0 站内商品 1 站外商品
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 站外商品原价
        /// </summary>
        public decimal OriginalPrice { get; set; }
        /// <summary>
        /// 站外商品现价
        /// </summary>
        public decimal PresentPrice { get; set; }
        /// <summary>
        /// 站外商品简介
        /// </summary>
        public string GoodsDesc { get; set; } = null!;
        /// <summary>
        /// 站外商品链接
        /// </summary>
        public string Href { get; set; } = null!;
        /// <summary>
        /// 直播间是否展示商品简介 0 否 1 是 默认0
        /// </summary>
        public bool LiveIsshow { get; set; }
    }
}
