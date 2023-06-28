using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGuide
    {
        public uint Id { get; set; }
        /// <summary>
        /// 图片/视频链接
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Href { get; set; } = null!;
        /// <summary>
        /// 类型
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
    }
}
