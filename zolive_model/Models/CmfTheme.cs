using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfTheme
    {
        public int Id { get; set; }
        /// <summary>
        /// 安装时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 最后升级时间
        /// </summary>
        public uint UpdateTime { get; set; }
        /// <summary>
        /// 模板状态,1:正在使用;0:未使用
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 是否为已编译模板
        /// </summary>
        public byte IsCompiled { get; set; }
        /// <summary>
        /// 主题目录名，用于主题的维一标识
        /// </summary>
        public string Theme { get; set; } = null!;
        /// <summary>
        /// 主题名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 主题版本号
        /// </summary>
        public string Version { get; set; } = null!;
        /// <summary>
        /// 演示地址，带协议
        /// </summary>
        public string DemoUrl { get; set; } = null!;
        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumbnail { get; set; } = null!;
        /// <summary>
        /// 主题作者
        /// </summary>
        public string Author { get; set; } = null!;
        /// <summary>
        /// 作者网站链接
        /// </summary>
        public string AuthorUrl { get; set; } = null!;
        /// <summary>
        /// 支持语言
        /// </summary>
        public string Lang { get; set; } = null!;
        /// <summary>
        /// 主题关键字
        /// </summary>
        public string Keywords { get; set; } = null!;
        /// <summary>
        /// 主题描述
        /// </summary>
        public string Description { get; set; } = null!;
    }
}
