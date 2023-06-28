using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfAd1
    {
        public int Id { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int? Sid { get; set; }
        /// <summary>
        /// 广告名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string? Des { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string? Url { get; set; }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string? Thumb { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int? Orderno { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int? Addtime { get; set; }
    }
}
