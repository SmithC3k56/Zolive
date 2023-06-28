using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfAdminLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int Adminid { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        public string Admin { get; set; } = null!;
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// IP地址
        /// </summary>
        public long Ip { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
