using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserAuth
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public uint Uid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; } = null!;
        /// <summary>
        /// 电话
        /// </summary>
        public string Mobile { get; set; } = null!;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CerNo { get; set; } = null!;
        /// <summary>
        /// 正面
        /// </summary>
        public string FrontView { get; set; } = null!;
        /// <summary>
        /// 反面
        /// </summary>
        public string BackView { get; set; } = null!;
        /// <summary>
        /// 手持
        /// </summary>
        public string HandsetView { get; set; } = null!;
        /// <summary>
        /// 审核说明
        /// </summary>
        public string? Reason { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 状态 0 处理中 1 成功 2 失败
        /// </summary>
        public bool Status { get; set; }
    }
}
