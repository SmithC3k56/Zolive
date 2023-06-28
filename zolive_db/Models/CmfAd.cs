using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfAd
    {
        /// <summary>
        /// 广告id
        /// </summary>
        public long AdId { get; set; }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string AdName { get; set; } = null!;
        /// <summary>
        /// 广告内容
        /// </summary>
        public string? AdContent { get; set; }
        /// <summary>
        /// 状态，1显示，0不显示
        /// </summary>
        public int Status { get; set; }
    }
}
