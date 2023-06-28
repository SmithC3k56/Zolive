using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUser
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserLogin { get; set; } = null!;
        /// <summary>
        /// 登录密码；sp_password加密
        /// </summary>
        public string UserPass { get; set; } = null!;
        /// <summary>
        /// 用户美名
        /// </summary>
        public string UserNicename { get; set; } = null!;
        /// <summary>
        /// 登录邮箱
        /// </summary>
        public string UserEmail { get; set; } = null!;
        /// <summary>
        /// 用户个人网站
        /// </summary>
        public string UserUrl { get; set; } = null!;
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar { get; set; } = null!;
        /// <summary>
        /// 小头像
        /// </summary>
        public string AvatarThumb { get; set; } = null!;
        /// <summary>
        /// 性别；0：保密，1：男；2：女
        /// </summary>
        public short? Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public string? Birthday { get; set; }
        /// <summary>
        /// 个性签名
        /// </summary>
        public string? Signature { get; set; }
        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIp { get; set; } = null!;
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 激活码
        /// </summary>
        public string UserActivationKey { get; set; } = null!;
        /// <summary>
        /// 用户状态 0：禁用； 1：正常 ；2：未验证
        /// </summary>
        public int UserStatus { get; set; }
        /// <summary>
        /// 用户积分
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 用户类型，1:admin ;2:会员
        /// </summary>
        public short UserType { get; set; }
        /// <summary>
        /// 金币
        /// </summary>
        public double Coin { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; } = null!;
        /// <summary>
        /// 授权token
        /// </summary>
        public string Token { get; set; } = null!;
        /// <summary>
        /// token 到期时间
        /// </summary>
        public int Expiretime { get; set; }
        /// <summary>
        /// 消费总额
        /// </summary>
        public ulong Consumption { get; set; }
        /// <summary>
        /// 映票余额
        /// </summary>
        public decimal Votes { get; set; }
        /// <summary>
        /// 映票总额
        /// </summary>
        public ulong Votestotal { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; } = null!;
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; } = null!;
        /// <summary>
        /// 0 未推荐 1 推荐
        /// </summary>
        public bool Isrecommend { get; set; }
        /// <summary>
        /// 三方标识
        /// </summary>
        public string Openid { get; set; } = null!;
        /// <summary>
        /// 注册方式
        /// </summary>
        public string LoginType { get; set; } = null!;
        /// <summary>
        /// 是否开启僵尸粉
        /// </summary>
        public bool Iszombie { get; set; }
        /// <summary>
        /// 是否开起回放
        /// </summary>
        public bool Isrecord { get; set; }
        /// <summary>
        /// 是否僵尸粉
        /// </summary>
        public bool Iszombiep { get; set; }
        /// <summary>
        /// 是否超管
        /// </summary>
        public bool Issuper { get; set; }
        /// <summary>
        /// 是否热门显示
        /// </summary>
        public bool? Ishot { get; set; }
        /// <summary>
        /// 当前装备靓号
        /// </summary>
        public string Goodnum { get; set; } = null!;
        /// <summary>
        /// 注册来源
        /// </summary>
        public string Source { get; set; } = null!;
        /// <summary>
        /// 所在地
        /// </summary>
        public string Location { get; set; } = null!;
        /// <summary>
        /// 总的观看次数
        /// </summary>
        public int? TotalWatchVideoCount { get; set; }
        /// <summary>
        /// 最后赠送的次数
        /// </summary>
        public string? LastSongTime { get; set; }
    }
}
