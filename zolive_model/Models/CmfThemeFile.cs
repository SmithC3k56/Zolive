using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfThemeFile
    {
        public int Id { get; set; }
        /// <summary>
        /// 是否公共的模板文件
        /// </summary>
        public sbyte IsPublic { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public float ListOrder { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Theme { get; set; } = null!;
        /// <summary>
        /// 模板文件名
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 操作
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 模板文件，相对于模板根目录，如Portal/index.html
        /// </summary>
        public string File { get; set; } = null!;
        /// <summary>
        /// 模板文件描述
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 模板更多配置,用户自己后台设置的
        /// </summary>
        public string? More { get; set; }
        /// <summary>
        /// 模板更多配置,来源模板的配置文件
        /// </summary>
        public string? ConfigMore { get; set; }
        /// <summary>
        /// 模板更多配置,用户临时保存的配置
        /// </summary>
        public string? DraftMore { get; set; }
    }
}
