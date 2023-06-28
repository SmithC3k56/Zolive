using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfJackpot
    {
        public uint Id { get; set; }
        /// <summary>
        /// 奖池金额
        /// </summary>
        public long Total { get; set; }
        /// <summary>
        /// 奖池等级
        /// </summary>
        public sbyte Level { get; set; }
    }
}
