using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfCashAccount
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 类型，1表示支付宝，2表示微信，3表示银行卡
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string AccountBank { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 添加时间
        /// </summary>
        public long Addtime { get; set; }
    }
}
