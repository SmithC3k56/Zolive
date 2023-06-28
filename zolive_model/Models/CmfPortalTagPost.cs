using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// portal应用 标签文章对应表
    /// </summary>
    public partial class CmfPortalTagPost
    {
        public long Id { get; set; }
        /// <summary>
        /// 标签 id
        /// </summary>
        public ulong TagId { get; set; }
        /// <summary>
        /// 文章 id
        /// </summary>
        public ulong PostId { get; set; }
        /// <summary>
        /// 状态,1:发布;0:不发布
        /// </summary>
        public byte Status { get; set; }
    }
}
