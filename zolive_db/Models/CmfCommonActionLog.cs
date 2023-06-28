using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfCommonActionLog
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long? User { get; set; }
        /// <summary>
        /// 访问对象的id,格式：不带前缀的表名+id;如posts1表示xx_posts表里id为1的记录
        /// </summary>
        public string? Object { get; set; }
        /// <summary>
        /// 操作名称；格式规定为：应用名+控制器+操作名；也可自己定义格式只要不发生冲突且惟一；
        /// </summary>
        public string? Action { get; set; }
        /// <summary>
        /// 访问次数
        /// </summary>
        public int? Count { get; set; }
        /// <summary>
        /// 最后访问的时间戳
        /// </summary>
        public int? LastTime { get; set; }
        /// <summary>
        /// 访问者最后访问ip
        /// </summary>
        public string? Ip { get; set; }
    }
}
