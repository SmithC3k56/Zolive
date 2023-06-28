using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    ///  回收站
    /// </summary>
    public partial class CmfRecycleBin
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 删除内容 id
        /// </summary>
        public int? ObjectId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public uint? CreateTime { get; set; }
        /// <summary>
        /// 删除内容所在表名
        /// </summary>
        public string? TableName { get; set; }
        /// <summary>
        /// 删除内容名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public ulong UserId { get; set; }
    }
}
