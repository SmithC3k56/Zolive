using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfConfig
    {
        public int Id { get; set; }
        /// <summary>
        /// APK版本号
        /// </summary>
        public string ApkVer { get; set; } = null!;
        /// <summary>
        /// APK下载链接
        /// </summary>
        public string ApkUrl { get; set; } = null!;
        /// <summary>
        /// APK版本更新说明
        /// </summary>
        public string ApkDes { get; set; } = null!;
        /// <summary>
        /// 网站标题
        /// </summary>
        public string Sitename { get; set; } = null!;
        /// <summary>
        /// 微信推广域名
        /// </summary>
        public string WxSiteurl { get; set; } = null!;
        /// <summary>
        /// AndroidAPP下载链接
        /// </summary>
        public string AppAndroid { get; set; } = null!;
        /// <summary>
        /// IOSAPP下载链接
        /// </summary>
        public string AppIos { get; set; } = null!;
        /// <summary>
        /// 二维码连接
        /// </summary>
        public string QrUrl { get; set; } = null!;
        /// <summary>
        /// IPA版本号
        /// </summary>
        public string IpaVer { get; set; } = null!;
        /// <summary>
        /// IPA下载链接
        /// </summary>
        public string IpaUrl { get; set; } = null!;
        /// <summary>
        /// IPA版本更新说明
        /// </summary>
        public string IpaDes { get; set; } = null!;
        /// <summary>
        /// 网站域名
        /// </summary>
        public string Site { get; set; } = null!;
        /// <summary>
        /// 推流分辨率宽度
        /// </summary>
        public string LiveWidth { get; set; } = null!;
        /// <summary>
        /// 推流分辨率高度
        /// </summary>
        public string LiveHeight { get; set; } = null!;
        /// <summary>
        /// 关键帧
        /// </summary>
        public uint Keyframe { get; set; }
        /// <summary>
        /// fps帧数
        /// </summary>
        public uint Fps { get; set; }
        /// <summary>
        /// 品质
        /// </summary>
        public uint Quality { get; set; }
        /// <summary>
        /// 公众号提示信息
        /// </summary>
        public string PubMsg { get; set; } = null!;
        /// <summary>
        /// 中奖基数
        /// </summary>
        public uint Lotterybase { get; set; }
        /// <summary>
        /// 映票兑换钻石比例
        /// </summary>
        public uint ExRate { get; set; }
        /// <summary>
        /// 分享标题
        /// </summary>
        public string ShareTitle { get; set; } = null!;
        /// <summary>
        /// 分享话术
        /// </summary>
        public string ShareDes { get; set; } = null!;
        /// <summary>
        /// IOS上架版本号
        /// </summary>
        public string IosShelves { get; set; } = null!;
        /// <summary>
        /// 钻石名称
        /// </summary>
        public string NameCoin { get; set; } = null!;
        /// <summary>
        /// 映票名称
        /// </summary>
        public string NameVotes { get; set; } = null!;
        /// <summary>
        /// 金光一闪提示
        /// </summary>
        public uint EnterTipLevel { get; set; }
        /// <summary>
        /// 网站维护开关
        /// </summary>
        public bool MaintainSwitch { get; set; }
        /// <summary>
        /// 维护内容
        /// </summary>
        public string MaintainTips { get; set; } = null!;
        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright { get; set; } = null!;
        /// <summary>
        /// 计时收费梯价
        /// </summary>
        public string LiveTimeCoin { get; set; } = null!;
        /// <summary>
        /// 登录方式
        /// </summary>
        public string LoginType { get; set; } = null!;
        /// <summary>
        /// 直播类型
        /// </summary>
        public string LiveType { get; set; } = null!;
        /// <summary>
        /// 分享类型
        /// </summary>
        public string ShareType { get; set; } = null!;
        /// <summary>
        /// 官网电话
        /// </summary>
        public string Mobile { get; set; } = null!;
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; } = null!;
        /// <summary>
        /// android下载二维码
        /// </summary>
        public string ApkEwm { get; set; } = null!;
        /// <summary>
        /// ios下载链接
        /// </summary>
        public string IpaEwm { get; set; } = null!;
        /// <summary>
        /// 微信公众号
        /// </summary>
        public string WechatEwm { get; set; } = null!;
        /// <summary>
        /// 新浪图标
        /// </summary>
        public string SinaIcon { get; set; } = null!;
        /// <summary>
        /// 新浪标题
        /// </summary>
        public string SinaTitle { get; set; } = null!;
        /// <summary>
        /// 新浪描述
        /// </summary>
        public string SinaDesc { get; set; } = null!;
        /// <summary>
        /// 新浪链接
        /// </summary>
        public string SinaUrl { get; set; } = null!;
        /// <summary>
        /// qq图标
        /// </summary>
        public string QqIcon { get; set; } = null!;
        /// <summary>
        /// qq标题
        /// </summary>
        public string QqTitle { get; set; } = null!;
        /// <summary>
        /// qq描述
        /// </summary>
        public string QqDesc { get; set; } = null!;
        /// <summary>
        /// qq链接
        /// </summary>
        public string QqUrl { get; set; } = null!;
        /// <summary>
        /// 萌颜授权码
        /// </summary>
        public string SproutKey { get; set; } = null!;
        /// <summary>
        /// 美白默认值
        /// </summary>
        public int SproutWhite { get; set; }
        /// <summary>
        /// 磨皮默认值
        /// </summary>
        public int? SproutSkin { get; set; }
        /// <summary>
        /// 饱和默认值
        /// </summary>
        public int? SproutSaturated { get; set; }
        /// <summary>
        /// 粉嫩默认值
        /// </summary>
        public int? SproutPink { get; set; }
        /// <summary>
        /// 大眼默认值
        /// </summary>
        public int? SproutEye { get; set; }
        /// <summary>
        /// 瘦脸默认值
        /// </summary>
        public int? SproutFace { get; set; }
        /// <summary>
        /// 短视频分享标题
        /// </summary>
        public string VideoShareTitle { get; set; } = null!;
        /// <summary>
        /// 短视频分享话术
        /// </summary>
        public string VideoShareDes { get; set; } = null!;
    }
}
