using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 权限授权表
    /// </summary>
    public partial class CmfAuthAccess
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public uint RoleId { get; set; }
        /// <summary>
        /// 规则唯一英文标识,全小写
        /// </summary>
        public string RuleName { get; set; } = null!;
        /// <summary>
        /// 权限规则分类,请加应用前缀,如admin_
        /// </summary>
        public string Type { get; set; } = null!;
    }
}
