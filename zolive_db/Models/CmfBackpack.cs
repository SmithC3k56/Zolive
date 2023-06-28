using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfBackpack
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 礼物ID
        /// </summary>
        public int Giftid { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Nums { get; set; }
    }
}
