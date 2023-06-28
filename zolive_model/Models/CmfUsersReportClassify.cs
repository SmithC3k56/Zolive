﻿using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersReportClassify
    {
        public uint Id { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Orderno { get; set; }
        /// <summary>
        /// 举报类型名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int? Addtime { get; set; }
    }
}