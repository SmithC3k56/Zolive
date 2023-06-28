﻿using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersLive
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public uint Uid { get; set; }
        /// <summary>
        /// 直播标识
        /// </summary>
        public int Showid { get; set; }
        /// <summary>
        /// 直播状态
        /// </summary>
        public int Islive { get; set; }
        /// <summary>
        /// 开播时间
        /// </summary>
        public int Starttime { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; } = null!;
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; } = null!;
        /// <summary>
        /// 流名
        /// </summary>
        public string Stream { get; set; } = null!;
        /// <summary>
        /// 封面图
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 播流地址
        /// </summary>
        public string Pull { get; set; } = null!;
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng { get; set; } = null!;
        /// <summary>
        /// 维度
        /// </summary>
        public string Lat { get; set; } = null!;
        /// <summary>
        /// 直播类型
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 类型值
        /// </summary>
        public string TypeVal { get; set; } = null!;
        /// <summary>
        /// 是否假视频
        /// </summary>
        public bool Isvideo { get; set; }
        /// <summary>
        /// 网易房间ID(当不使用网易是默认为空)
        /// </summary>
        public string WyCid { get; set; } = null!;
        /// <summary>
        /// 靓号
        /// </summary>
        public string Goodnum { get; set; } = null!;
        /// <summary>
        /// 横竖屏，0表示竖屏，1表示横屏
        /// </summary>
        public bool? Anyway { get; set; }
        /// <summary>
        /// 直播分类ID
        /// </summary>
        public int Liveclassid { get; set; }
        /// <summary>
        /// 热门礼物总额
        /// </summary>
        public int Hotvotes { get; set; }
        /// <summary>
        /// PK对方ID
        /// </summary>
        public int Pkuid { get; set; }
        /// <summary>
        /// pk对方的流名
        /// </summary>
        public string Pkstream { get; set; } = null!;
        /// <summary>
        /// 连麦开关，0是关，1是开
        /// </summary>
        public bool Ismic { get; set; }
        /// <summary>
        /// 是否热门
        /// </summary>
        public bool Ishot { get; set; }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool Isrecommend { get; set; }
        /// <summary>
        /// 设备信息
        /// </summary>
        public string Deviceinfo { get; set; } = null!;
        /// <summary>
        /// 是否开启店铺
        /// </summary>
        public bool Isshop { get; set; }
        /// <summary>
        /// 房间ID
        /// </summary>
        public int RoomId { get; set; }
        /// <summary>
        /// 彩票类型
        /// </summary>
        public string BcType { get; set; } = null!;
    }
}
