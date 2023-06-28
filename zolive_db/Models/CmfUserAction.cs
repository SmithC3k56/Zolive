using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 用户操作表
    /// </summary>
    public partial class CmfUserAction
    {
        public int Id { get; set; }
        /// <summary>
        /// 更改积分，可以为负
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// 更改金币，可以为负
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 奖励次数
        /// </summary>
        public int RewardNumber { get; set; }
        /// <summary>
        /// 周期类型;0:不限;1:按天;2:按小时;3:永久
        /// </summary>
        public byte CycleType { get; set; }
        /// <summary>
        /// 周期时间值
        /// </summary>
        public uint CycleTime { get; set; }
        /// <summary>
        /// 用户操作名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 用户操作名称
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 操作所在应用名或插件名等
        /// </summary>
        public string App { get; set; } = null!;
        /// <summary>
        /// 执行操作的url
        /// </summary>
        public string? Url { get; set; }
    }
}
