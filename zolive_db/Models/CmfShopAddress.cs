using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopAddress
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 国家
        /// </summary>
        public string? Country { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string? Province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string? Area { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; } = null!;
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; } = null!;
        /// <summary>
        /// 国家代号
        /// </summary>
        public int CountryCode { get; set; }
        /// <summary>
        /// 是否为默认地址 0 否 1 是
        /// </summary>
        public bool IsDefault { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Edittime { get; set; }
        public string? ReceiverCountry { get; set; }
    }
}
