using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfFamilyUser
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 家族ID
        /// </summary>
        public int Familyid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; } = null!;
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 是否退出
        /// </summary>
        public bool Signout { get; set; }
        /// <summary>
        /// 审核后是否需要通知
        /// </summary>
        public bool Istip { get; set; }
        /// <summary>
        /// 踢出或拒绝理由
        /// </summary>
        public string SignoutReason { get; set; } = null!;
        /// <summary>
        /// 踢出或拒绝是否需要通知
        /// </summary>
        public sbyte SignoutIstip { get; set; }
        /// <summary>
        /// 家族分成
        /// </summary>
        public int DivideFamily { get; set; }
    }
}
