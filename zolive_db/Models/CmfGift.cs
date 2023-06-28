using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGift
    {
        public uint Id { get; set; }
        /// <summary>
        /// 标识，0普通，1热门，2守护
        /// </summary>
        public bool Mark { get; set; }
        /// <summary>
        /// 类型,0普通礼物，1豪华礼物
        /// </summary>
        public bool? Type { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int Sid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Giftname { get; set; } = null!;
        /// <summary>
        /// 价格
        /// </summary>
        public int Needcoin { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Gifticon { get; set; } = null!;
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 动画类型，0gif,1svga
        /// </summary>
        public bool Swftype { get; set; }
        /// <summary>
        /// 动画链接
        /// </summary>
        public string Swf { get; set; } = null!;
        /// <summary>
        /// 动画时长
        /// </summary>
        public decimal Swftime { get; set; }
        /// <summary>
        /// 是否全站礼物：0：否；1：是
        /// </summary>
        public bool Isplatgift { get; set; }
        /// <summary>
        /// 贴纸ID
        /// </summary>
        public int StickerId { get; set; }
        public string GiftnameEn { get; set; } = null!;
        public string GiftnameNam { get; set; } = null!;
    }
}
