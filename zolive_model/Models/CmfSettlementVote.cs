using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfSettlementVote
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 状态，0未结算，1已结算
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public int Date { get; set; }
        /// <summary>
        /// 当天总映票
        /// </summary>
        public decimal Votes { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
    }
}
