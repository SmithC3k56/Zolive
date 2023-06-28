using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersChargeAdmin
    {
        public uint Id { get; set; }
        /// <summary>
        /// 充值对象ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 钻石数
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public string Admin { get; set; } = null!;
        /// <summary>
        /// IP
        /// </summary>
        public string Ip { get; set; } = null!;
    }
}
