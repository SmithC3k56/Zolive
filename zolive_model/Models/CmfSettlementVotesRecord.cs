using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfSettlementVotesRecord
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        public int Date { get; set; }
        /// <summary>
        /// 结算映票
        /// </summary>
        public decimal Votes { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 结算时间段
        /// </summary>
        public string TimeSlot { get; set; } = null!;
    }
}
