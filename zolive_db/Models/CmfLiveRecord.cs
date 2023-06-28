using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLiveRecord
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 直播标识
        /// </summary>
        public long Showid { get; set; }
        /// <summary>
        /// 关播时人数
        /// </summary>
        public uint Nums { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public long Starttime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public long Endtime { get; set; }
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
        /// 经度
        /// </summary>
        public string Lng { get; set; } = null!;
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat { get; set; } = null!;
        /// <summary>
        /// 直播类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 类型值
        /// </summary>
        public string TypeVal { get; set; } = null!;
        /// <summary>
        /// 本次直播收益
        /// </summary>
        public string Votes { get; set; } = null!;
        /// <summary>
        /// 格式日期
        /// </summary>
        public string Time { get; set; } = null!;
        /// <summary>
        /// 直播分类ID
        /// </summary>
        public ulong Liveclassid { get; set; }
        /// <summary>
        /// 回放地址
        /// </summary>
        public string VideoUrl { get; set; } = null!;
    }
}
