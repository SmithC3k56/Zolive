using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfSomething
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Uid { get; set; }
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; set; } = null!;
        /// <summary>
        /// 图片
        /// </summary>
        public string Pic { get; set; } = null!;
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Fabulous { get; set; }
        public int Addtime { get; set; }
    }
}
