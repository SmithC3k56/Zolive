using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class CmfRole
    {
        public uint Id { get; set; }
        /// <summary>
        /// 父角色ID
        /// </summary>
        public uint ParentId { get; set; }
        /// <summary>
        /// 状态;0:禁用;1:正常
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public uint UpdateTime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = null!;
    }
}
