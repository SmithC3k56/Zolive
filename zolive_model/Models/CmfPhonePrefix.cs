using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 国际电话号码区号
    /// </summary>
    public partial class CmfPhonePrefix
    {
        public int Id { get; set; }
        /// <summary>
        /// 国家名称
        /// </summary>
        public string Country { get; set; } = null!;
        /// <summary>
        /// 区号
        /// </summary>
        public int Prefix { get; set; }
        /// <summary>
        /// 所在的洲
        /// </summary>
        public string Area { get; set; } = null!;
    }
}
