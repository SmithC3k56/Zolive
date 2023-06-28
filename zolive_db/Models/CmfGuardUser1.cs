using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGuardUser1
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 主播ID
        /// </summary>
        public int Liveuid { get; set; }
        /// <summary>
        /// 守护类型,1普通守护，2尊贵守护
        /// </summary>
        public bool Type { get; set; }
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
