using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserVoterecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 收支类型,0支出，1收入
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 收支行为,1收礼物2弹幕3分销收益4家族长收益6房间收费7计时收费10守护
        /// </summary>
        public short Action { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 来源用户ID
        /// </summary>
        public long Fromid { get; set; }
        /// <summary>
        /// 行为对应ID
        /// </summary>
        public long Actionid { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public long Nums { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// 直播标识
        /// </summary>
        public ulong Showid { get; set; }
        /// <summary>
        /// 收益映票
        /// </summary>
        public decimal Votes { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public long Addtime { get; set; }
    }
}
