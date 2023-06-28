using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTurntableWin
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 转盘记录ID
        /// </summary>
        public long Logid { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
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
        /// 数量
        /// </summary>
        public int Nums { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Addtime { get; set; }
        /// <summary>
        /// 处理状态，0未处理1已处理
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public long Uptime { get; set; }
    }
}
