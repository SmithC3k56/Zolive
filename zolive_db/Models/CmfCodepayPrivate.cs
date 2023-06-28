using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfCodepayPrivate
    {
        public int Id { get; set; }
        /// <summary>
        /// 码支付ID
        /// </summary>
        public int CodepayId { get; set; }
        /// <summary>
        /// 码支付Key
        /// </summary>
        public string CodepayKey { get; set; } = null!;
        /// <summary>
        /// 码支付倍数
        /// </summary>
        public int CodepayMultiple { get; set; }
    }
}
