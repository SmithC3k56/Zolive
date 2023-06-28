using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPlugin1
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// 插件名，英文
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 插件名称
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 插件描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 插件类型, 1:网站；8;微信
        /// </summary>
        public sbyte? Type { get; set; }
        /// <summary>
        /// 状态；1开启；
        /// </summary>
        public bool? Status { get; set; }
        /// <summary>
        /// 插件配置
        /// </summary>
        public string? Config { get; set; }
        /// <summary>
        /// 实现的钩子;以“，”分隔
        /// </summary>
        public string? Hooks { get; set; }
        /// <summary>
        /// 插件是否有后台管理界面
        /// </summary>
        public sbyte? HasAdmin { get; set; }
        /// <summary>
        /// 插件作者
        /// </summary>
        public string? Author { get; set; }
        /// <summary>
        /// 插件版本号
        /// </summary>
        public string? Version { get; set; }
        /// <summary>
        /// 插件安装时间
        /// </summary>
        public uint Createtime { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public short Listorder { get; set; }
    }
}
