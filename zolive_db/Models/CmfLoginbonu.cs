using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLoginbonu
    {
        public uint Id { get; set; }
        /// <summary>
        /// 登录天数
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// 登录奖励
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
    }
}
