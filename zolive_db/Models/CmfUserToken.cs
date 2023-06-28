using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户客户端登录 token 表
    /// </summary>
    public partial class CmfUserToken
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public ulong UserId { get; set; }
        /// <summary>
        ///  过期时间
        /// </summary>
        public uint ExpireTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; } = null!;
        /// <summary>
        /// 设备类型;mobile,android,iphone,ipad,web,pc,mac,wxapp
        /// </summary>
        public string DeviceType { get; set; } = null!;
    }
}
