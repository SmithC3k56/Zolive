using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 幻灯片表
    /// </summary>
    public partial class CmfSlide
    {
        public int Id { get; set; }
        /// <summary>
        /// 状态,1:显示,0不显示
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public uint DeleteTime { get; set; }
        /// <summary>
        /// 幻灯片分类
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 分类备注
        /// </summary>
        public string Remark { get; set; } = null!;
    }
}
