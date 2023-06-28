using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfFamily
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 家族名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 家族图标
        /// </summary>
        public string Badge { get; set; } = null!;
        /// <summary>
        /// 身份证正面
        /// </summary>
        public string ApplyPos { get; set; } = null!;
        /// <summary>
        /// 身份证背面
        /// </summary>
        public string ApplySide { get; set; } = null!;
        /// <summary>
        /// 简介
        /// </summary>
        public string? Briefing { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string Carded { get; set; } = null!;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Fullname { get; set; } = null!;
        /// <summary>
        /// 申请时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 申请状态 0未审核 1 审核失败 2 审核通过 3
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; } = null!;
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disable { get; set; }
        /// <summary>
        /// 分成比例
        /// </summary>
        public int DivideFamily { get; set; }
        /// <summary>
        /// 是否需要通知
        /// </summary>
        public bool Istip { get; set; }
    }
}
