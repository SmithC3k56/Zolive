using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGiftSort
    {
        public int Id { get; set; }
        /// <summary>
        /// 分类名
        /// </summary>
        public string Sortname { get; set; } = null!;
        /// <summary>
        /// 序号
        /// </summary>
        public int Orderno { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
