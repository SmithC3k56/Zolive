using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 权限规则表
    /// </summary>
    public partial class CmfAuthRule
    {
        /// <summary>
        /// 规则id,自增主键
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 是否有效(0:无效,1:有效)
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 规则所属app
        /// </summary>
        public string App { get; set; } = null!;
        /// <summary>
        /// 权限规则分类，请加应用前缀,如admin_
        /// </summary>
        public string Type { get; set; } = null!;
        /// <summary>
        /// 规则唯一英文标识,全小写
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 额外url参数
        /// </summary>
        public string Param { get; set; } = null!;
        /// <summary>
        /// 规则描述
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 规则附加条件
        /// </summary>
        public string Condition { get; set; } = null!;
    }
}
