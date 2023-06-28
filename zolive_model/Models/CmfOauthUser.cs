using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfOauthUser
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户来源key
        /// </summary>
        public string From { get; set; } = null!;
        /// <summary>
        /// 第三方昵称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImg { get; set; } = null!;
        /// <summary>
        /// 关联的本站用户id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 绑定时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIp { get; set; } = null!;
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginTimes { get; set; }
        public sbyte Status { get; set; }
        public string AccessToken { get; set; } = null!;
        /// <summary>
        /// access_token过期时间
        /// </summary>
        public int ExpiresDate { get; set; }
        /// <summary>
        /// 第三方用户id
        /// </summary>
        public string Openid { get; set; } = null!;
    }
}
