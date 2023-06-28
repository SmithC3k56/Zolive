using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLiveBan
    {
        /// <summary>
        /// 主播ID
        /// </summary>
        public uint Liveuid { get; set; }
        /// <summary>
        /// 超管ID
        /// </summary>
        public uint Superid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
