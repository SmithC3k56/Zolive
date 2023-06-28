using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLiveClass
    {
        public uint Id { get; set; }
        /// <summary>
        /// 分类名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 图标
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 描述
        /// </summary>
        public string Des { get; set; } = null!;
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        public string En { get; set; } = null!;
        public string Nam { get; set; } = null!;
    }
}
