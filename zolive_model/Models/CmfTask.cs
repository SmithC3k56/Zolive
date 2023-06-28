using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTask
    {
        public int Id { get; set; }
        /// <summary>
        /// 1、关注 2、分享
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 发布金额
        /// </summary>
        public string Money { get; set; } = null!;
        /// <summary>
        /// 平台比例，百分比单位
        /// </summary>
        public int Proportion { get; set; }
        /// <summary>
        /// 任务说明
        /// </summary>
        public string Text { get; set; } = null!;
        /// <summary>
        /// 主播ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 剩余金额
        /// </summary>
        public double SurplusMoney { get; set; }
        /// <summary>
        /// 平台扣金额
        /// </summary>
        public string ProportionMoney { get; set; } = null!;
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime Addtime { get; set; }
        /// <summary>
        /// 1、直播间 2、短视频
        /// </summary>
        public int TypeClass { get; set; }
        /// <summary>
        /// 是否完成 0是 1否
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 视频ID
        /// </summary>
        public int VideoId { get; set; }
    }
}
