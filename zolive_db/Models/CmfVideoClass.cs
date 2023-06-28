using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVideoClass
    {
        public uint Id { get; set; }
        /// <summary>
        /// 分类名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameNam { get; set; } = null!;
    }
}
