using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPaidprogramComment
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 项目发布者ID
        /// </summary>
        public long Touid { get; set; }
        /// <summary>
        /// 付费项目ID
        /// </summary>
        public long ObjectId { get; set; }
        /// <summary>
        /// 评价等级
        /// </summary>
        public bool Grade { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
