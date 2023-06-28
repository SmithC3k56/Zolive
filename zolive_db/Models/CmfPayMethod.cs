using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 支付管理
    /// </summary>
    public partial class CmfPayMethod
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 支付名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 是否开启 1:未开启; 0:未开启
        /// </summary>
        public bool IsSwitch { get; set; }
        /// <summary>
        /// 是否外部浏览器打开 1:是; 0:否
        /// </summary>
        public bool IsOpen { get; set; }
        /// <summary>
        /// 提交地址
        /// </summary>
        public string Href { get; set; } = null!;
        /// <summary>
        /// 排序
        /// </summary>
        public sbyte Sort { get; set; }
        /// <summary>
        /// 类型 1:支付宝; 2:微信;
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public int Createtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Updatetime { get; set; }
    }
}
