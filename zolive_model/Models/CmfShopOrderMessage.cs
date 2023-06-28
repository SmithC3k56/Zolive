using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopOrderMessage
    {
        public long Id { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Title { get; set; } = null!;
        public long Orderid { get; set; }
        /// <summary>
        /// 接受消息用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 用户身份 0买家 1卖家
        /// </summary>
        public bool Type { get; set; }
        public string TitleEn { get; set; } = null!;
        public string TitleNam { get; set; } = null!;
    }
}
