using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLuckRate
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
        /// 倍数
        /// </summary>
        public uint Times { get; set; }
        /// <summary>
        /// 中奖概率
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 是否全站，0否1是
        /// </summary>
        public sbyte Isall { get; set; }
    }
}
