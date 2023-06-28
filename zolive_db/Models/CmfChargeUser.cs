using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfChargeUser
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 充值对象ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 钻石数
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 赠送钻石数
        /// </summary>
        public int CoinGive { get; set; }
        /// <summary>
        /// 商家订单号
        /// </summary>
        public string Orderno { get; set; } = null!;
        /// <summary>
        /// 三方平台订单号
        /// </summary>
        public string TradeNo { get; set; } = null!;
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public bool? Type { get; set; }
        /// <summary>
        /// 支付环境
        /// </summary>
        public bool Ambient { get; set; }
        /// <summary>
        /// 是否结算
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// 额度
        /// </summary>
        public decimal Je { get; set; }
    }
}
