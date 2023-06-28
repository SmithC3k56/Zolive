using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfAgent
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 上级用户id
        /// </summary>
        public int OneUid { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
