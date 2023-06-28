using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopRefuseReason
    {
        public int Id { get; set; }
        /// <summary>
        /// 原因名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 排序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 状态 0不显示 1 显示
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Edittime { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameNam { get; set; } = null!;
    }
}
