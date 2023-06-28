using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersMusicCollection
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int? Uid { get; set; }
        /// <summary>
        /// 音乐id
        /// </summary>
        public int? MusicId { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int? Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int? Updatetime { get; set; }
        /// <summary>
        /// 音乐收藏状态 1收藏 0 取消收藏
        /// </summary>
        public bool? Status { get; set; }
    }
}
