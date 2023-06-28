using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfCar
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 图片链接
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 动画链接
        /// </summary>
        public string Swf { get; set; } = null!;
        /// <summary>
        /// 动画时长
        /// </summary>
        public decimal Swftime { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Needcoin { get; set; }
        /// <summary>
        /// 积分价格
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 进场话术
        /// </summary>
        public string Words { get; set; } = null!;
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameNam { get; set; } = null!;
        public string WordsEn { get; set; } = null!;
        public string WordsNam { get; set; } = null!;
    }
}
