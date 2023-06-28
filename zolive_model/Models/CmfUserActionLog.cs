using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 访问记录表
    /// </summary>
    public partial class CmfUserActionLog
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public ulong UserId { get; set; }
        /// <summary>
        /// 访问次数
        /// </summary>
        public uint Count { get; set; }
        /// <summary>
        /// 最后访问时间
        /// </summary>
        public uint LastVisitTime { get; set; }
        /// <summary>
        /// 访问对象的id,格式:不带前缀的表名+id;如posts1表示xx_posts表里id为1的记录
        /// </summary>
        public string Object { get; set; } = null!;
        /// <summary>
        /// 操作名称;格式:应用名+控制器+操作名,也可自己定义格式只要不发生冲突且惟一;
        /// </summary>
        public string Action { get; set; } = null!;
        /// <summary>
        /// 用户ip
        /// </summary>
        public string Ip { get; set; } = null!;
    }
}
