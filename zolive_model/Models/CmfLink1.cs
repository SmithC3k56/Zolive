using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLink1
    {
        public ulong LinkId { get; set; }
        /// <summary>
        /// 友情链接地址
        /// </summary>
        public string LinkUrl { get; set; } = null!;
        /// <summary>
        /// 友情链接名称
        /// </summary>
        public string LinkName { get; set; } = null!;
        /// <summary>
        /// 友情链接图标
        /// </summary>
        public string? LinkImage { get; set; }
        /// <summary>
        /// 友情链接打开方式
        /// </summary>
        public string LinkTarget { get; set; } = null!;
        /// <summary>
        /// 友情链接描述
        /// </summary>
        public string LinkDescription { get; set; } = null!;
        /// <summary>
        /// 状态，1显示，0不显示
        /// </summary>
        public int LinkStatus { get; set; }
        /// <summary>
        /// 友情链接评级
        /// </summary>
        public int LinkRating { get; set; }
        /// <summary>
        /// 链接与网站的关系
        /// </summary>
        public string? LinkRel { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Listorder { get; set; }
    }
}
