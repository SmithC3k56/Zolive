using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 第三方用户表
    /// </summary>
    public partial class CmfThirdPartyUser
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 本站用户id
        /// </summary>
        public ulong UserId { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public uint LastLoginTime { get; set; }
        /// <summary>
        /// access_token过期时间
        /// </summary>
        public uint ExpireTime { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 登录次数
        /// </summary>
        public uint LoginTimes { get; set; }
        /// <summary>
        /// 状态;1:正常;0:禁用
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nickname { get; set; } = null!;
        /// <summary>
        /// 第三方唯一码
        /// </summary>
        public string ThirdParty { get; set; } = null!;
        /// <summary>
        /// 第三方应用 id
        /// </summary>
        public string AppId { get; set; } = null!;
        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIp { get; set; } = null!;
        /// <summary>
        /// 第三方授权码
        /// </summary>
        public string AccessToken { get; set; } = null!;
        /// <summary>
        /// 第三方用户id
        /// </summary>
        public string Openid { get; set; } = null!;
        /// <summary>
        /// 第三方用户多个产品中的惟一 id,(如:微信平台)
        /// </summary>
        public string UnionId { get; set; } = null!;
        /// <summary>
        /// 扩展信息
        /// </summary>
        public string? More { get; set; }
    }
}
