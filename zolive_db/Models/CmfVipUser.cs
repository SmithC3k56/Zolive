using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVipUser
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public int Endtime { get; set; }
    }
}
