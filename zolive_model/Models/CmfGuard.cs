using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfGuard
    {
        public uint Id { get; set; }
        /// <summary>
        /// 守护名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 守护类型，1普通2尊贵
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public int Coin { get; set; }
        /// <summary>
        /// 时长类型，0天，1月，2年
        /// </summary>
        public bool LengthType { get; set; }
        /// <summary>
        /// 时长
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// 时长秒数
        /// </summary>
        public int LengthTime { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int ListOrder { get; set; }
        public string NameEn { get; set; } = null!;
        public string NameNam { get; set; } = null!;
    }
}
