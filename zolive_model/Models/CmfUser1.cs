using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class CmfUser1
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户类型;1:admin;2:会员
        /// </summary>
        public byte UserType { get; set; }
        /// <summary>
        /// 性别;0:保密,1:男,2:女
        /// </summary>
        public sbyte Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public int Birthday { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public int LastLoginTime { get; set; }
        /// <summary>
        /// 用户积分
        /// </summary>
        public long Score { get; set; }
        /// <summary>
        /// 金币
        /// </summary>
        public ulong Coin { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public int CreateTime { get; set; }
        /// <summary>
        /// 用户状态;0:禁用,1:正常,2:未验证
        /// </summary>
        public byte UserStatus { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserLogin { get; set; } = null!;
        /// <summary>
        /// 登录密码;cmf_password加密
        /// </summary>
        public string UserPass { get; set; } = null!;
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserNicename { get; set; } = null!;
        /// <summary>
        /// 用户登录邮箱
        /// </summary>
        public string UserEmail { get; set; } = null!;
        /// <summary>
        /// 用户个人网址
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
        /// 个性签名
        /// </summary>
        public string Signature { get; set; } = null!;
        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIp { get; set; } = null!;
        /// <summary>
        /// 激活码
        /// </summary>
        public string UserActivationKey { get; set; } = null!;
        /// <summary>
        /// 中国手机不带国家代码，国际手机号格式为：国家代码-手机号
        /// </summary>
        public string Mobile { get; set; } = null!;
        /// <summary>
        /// 扩展属性
        /// </summary>
        public string? More { get; set; }
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
        /// 禁用到期时间
        /// </summary>
        public long EndBantime { get; set; }
        /// <summary>
        /// 用户商城人民币账户金额
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
        /// 用户商城累计收入人民币
        /// </summary>
        public decimal BalanceTotal { get; set; }
        /// <summary>
        /// 用户商城累计消费人民币
        /// </summary>
        public decimal BalanceConsumption { get; set; }
        /// <summary>
        /// 教育json
        /// </summary>
        public string Education { get; set; } = null!;
        /// <summary>
        /// 职业json
        /// </summary>
        public string Professional { get; set; } = null!;
        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; } = null!;
        /// <summary>
        /// 多图片
        /// </summary>
        public string Url1 { get; set; } = null!;
        public decimal Je { get; set; }
    }
}
