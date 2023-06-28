using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersVoterecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 收支类型
        /// </summary>
        public string Type { get; set; } = null!;
        /// <summary>
        /// 收支行为
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 收益映票
        /// </summary>
        public decimal Votes { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
