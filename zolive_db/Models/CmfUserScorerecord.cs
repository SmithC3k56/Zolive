using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserScorerecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 收支类型,0支出1收入
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 收支行为，4购买VIP,5购买坐骑,18购买靓号,21游戏获胜
        /// </summary>
        public bool Action { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 对方ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 行为对应ID
        /// </summary>
        public int Giftid { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Giftcount { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public int Totalcoin { get; set; }
        /// <summary>
        /// 直播标识
        /// </summary>
        public int Showid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 游戏类型
        /// </summary>
        public bool GameAction { get; set; }
    }
}
