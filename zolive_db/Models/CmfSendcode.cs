using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfSendcode
    {
        public int Id { get; set; }
        /// <summary>
        /// 消息类型，1表示短信验证码，2表示邮箱验证码
        /// </summary>
        public short Type { get; set; }
        /// <summary>
        /// 接收账号
        /// </summary>
        public string Account { get; set; } = null!;
        /// <summary>
        /// 消息内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 提交时间
        /// </summary>
        public long Addtime { get; set; }
    }
}
