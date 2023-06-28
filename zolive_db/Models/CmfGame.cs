using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGame
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 游戏名称
        /// </summary>
        public bool? Action { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public ulong Liveuid { get; set; }
        /// <summary>
        /// 庄家ID，0表示平台
        /// </summary>
        public int? Bankerid { get; set; }
        /// <summary>
        /// 直播流名
        /// </summary>
        public string? Stream { get; set; }
        /// <summary>
        /// 本次游戏开始时间
        /// </summary>
        public int? Starttime { get; set; }
        /// <summary>
        /// 游戏结束时间
        /// </summary>
        public long Endtime { get; set; }
        /// <summary>
        /// 本轮游戏结果
        /// </summary>
        public string? Result { get; set; }
        /// <summary>
        /// 当前游戏状态（0是进行中，1是正常结束，2是 主播关闭 3意外结束）
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 庄家收益
        /// </summary>
        public int? BankerProfit { get; set; }
        /// <summary>
        /// 庄家牌型
        /// </summary>
        public string? BankerCard { get; set; }
        /// <summary>
        /// 是否进行系统干预
        /// </summary>
        public bool? Isintervene { get; set; }
    }
}
