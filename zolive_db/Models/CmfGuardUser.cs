using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGuardUser
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public ulong Liveuid { get; set; }
        /// <summary>
        /// 守护类型,1普通守护，2尊贵守护
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public int Endtime { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
