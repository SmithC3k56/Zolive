using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 发布任务钻石明细
    /// </summary>
    public partial class CmfTheDetail
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? Userid { get; set; }
        /// <summary>
        /// 领取任务人ID
        /// </summary>
        public int? UserId1 { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public int? TaskId { get; set; }
        /// <summary>
        /// 获得钻石
        /// </summary>
        public double? Coin { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? Endtime { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? Addtime { get; set; }
    }
}
