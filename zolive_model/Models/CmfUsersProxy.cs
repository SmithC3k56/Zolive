using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersProxy
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 关系
        /// </summary>
        public string Path { get; set; } = null!;
        /// <summary>
        /// 用户类型,0是会员1是代理，-1推广员
        /// </summary>
        public bool Type { get; set; }
    }
}
