using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfDynamicLike
    {
        public uint Id { get; set; }
        /// <summary>
        /// 点赞用户
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 动态id
        /// </summary>
        public ulong Dynamicid { get; set; }
        /// <summary>
        /// 点赞时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 动态是否被删除或被拒绝 0被删除或被拒绝 1 正常
        /// </summary>
        public bool? Status { get; set; }
    }
}
