using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfAgentProfitRecode
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? Uid { get; set; }
        /// <summary>
        /// 消费总数
        /// </summary>
        public int? Total { get; set; }
        /// <summary>
        /// 一级ID
        /// </summary>
        public int? OneUid { get; set; }
        /// <summary>
        /// 一级收益
        /// </summary>
        public decimal? OneProfit { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int? Addtime { get; set; }
    }
}
