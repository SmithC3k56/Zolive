using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTurntableCon
    {
        public uint Id { get; set; }
        /// <summary>
        /// 次数
        /// </summary>
        public int Times { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
    }
}
