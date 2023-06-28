using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersCoinrecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 收支类型
        /// </summary>
        public string Type { get; set; } = null!;
        /// <summary>
        /// 收支行为
        /// </summary>
        public string Action { get; set; } = null!;
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
        /// 标识，1表示热门礼物，2表示守护礼物
        /// </summary>
        public bool Mark { get; set; }
    }
}
