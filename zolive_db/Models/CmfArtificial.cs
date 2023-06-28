using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 人工充值
    /// </summary>
    public partial class CmfArtificial
    {
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 可用额度
        /// </summary>
        public string Money { get; set; } = null!;
        /// <summary>
        /// QQ
        /// </summary>
        public string Qq { get; set; } = null!;
        /// <summary>
        /// 微信
        /// </summary>
        public string Wechat { get; set; } = null!;
        /// <summary>
        /// 支付宝
        /// </summary>
        public string PayAli { get; set; } = null!;
        public string TheText { get; set; } = null!;
    }
}
