using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoLike
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public int Videoid { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 视频是否被删除或被拒绝 0被删除或被拒绝 1 正常
        /// </summary>
        public bool? Status { get; set; }
    }
}
