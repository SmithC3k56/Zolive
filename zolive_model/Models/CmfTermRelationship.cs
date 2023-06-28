using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTermRelationship
    {
        public long Tid { get; set; }
        /// <summary>
        /// posts表里文章id
        /// </summary>
        public ulong ObjectId { get; set; }
        /// <summary>
        /// 分类id
        /// </summary>
        public ulong TermId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Listorder { get; set; }
        /// <summary>
        /// 状态，1发布，0不发布
        /// </summary>
        public int Status { get; set; }
    }
}
