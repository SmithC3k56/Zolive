using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfReportClassify
    {
        public uint Id { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 举报类型名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameNam { get; set; } = null!;
    }
}
