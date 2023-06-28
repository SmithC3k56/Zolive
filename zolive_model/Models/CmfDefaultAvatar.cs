using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfDefaultAvatar
    {
        /// <summary>
        /// ID
        /// </summary>
        public ushort Id { get; set; }
        /// <summary>
        /// 头像文件路径
        /// </summary>
        public string AvatarUrl { get; set; } = null!;
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public uint LastUpdatetime { get; set; }
    }
}
