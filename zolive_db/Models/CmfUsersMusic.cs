using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfUsersMusic
    {
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 音乐名称
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 演唱者
        /// </summary>
        public string? Author { get; set; }
        /// <summary>
        /// 上传者ID
        /// </summary>
        public int? Uploader { get; set; }
        /// <summary>
        /// 上传类型  1管理员上传 2 用户上传
        /// </summary>
        public bool? UploadType { get; set; }
        /// <summary>
        /// 封面地址
        /// </summary>
        public string? ImgUrl { get; set; }
        /// <summary>
        /// 音乐长度
        /// </summary>
        public string? Length { get; set; }
        /// <summary>
        /// 文件地址
        /// </summary>
        public string? FileUrl { get; set; }
        /// <summary>
        /// 被使用次数
        /// </summary>
        public int? UseNums { get; set; }
        /// <summary>
        /// 是否被删除 0否 1是
        /// </summary>
        public bool? Isdel { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int? Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int? Updatetime { get; set; }
        /// <summary>
        /// 音乐分类ID
        /// </summary>
        public int? ClassifyId { get; set; }
    }
}
