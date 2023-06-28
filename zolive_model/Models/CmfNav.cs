using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfNav
    {
        public int Id { get; set; }
        /// <summary>
        /// 导航分类 id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 导航父 id
        /// </summary>
        public int Parentid { get; set; }
        /// <summary>
        /// 导航标题
        /// </summary>
        public string Label { get; set; } = null!;
        /// <summary>
        /// 打开方式
        /// </summary>
        public string? Target { get; set; }
        /// <summary>
        /// 导航链接
        /// </summary>
        public string Href { get; set; } = null!;
        /// <summary>
        /// 导航图标
        /// </summary>
        public string Icon { get; set; } = null!;
        /// <summary>
        /// 状态，1显示，0不显示
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Listorder { get; set; }
        /// <summary>
        /// 层级关系
        /// </summary>
        public string Path { get; set; } = null!;
    }
}
