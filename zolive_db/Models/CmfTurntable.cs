using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTurntable
    {
        public uint Id { get; set; }
        /// <summary>
        /// 类型，0无奖1钻石2礼物
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 类型值
        /// </summary>
        public string TypeVal { get; set; } = null!;
        /// <summary>
        /// 图片
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 中奖率
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Uptime { get; set; }
    }
}
