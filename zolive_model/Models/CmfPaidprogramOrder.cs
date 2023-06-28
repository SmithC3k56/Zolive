using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPaidprogramOrder
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 付费项目发布者ID
        /// </summary>
        public long Touid { get; set; }
        /// <summary>
        /// 付费项目ID
        /// </summary>
        public long ObjectId { get; set; }
        /// <summary>
        /// 支付方式 1 支付宝 2 微信 3 余额
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 订单状态 0 未支付 1 已支付
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string Orderno { get; set; } = null!;
        /// <summary>
        /// 三方订单编号
        /// </summary>
        public string TradeNo { get; set; } = null!;
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Edittime { get; set; }
        /// <summary>
        /// 是否删除 0 否 1 是（用于删除付费项目）
        /// </summary>
        public bool Isdel { get; set; }
    }
}
