using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户登录尝试表
    /// </summary>
    public partial class CmfUserLoginAttempt
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 尝试次数
        /// </summary>
        public uint LoginAttempts { get; set; }
        /// <summary>
        /// 尝试登录时间
        /// </summary>
        public uint AttemptTime { get; set; }
        /// <summary>
        /// 锁定时间
        /// </summary>
        public uint LockedTime { get; set; }
        /// <summary>
        /// 用户 ip
        /// </summary>
        public string Ip { get; set; } = null!;
        /// <summary>
        /// 用户账号,手机号,邮箱或用户名
        /// </summary>
        public string Account { get; set; } = null!;
    }
}
