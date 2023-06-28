using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户角色对应表
    /// </summary>
    public partial class CmfRoleUser
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 角色 id
        /// </summary>
        public uint RoleId { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public ulong UserId { get; set; }
    }
}
