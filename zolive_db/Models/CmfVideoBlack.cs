using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoBlack
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public ulong Videoid { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
