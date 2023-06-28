using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class V1PushMessageHistory
    {
        public int PushMessageHistoryId { get; set; }
        /// <summary>
        /// 操作用户
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 推送内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// receiver消息标识
        /// </summary>
        public string? Receiver { get; set; }
        /// <summary>
        /// 推送平台
        /// </summary>
        public string? Platform { get; set; }
        /// <summary>
        /// 消息类型 1 系统消息  2活动消息 3还款提醒 
        /// </summary>
        public int? MsgType { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public int? Time { get; set; }
    }
}
