using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersAgentProfitRecode
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
        /// 二级ID
        /// </summary>
        public int? TwoUid { get; set; }
        /// <summary>
        /// 三级ID
        /// </summary>
        public int? ThreeUid { get; set; }
        /// <summary>
        /// 一级代理收益
        /// </summary>
        public decimal? OneProfit { get; set; }
        /// <summary>
        /// 二级代理收益
        /// </summary>
        public decimal? TwoProfit { get; set; }
        /// <summary>
        /// 三级代理收益
        /// </summary>
        public decimal? ThreeProfit { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int? Addtime { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        public string? Content { get; set; }
    }
}
