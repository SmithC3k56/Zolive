using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfAgentProfit
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? Uid { get; set; }
        /// <summary>
        /// 一级收益
        /// </summary>
        public decimal? OneProfit { get; set; }
    }
}
