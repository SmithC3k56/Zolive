using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopOrderRefundList
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public long Orderid { get; set; }
        /// <summary>
        /// 处理方 1 买家 2 卖家 3 平台 4 系统
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 处理说明
        /// </summary>
        public string Desc { get; set; } = null!;
        /// <summary>
        /// 处理备注说明
        /// </summary>
        public string HandleDesc { get; set; } = null!;
        /// <summary>
        /// 卖家拒绝理由
        /// </summary>
        public string RefuseReason { get; set; } = null!;
    }
}
