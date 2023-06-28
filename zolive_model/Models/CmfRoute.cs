using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// url路由表
    /// </summary>
    public partial class CmfRoute
    {
        /// <summary>
        /// 路由id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 状态;1:启用,0:不启用
        /// </summary>
        public sbyte Status { get; set; }
        /// <summary>
        /// URL规则类型;1:用户自定义;2:别名添加
        /// </summary>
        public sbyte Type { get; set; }
        /// <summary>
        /// 完整url
        /// </summary>
        public string FullUrl { get; set; } = null!;
        /// <summary>
        /// 实际显示的url
        /// </summary>
        public string Url { get; set; } = null!;
    }
}
