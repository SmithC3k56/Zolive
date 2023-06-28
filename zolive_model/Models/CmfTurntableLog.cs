using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTurntableLog
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public long Liveuid { get; set; }
        /// <summary>
        /// 直播标识
        /// </summary>
        public long Showid { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Nums { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 是否中奖
        /// </summary>
        public bool Iswin { get; set; }
    }
}
