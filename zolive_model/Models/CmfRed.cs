using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfRed
    {
        public uint Id { get; set; }
        /// <summary>
        /// 直播标识
        /// </summary>
        public int Showid { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public int Liveuid { get; set; }
        /// <summary>
        /// 红包类型，0平均，1手气
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 发放类型，0立即，1延迟
        /// </summary>
        public bool TypeGrant { get; set; }
        /// <summary>
        /// 钻石数
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Nums { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; } = null!;
        /// <summary>
        /// 生效时间
        /// </summary>
        public int Effecttime { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 状态，0抢中，1抢完
        /// </summary>
        public sbyte Status { get; set; }
        /// <summary>
        /// 钻石数
        /// </summary>
        public int CoinRob { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int NumsRob { get; set; }
    }
}
