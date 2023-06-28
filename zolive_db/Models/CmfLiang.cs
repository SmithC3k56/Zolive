using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfLiang
    {
        public uint Id { get; set; }
        /// <summary>
        /// 靓号
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 长度
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 积分价格
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 购买用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 购买时间
        /// </summary>
        public int Buytime { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 靓号销售状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 启用状态
        /// </summary>
        public sbyte State { get; set; }
    }
}
