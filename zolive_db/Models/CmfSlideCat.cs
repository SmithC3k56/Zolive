using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfSlideCat
    {
        public int Cid { get; set; }
        /// <summary>
        /// 幻灯片分类
        /// </summary>
        public string CatName { get; set; } = null!;
        /// <summary>
        /// 幻灯片分类标识
        /// </summary>
        public string CatIdname { get; set; } = null!;
        /// <summary>
        /// 分类备注
        /// </summary>
        public string? CatRemark { get; set; }
        /// <summary>
        /// 状态，1显示，0不显示
        /// </summary>
        public int CatStatus { get; set; }
    }
}
