using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 插件表
    /// </summary>
    public partial class CmfPlugin
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 插件类型;1:网站;8:微信
        /// </summary>
        public byte Type { get; set; }
        /// <summary>
        /// 是否有后台管理,0:没有;1:有
        /// </summary>
        public byte HasAdmin { get; set; }
        /// <summary>
        /// 状态;1:开启;0:禁用
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 插件安装时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 插件标识名,英文字母(惟一)
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 插件名称
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 演示地址，带协议
        /// </summary>
        public string DemoUrl { get; set; } = null!;
        /// <summary>
        /// 实现的钩子;以“,”分隔
        /// </summary>
        public string Hooks { get; set; } = null!;
        /// <summary>
        /// 插件作者
        /// </summary>
        public string Author { get; set; } = null!;
        /// <summary>
        /// 作者网站链接
        /// </summary>
        public string AuthorUrl { get; set; } = null!;
        /// <summary>
        /// 插件版本号
        /// </summary>
        public string Version { get; set; } = null!;
        /// <summary>
        /// 插件描述
        /// </summary>
        public string Description { get; set; } = null!;
        /// <summary>
        /// 插件配置
        /// </summary>
        public string? Config { get; set; }
    }
}
