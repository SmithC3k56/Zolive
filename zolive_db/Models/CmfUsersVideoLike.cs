using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersVideoLike
    {
        public int Id { get; set; }
        public int? Uid { get; set; }
        public int? Videoid { get; set; }
        public int? Addtime { get; set; }
        /// <summary>
        /// 视频是否被删除或被拒绝 0被删除或被拒绝 1 正常
        /// </summary>
        public bool? Status { get; set; }
    }
}
