using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfRedRecord
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 红包ID
        /// </summary>
        public int Redid { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
