using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoReport
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 被举报用户ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public ulong Videoid { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 0处理中 1已处理  2审核失败
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Uptime { get; set; }
    }
}
