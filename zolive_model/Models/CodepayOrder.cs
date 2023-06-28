using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用于区分是否已经处理
    /// </summary>
    public partial class CodepayOrder
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID或订单ID
        /// </summary>
        public string PayId { get; set; } = null!;
        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 流水号
        /// </summary>
        public string PayNo { get; set; } = null!;
        /// <summary>
        /// 自定义参数
        /// </summary>
        public string? Param { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public long PayTime { get; set; }
        /// <summary>
        /// 金额的备注
        /// </summary>
        public string PayTag { get; set; } = null!;
        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public long CreatTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpTime { get; set; }
    }
}
