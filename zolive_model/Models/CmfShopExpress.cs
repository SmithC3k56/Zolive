using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopExpress
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 快递公司电话
        /// </summary>
        public string ExpressName { get; set; } = null!;
        /// <summary>
        /// 快递公司客服电话
        /// </summary>
        public string ExpressPhone { get; set; } = null!;
        /// <summary>
        /// 快递公司图标
        /// </summary>
        public string ExpressThumb { get; set; } = null!;
        /// <summary>
        /// 是否显示 0 否 1 是
        /// </summary>
        public bool? ExpressStatus { get; set; }
        /// <summary>
        /// 快递公司对应三方平台的编码
        /// </summary>
        public string ExpressCode { get; set; } = null!;
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public int Edittime { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int ListOrder { get; set; }
    }
}
