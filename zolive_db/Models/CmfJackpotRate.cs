using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfJackpotRate
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 礼物ID
        /// </summary>
        public int Giftid { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public uint Nums { get; set; }
        /// <summary>
        /// 奖池概率
        /// </summary>
        public string? RateJackpot { get; set; }
    }
}
