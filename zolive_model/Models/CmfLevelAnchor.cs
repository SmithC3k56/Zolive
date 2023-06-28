using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLevelAnchor
    {
        /// <summary>
        /// 等级
        /// </summary>
        public uint Levelid { get; set; }
        /// <summary>
        /// 等级名称
        /// </summary>
        public string? Levelname { get; set; }
        /// <summary>
        /// 等级上限
        /// </summary>
        public uint? LevelUp { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int? Addtime { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 头像角标
        /// </summary>
        public string ThumbMark { get; set; } = null!;
        /// <summary>
        /// 背景
        /// </summary>
        public string Bg { get; set; } = null!;
    }
}
