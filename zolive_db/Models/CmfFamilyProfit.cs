using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfFamilyProfit
    {
        public uint Id { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 家族ID
        /// </summary>
        public int Familyid { get; set; }
        /// <summary>
        /// 格式化日期
        /// </summary>
        public string Time { get; set; } = null!;
        /// <summary>
        /// 主播收益
        /// </summary>
        public decimal ProfitAnthor { get; set; }
        /// <summary>
        /// 总收益
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 家族收益
        /// </summary>
        public decimal Profit { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public uint Addtime { get; set; }
    }
}
