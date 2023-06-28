using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 前台导航菜单表
    /// </summary>
    public partial class CmfNavMenu
    {
        public int Id { get; set; }
        /// <summary>
        /// 导航 id
        /// </summary>
        public int NavId { get; set; }
        /// <summary>
        /// 父 id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 状态;1:显示;0:隐藏
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 打开方式
        /// </summary>
        public string Target { get; set; } = null!;
        /// <summary>
        /// 链接
        /// </summary>
        public string Href { get; set; } = null!;
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = null!;
        /// <summary>
        /// 层级关系
        /// </summary>
        public string Path { get; set; } = null!;
    }
}
