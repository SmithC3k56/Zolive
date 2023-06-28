﻿using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfMusicClassify
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 排序号
        /// </summary>
        public int ListOrder { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Isdel { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Updatetime { get; set; }
        /// <summary>
        /// 分类图标地址
        /// </summary>
        public string ImgUrl { get; set; } = null!;
        public string TitleEn { get; set; } = null!;
        public string TitleNam { get; set; } = null!;
    }
}
