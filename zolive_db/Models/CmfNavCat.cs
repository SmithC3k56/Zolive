using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfNavCat
    {
        public int Navcid { get; set; }
        /// <summary>
        /// 导航分类名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 是否为主菜单，1是，0不是
        /// </summary>
        public int Active { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }
    }
}
