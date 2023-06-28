using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfFamilyUserDivideApply
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 家族id
        /// </summary>
        public int Familyid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 处理状态 0 等待审核 1 同意 -1 拒绝
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 家族分成
        /// </summary>
        public int Divide { get; set; }
    }
}
