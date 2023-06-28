using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPushrecord
    {
        public int Id { get; set; }
        /// <summary>
        /// 推送对象
        /// </summary>
        public string Touid { get; set; } = null!;
        /// <summary>
        /// 推送内容
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int Adminid { get; set; }
        /// <summary>
        /// 管理员账号
        /// </summary>
        public string Admin { get; set; } = null!;
        /// <summary>
        /// 管理员IP地址
        /// </summary>
        public long Ip { get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 消息类型 0 后台手动发布的系统消息 1 商品消息
        /// </summary>
        public bool Type { get; set; }
    }
}
