using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserBalanceRecord
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 对方用户id
        /// </summary>
        public long Touid { get; set; }
        /// <summary>
        /// 操作的余额数
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 收支类型,0支出1收入
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 收支行为 1 买家使用余额付款 2 系统自动结算货款给卖家  3 卖家超时未发货,退款给买家 4 买家发起退款，卖家超时未处理,系统自动退款 5买家发起退款，卖家同意 6 买家发起退款，平台介入后同意 7 用户使用余额购买付费项目  8 付费项目收入
        /// </summary>
        public bool Action { get; set; }
        /// <summary>
        /// 对应的订单ID
        /// </summary>
        public long Orderid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
