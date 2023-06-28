using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 注册记录表
    /// </summary>
    public partial class CmfRecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskId { get; set; }
        /// <summary>
        /// 领取人ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 1、未完成 2、已完成
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Addtime { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime Endtime { get; set; }
    }
}
