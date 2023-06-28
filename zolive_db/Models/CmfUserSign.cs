﻿using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUserSign
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public ulong Uid { get; set; }
        /// <summary>
        /// 登录天数
        /// </summary>
        public int BonusDay { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public long BonusTime { get; set; }
        /// <summary>
        /// 连续登陆天数
        /// </summary>
        public int CountDay { get; set; }
    }
}
