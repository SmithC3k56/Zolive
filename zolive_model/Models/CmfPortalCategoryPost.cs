using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// portal应用 分类文章对应表
    /// </summary>
    public partial class CmfPortalCategoryPost
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 文章id
        /// </summary>
        public ulong PostId { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public ulong CategoryId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 状态,1:发布;0:不发布
        /// </summary>
        public byte Status { get; set; }
    }
}
