using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersCashrecord
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 提现金额
        /// </summary>
        public int Money { get; set; }
        /// <summary>
        /// 提现映票数
        /// </summary>
        public int Votes { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string Orderno { get; set; } = null!;
        /// <summary>
        /// 三方订单号
        /// </summary>
        public string TradeNo { get; set; } = null!;
        /// <summary>
        /// 状态，0审核中，1审核通过，2审核拒绝
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 账号类型
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string AccountBank { get; set; } = null!;
        /// <summary>
        /// 帐号
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;
        public int State { get; set; }
    }
}
