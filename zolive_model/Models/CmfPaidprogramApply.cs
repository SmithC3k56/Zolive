using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPaidprogramApply
    {
        public int Id { get; set; }
        public long Uid { get; set; }
        /// <summary>
        /// 审核状态 -1 拒绝 0 审核中 1 通过
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 抽水比例
        /// </summary>
        public int Percent { get; set; }
    }
}
