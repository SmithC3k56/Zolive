using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfMenu
    {
        public ushort Id { get; set; }
        public ushort Parentid { get; set; }
        /// <summary>
        /// 应用名称app
        /// </summary>
        public string App { get; set; } = null!;
        /// <summary>
        /// 控制器
        /// </summary>
        public string Model { get; set; } = null!;
        /// <summary>
        /// 操作名称
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 额外参数
        /// </summary>
        public string Data { get; set; } = null!;
        /// <summary>
        /// 菜单类型  1：权限认证+菜单；0：只作为菜单
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 状态，1显示，0不显示
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 菜单图标
        /// </summary>
        public string? Icon { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = null!;
        /// <summary>
        /// 排序ID
        /// </summary>
        public ushort Listorder { get; set; }
    }
}
