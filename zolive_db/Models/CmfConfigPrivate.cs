using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfConfigPrivate
    {
        public int Id { get; set; }
        /// <summary>
        /// 缓存开关
        /// </summary>
        public int CacheSwitch { get; set; }
        /// <summary>
        /// 缓存时间
        /// </summary>
        public uint CacheTime { get; set; }
        /// <summary>
        /// 互亿无线APIID
        /// </summary>
        public string IhuyiAccount { get; set; } = null!;
        /// <summary>
        /// 互亿无线key
        /// </summary>
        public string IhuyiPs { get; set; } = null!;
        /// <summary>
        /// 极光推送APP_KEY
        /// </summary>
        public string JpushKey { get; set; } = null!;
        /// <summary>
        /// 极光推送master_secret
        /// </summary>
        public string JpushSecret { get; set; } = null!;
        /// <summary>
        /// 用户列表请求间隔
        /// </summary>
        public uint UserlistTime { get; set; }
        /// <summary>
        /// 弹幕费用
        /// </summary>
        public uint BarrageFee { get; set; }
        /// <summary>
        /// 认证限制
        /// </summary>
        public int AuthIslimit { get; set; }
        /// <summary>
        /// 直播等级控制
        /// </summary>
        public int LevelIslimit { get; set; }
        /// <summary>
        /// 限制等级
        /// </summary>
        public uint LevelLimit { get; set; }
        /// <summary>
        /// 提现比例
        /// </summary>
        public uint CashRate { get; set; }
        /// <summary>
        /// 阿里云推流服务器地址
        /// </summary>
        public string PushUrl { get; set; } = null!;
        /// <summary>
        /// 阿里云播流服务器地址
        /// </summary>
        public string PullUrl { get; set; } = null!;
        /// <summary>
        /// 阿里云直播推流鉴权KEY
        /// </summary>
        public string AuthKeyPush { get; set; } = null!;
        /// <summary>
        /// 阿里云直播推流鉴权有效时长
        /// </summary>
        public string AuthLengthPush { get; set; } = null!;
        /// <summary>
        /// 阿里云直播播流鉴权KEY
        /// </summary>
        public string AuthKeyPull { get; set; } = null!;
        /// <summary>
        /// 阿里云直播播流鉴权有效时长
        /// </summary>
        public string AuthLengthPull { get; set; } = null!;
        /// <summary>
        /// 聊天服务器带端口
        /// </summary>
        public string Chatserver { get; set; } = null!;
        /// <summary>
        /// 支付宝APP
        /// </summary>
        public int AliappSwitch { get; set; }
        /// <summary>
        /// 合作者身份ID
        /// </summary>
        public string AliappPartner { get; set; } = null!;
        /// <summary>
        /// 支付宝帐号
        /// </summary>
        public string AliappSellerId { get; set; } = null!;
        /// <summary>
        /// 支付宝安卓密钥
        /// </summary>
        public string AliappKeyAndroid { get; set; } = null!;
        /// <summary>
        /// 支付宝苹果密钥
        /// </summary>
        public string AliappKeyIos { get; set; } = null!;
        /// <summary>
        /// 微信支付
        /// </summary>
        public int WxSwitch { get; set; }
        /// <summary>
        /// 开放平台账号AppID
        /// </summary>
        public string WxAppid { get; set; } = null!;
        /// <summary>
        /// 微信应用appsecret
        /// </summary>
        public string WxAppsecret { get; set; } = null!;
        /// <summary>
        /// 微信商户号mchid
        /// </summary>
        public string WxMchid { get; set; } = null!;
        /// <summary>
        /// 微信密钥key
        /// </summary>
        public string WxKey { get; set; } = null!;
        /// <summary>
        /// 支付宝校验码
        /// </summary>
        public string AliappCheck { get; set; } = null!;
        /// <summary>
        /// 支付宝PC
        /// </summary>
        public int AliappPc { get; set; }
        /// <summary>
        /// PC 微信登录appid
        /// </summary>
        public string LoginWxPcAppid { get; set; } = null!;
        /// <summary>
        /// PC 微信登录appsecret
        /// </summary>
        public string LoginWxPcAppsecret { get; set; } = null!;
        /// <summary>
        /// PC微博登陆akey
        /// </summary>
        public string LoginSinaPcAkey { get; set; } = null!;
        /// <summary>
        /// PC新浪微博skey
        /// </summary>
        public string LoginSinaPcSkey { get; set; } = null!;
        /// <summary>
        /// 微信支付PC
        /// </summary>
        public int WxSwitchPc { get; set; }
        /// <summary>
        /// 提现最低额度（元）
        /// </summary>
        public uint CashMin { get; set; }
        /// <summary>
        /// 微信公众平台应用ID
        /// </summary>
        public string LoginWxAppid { get; set; } = null!;
        /// <summary>
        /// 微信公众平台AppSecret
        /// </summary>
        public string LoginWxAppsecret { get; set; } = null!;
        /// <summary>
        /// 苹果支付沙盒模式
        /// </summary>
        public int IosSandbox { get; set; }
        /// <summary>
        /// 极光推送模式
        /// </summary>
        public int JpushSandbox { get; set; }
        /// <summary>
        /// cdn服务器选择 1表示阿里云 2表示腾讯云 3表示七牛云
        /// </summary>
        public bool? CdnSwitch { get; set; }
        /// <summary>
        /// 腾讯云直播appid
        /// </summary>
        public string TxAppid { get; set; } = null!;
        /// <summary>
        /// 腾讯云直播bizid
        /// </summary>
        public string TxBizid { get; set; } = null!;
        /// <summary>
        /// 腾讯云直播推流防盗链Key
        /// </summary>
        public string TxPushKey { get; set; } = null!;
        /// <summary>
        /// 腾讯云直播推流域名
        /// </summary>
        public string TxPush { get; set; } = null!;
        /// <summary>
        /// 腾讯云直播播流域名
        /// </summary>
        public string TxPull { get; set; } = null!;
        /// <summary>
        /// 七牛云AK
        /// </summary>
        public string QnAk { get; set; } = null!;
        /// <summary>
        /// 七牛云SK
        /// </summary>
        public string QnSk { get; set; } = null!;
        /// <summary>
        /// 七牛云直播空间名称
        /// </summary>
        public string QnHname { get; set; } = null!;
        /// <summary>
        /// 七牛云推流地址
        /// </summary>
        public string QnPush { get; set; } = null!;
        /// <summary>
        /// 七牛云播流地址
        /// </summary>
        public string QnPull { get; set; } = null!;
        /// <summary>
        /// 登录奖励开关
        /// </summary>
        public bool BonusSwitch { get; set; }
        /// <summary>
        /// 网宿推流地址
        /// </summary>
        public string WsPush { get; set; } = null!;
        /// <summary>
        /// 网宿播流地址
        /// </summary>
        public string WsPull { get; set; } = null!;
        /// <summary>
        /// 网宿AppName
        /// </summary>
        public string WsApn { get; set; } = null!;
        /// <summary>
        /// 网易appkey
        /// </summary>
        public string WyAppkey { get; set; } = null!;
        /// <summary>
        /// 网易appSecret
        /// </summary>
        public string WyAppsecret { get; set; } = null!;
        /// <summary>
        /// 奥点云推流地址
        /// </summary>
        public string AdyPush { get; set; } = null!;
        /// <summary>
        /// 奥点云播流地址
        /// </summary>
        public string AdyPull { get; set; } = null!;
        /// <summary>
        /// 奥点云HLS播流地址
        /// </summary>
        public string AdyHlsPull { get; set; } = null!;
        /// <summary>
        /// 奥点云AppName
        /// </summary>
        public string AdyApn { get; set; } = null!;
        /// <summary>
        /// 短信验证码开关
        /// </summary>
        public bool SendcodeSwitch { get; set; }
        /// <summary>
        /// 短信验证码IP限制开关
        /// </summary>
        public bool IplimitSwitch { get; set; }
        /// <summary>
        /// 短信验证码IP限制次数
        /// </summary>
        public bool? IplimitTimes { get; set; }
        /// <summary>
        /// 上庄限制
        /// </summary>
        public int GameBankerLimit { get; set; }
        /// <summary>
        /// 游戏开关
        /// </summary>
        public string GameSwitch { get; set; } = null!;
        /// <summary>
        /// 游戏抽水
        /// </summary>
        public int GamePump { get; set; }
        /// <summary>
        /// 游戏赔率
        /// </summary>
        public int GameOdds { get; set; }
        /// <summary>
        /// 系统坐庄游戏赔率
        /// </summary>
        public int GameOddsP { get; set; }
        /// <summary>
        /// 用户坐庄游戏赔率
        /// </summary>
        public int GameOddsU { get; set; }
        /// <summary>
        /// 竞拍开关
        /// </summary>
        public bool AuctionSwitch { get; set; }
        /// <summary>
        /// 禁言时长
        /// </summary>
        public int ShutTime { get; set; }
        /// <summary>
        /// 踢出时长
        /// </summary>
        public int KickTime { get; set; }
        /// <summary>
        /// 分销开关
        /// </summary>
        public bool AgentSwitch { get; set; }
        /// <summary>
        /// 分销一级分成
        /// </summary>
        public int Distribut1 { get; set; }
        /// <summary>
        /// 分销二级分成
        /// </summary>
        public int Distribut2 { get; set; }
        /// <summary>
        /// 分销三级分成
        /// </summary>
        public int Distribut3 { get; set; }
        /// <summary>
        /// 注册奖励
        /// </summary>
        public int RegReward { get; set; }
        /// <summary>
        /// 家族开关
        /// </summary>
        public bool FamilySwitch { get; set; }
        /// <summary>
        /// 提现期限开始时间
        /// </summary>
        public int CashStart { get; set; }
        /// <summary>
        /// 提现期限结束时间
        /// </summary>
        public int CashEnd { get; set; }
        /// <summary>
        /// 提现最大次数
        /// </summary>
        public int CashMaxTimes { get; set; }
        /// <summary>
        /// 友盟OpenApi-apiKey
        /// </summary>
        public string UmApikey { get; set; } = null!;
        /// <summary>
        /// 友盟OpenApi-apiSecurity
        /// </summary>
        public string UmApisecurity { get; set; } = null!;
        /// <summary>
        /// 友盟Android应用-appkey
        /// </summary>
        public string UmAppkeyAndroid { get; set; } = null!;
        /// <summary>
        /// 友盟IOS应用-appkey
        /// </summary>
        public string UmAppkeyIos { get; set; } = null!;
        /// <summary>
        /// 视频审核开关
        /// </summary>
        public bool VideoAuditSwitch { get; set; }
        /// <summary>
        /// 推荐视频显示方式
        /// </summary>
        public bool VideoShowtype { get; set; }
        /// <summary>
        /// 评论权重值
        /// </summary>
        public int CommentWeight { get; set; }
        /// <summary>
        /// 点赞权重值
        /// </summary>
        public int LikeWeight { get; set; }
        /// <summary>
        /// 分享权重值
        /// </summary>
        public int ShareWeight { get; set; }
        /// <summary>
        /// 初始曝光值
        /// </summary>
        public int ShowVal { get; set; }
        /// <summary>
        /// 每小时扣除曝光值
        /// </summary>
        public int HourMinusVal { get; set; }
        /// <summary>
        /// 腾讯云存储appid
        /// </summary>
        public string TxcloudAppid { get; set; } = null!;
        /// <summary>
        /// 腾讯云存储secret_id
        /// </summary>
        public string TxcloudSecretId { get; set; } = null!;
        /// <summary>
        /// 腾讯云存储secret_key
        /// </summary>
        public string TxcloudSecretKey { get; set; } = null!;
        /// <summary>
        /// 腾讯云存储buctet所属地域 tj 华北 sh华东 gz 华南
        /// </summary>
        public string TxcloudRegion { get; set; } = null!;
        /// <summary>
        /// 腾讯云存储存储桶
        /// </summary>
        public string TxcloudBucket { get; set; } = null!;
        /// <summary>
        /// 七牛云存储accesskey
        /// </summary>
        public string QiniuAccesskey { get; set; } = null!;
        /// <summary>
        /// 七牛云存储secretkey
        /// </summary>
        public string QiniuSecretkey { get; set; } = null!;
        /// <summary>
        /// 七牛存储桶
        /// </summary>
        public string QiniuBucket { get; set; } = null!;
        /// <summary>
        /// 七牛空间域名
        /// </summary>
        public string QiniuDomain { get; set; } = null!;
        /// <summary>
        /// 七牛云空间绝对地址（app拼链接用）
        /// </summary>
        public string QiniuDomainUrl { get; set; } = null!;
        /// <summary>
        ///  存储方式：0本地 1七牛云存储 2腾讯云存储
        /// </summary>
        public int Cloudtype { get; set; }
        /// <summary>
        /// 腾讯云图片存放目录名称
        /// </summary>
        public string? Tximgfolder { get; set; }
        /// <summary>
        /// 腾讯云视频存放目录名称
        /// </summary>
        public string? Txvideofolder { get; set; }
        /// <summary>
        /// 腾讯云用户头像存放目录名称
        /// </summary>
        public string? Txuserimgfolder { get; set; }
        /// <summary>
        /// 连麦等级限制，0表示无限制
        /// </summary>
        public int MicLimit { get; set; }
    }
}
