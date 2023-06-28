using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopGoodsClass
    {
        /// <summary>
        /// 商品分类ID
        /// </summary>
        public uint GcId { get; set; }
        /// <summary>
        /// 商品分类名称
        /// </summary>
        public string GcName { get; set; } = null!;
        /// <summary>
        /// 上级分类ID
        /// </summary>
        public int GcParentid { get; set; }
        /// <summary>
        /// 所属一级分类ID
        /// </summary>
        public int GcOneId { get; set; }
        /// <summary>
        /// 商品分类排序号
        /// </summary>
        public int GcSort { get; set; }
        /// <summary>
        /// 是否展示 0 否 1 是
        /// </summary>
        public bool GcIsshow { get; set; }
        /// <summary>
        /// 商品分类添加时间
        /// </summary>
        public int GcAddtime { get; set; }
        /// <summary>
        /// 商品分类修改时间
        /// </summary>
        public int GcEdittime { get; set; }
        /// <summary>
        /// 商品分类等级
        /// </summary>
        public bool GcGrade { get; set; }
        public string GcNameEn { get; set; } = null!;
        public string GcNameNam { get; set; } = null!;
    }
}
