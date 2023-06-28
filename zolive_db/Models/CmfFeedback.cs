using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfFeedback
    {
        public uint Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 系统版本号
        /// </summary>
        public string Version { get; set; } = null!;
        /// <summary>
        /// 设备
        /// </summary>
        public string Model { get; set; } = null!;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 提交时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Thumb { get; set; } = null!;
    }
}
