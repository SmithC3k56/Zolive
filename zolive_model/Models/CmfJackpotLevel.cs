using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfJackpotLevel
    {
        public int Id { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public uint Levelid { get; set; }
        /// <summary>
        /// 经验下限
        /// </summary>
        public uint LevelUp { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
    }
}
