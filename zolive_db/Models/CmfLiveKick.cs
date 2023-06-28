using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLiveKick
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public uint Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public uint Liveuid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 操作用户ID
        /// </summary>
        public int Actionid { get; set; }
    }
}
