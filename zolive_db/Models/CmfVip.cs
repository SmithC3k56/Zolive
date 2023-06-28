using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfVip
    {
        public int Id { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 时长（月）
        /// </summary>
        public int Length { get; set; }
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
    }
}
