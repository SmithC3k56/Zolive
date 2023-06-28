using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfChargeRule
    {
        public uint Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 钻石数
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 苹果钻石数
        /// </summary>
        public int CoinIos { get; set; }
        /// <summary>
        /// 安卓金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 苹果项目ID
        /// </summary>
        public string ProductId { get; set; } = null!;
        /// <summary>
        /// 赠送钻石数
        /// </summary>
        public int Give { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
