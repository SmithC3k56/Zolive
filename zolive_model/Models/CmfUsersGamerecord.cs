using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersGamerecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 游戏类型
        /// </summary>
        public bool? Action { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public int? Liveuid { get; set; }
        /// <summary>
        /// 游戏ID
        /// </summary>
        public int? Gameid { get; set; }
        /// <summary>
        /// 1位置下注金额
        /// </summary>
        public int? Coin1 { get; set; }
        /// <summary>
        /// 2位置下注金额
        /// </summary>
        public int? Coin2 { get; set; }
        /// <summary>
        /// 3位置下注金额
        /// </summary>
        public int? Coin3 { get; set; }
        /// <summary>
        /// 4位置下注金额
        /// </summary>
        public int? Coin4 { get; set; }
        /// <summary>
        /// 5位置下注金额
        /// </summary>
        public int? Coin5 { get; set; }
        /// <summary>
        /// 6位置下注金额
        /// </summary>
        public int? Coin6 { get; set; }
        /// <summary>
        /// 处理状态 0 未处理 1 已处理
        /// </summary>
        public bool? Status { get; set; }
        /// <summary>
        /// 下注时间
        /// </summary>
        public int? Addtime { get; set; }
    }
}
