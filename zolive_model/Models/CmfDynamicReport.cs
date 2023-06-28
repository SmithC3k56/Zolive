using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfDynamicReport
    {
        public uint Id { get; set; }
        /// <summary>
        /// 举报用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 被举报用户ID
        /// </summary>
        public int Touid { get; set; }
        /// <summary>
        /// 动态ID
        /// </summary>
        public int Dynamicid { get; set; }
        /// <summary>
        /// 举报内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 0处理中 1已处理  2审核失败
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 动态类型：0：纯文字；1：文字+图片‘；2：视频+图片；3：语音+图片
        /// </summary>
        public int DynamicType { get; set; }
    }
}
