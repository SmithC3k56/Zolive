using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 后台菜单表
    /// </summary>
    public partial class CmfAdminMenu
    {
        public uint Id { get; set; }
        /// <summary>
        /// 父菜单id
        /// </summary>
        public uint ParentId { get; set; }
        /// <summary>
        /// 菜单类型;1:有界面可访问菜单,2:无界面可访问菜单,0:只作为菜单
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 状态;1:显示,0:不显示
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 应用名
        /// </summary>
        public string App { get; set; } = null!;
        /// <summary>
        /// 控制器名
        /// </summary>
        public string Controller { get; set; } = null!;
        /// <summary>
        /// 操作名称
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 额外参数
        /// </summary>
        public string Param { get; set; } = null!;
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; } = null!;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = null!;
    }
}
