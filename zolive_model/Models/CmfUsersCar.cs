using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersCar
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 坐骑ID
        /// </summary>
        public int Carid { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public int Endtime { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
