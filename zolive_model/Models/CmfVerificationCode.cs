using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 手机邮箱数字验证码表
    /// </summary>
    public partial class CmfVerificationCode
    {
        /// <summary>
        /// 表id
        /// </summary>
        public ulong Id { get; set; }
        /// <summary>
        /// 当天已经发送成功的次数
        /// </summary>
        public uint Count { get; set; }
        /// <summary>
        /// 最后发送成功时间
        /// </summary>
        public uint SendTime { get; set; }
        /// <summary>
        /// 验证码过期时间
        /// </summary>
        public uint ExpireTime { get; set; }
        /// <summary>
        /// 最后发送成功的验证码
        /// </summary>
        public string Code { get; set; } = null!;
        /// <summary>
        /// 手机号或者邮箱
        /// </summary>
        public string Account { get; set; } = null!;
    }
}
