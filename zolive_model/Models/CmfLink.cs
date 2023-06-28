using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 友情链接表
    /// </summary>
    public partial class CmfLink
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 状态;1:显示;0:不显示
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 友情链接评级
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 友情链接描述
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 友情链接地址
        /// </summary>
        public string Url { get; set; } = null!;
        /// <summary>
        /// 友情链接名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 友情链接图标
        /// </summary>
        public string Image { get; set; } = null!;
        /// <summary>
        /// 友情链接打开方式
        /// </summary>
        public string Target { get; set; } = null!;
        /// <summary>
        /// 链接与网站的关系
        /// </summary>
        public string Rel { get; set; } = null!;
    }
}
