using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfSellerGoodsClass
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 商品一级分类id
        /// </summary>
        public int GoodsClassid { get; set; }
        /// <summary>
        /// 是否显示 0 否 1 是
        /// </summary>
        public bool Status { get; set; }
    }
}
