using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserGoodsVisit
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public int Goodsid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        public string TimeFormat { get; set; } = null!;
    }
}
