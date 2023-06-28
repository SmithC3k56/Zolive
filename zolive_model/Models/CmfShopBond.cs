using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopBond
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 保证金
        /// </summary>
        public int Bond { get; set; }
        /// <summary>
        /// 状态，0已退回1已支付,-1已扣除
        /// </summary>
        public sbyte Status { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public long Uptime { get; set; }
    }
}
