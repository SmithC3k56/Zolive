using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 幻灯片子项表
    /// </summary>
    public partial class CmfSlideItem
    {
        public uint Id { get; set; }
        /// <summary>
        /// 幻灯片id
        /// </summary>
        public int SlideId { get; set; }
        /// <summary>
        /// 状态,1:显示;0:隐藏
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 幻灯片名称
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 幻灯片图片
        /// </summary>
        public string Image { get; set; } = null!;
        /// <summary>
        /// 幻灯片链接
        /// </summary>
        public string Url { get; set; } = null!;
        /// <summary>
        /// 友情链接打开方式
        /// </summary>
        public string Target { get; set; } = null!;
        /// <summary>
        /// 幻灯片描述
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 幻灯片内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 扩展信息
        /// </summary>
        public string? More { get; set; }
    }
}
