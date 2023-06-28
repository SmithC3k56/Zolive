using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLabel
    {
        public uint Id { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Colour { get; set; } = null!;
        /// <summary>
        /// 尾色
        /// </summary>
        public string Colour2 { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string NameNam { get; set; } = null!;
    }
}
