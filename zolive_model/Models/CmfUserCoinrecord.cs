using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserCoinrecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 收支类型,0支出1收入
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 收支行为，1赠送礼物,2弹幕,3登录奖励,4购买VIP,5购买坐骑,6房间扣费,7计时扣费,8发送红包,9抢红包,10开通守护,11注册奖励,12礼物中奖,13奖池中奖,14缴纳保证金,15退还保证金,16转盘游戏,17转盘中奖,18购买靓号
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
        /// 标识，1表示热门礼物，2表示守护礼物
        /// </summary>
        public bool Mark { get; set; }
        /// <summary>
        /// 是否结算
        /// </summary>
        public int Status { get; set; }
    }
}
