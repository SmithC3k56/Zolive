using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopPoint
    {
        /// <summary>
        /// 店铺用户ID
        /// </summary>
        public long ShopUid { get; set; }
        /// <summary>
        /// 评价总数
        /// </summary>
        public long EvaluateTotal { get; set; }
        /// <summary>
        /// 店铺商品质量(商品描述)总分
        /// </summary>
        public int QualityPointsTotal { get; set; }
        /// <summary>
        /// 店铺服务态度总分
        /// </summary>
        public int ServicePointsTotal { get; set; }
        /// <summary>
        /// 物流服务总分
        /// </summary>
        public int ExpressPointsTotal { get; set; }
    }
}
