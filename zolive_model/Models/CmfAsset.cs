using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    /// <summary>
    /// 资源表
    /// </summary>
    public partial class CmfAsset
    {
        public ulong Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public ulong UserId { get; set; }
        /// <summary>
        /// 文件大小,单位B
        /// </summary>
        public ulong FileSize { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public uint CreateTime { get; set; }
        /// <summary>
        /// 状态;1:可用,0:不可用
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        public uint DownloadTimes { get; set; }
        /// <summary>
        /// 文件惟一码
        /// </summary>
        public string FileKey { get; set; } = null!;
        /// <summary>
        /// 文件名
        /// </summary>
        public string Filename { get; set; } = null!;
        /// <summary>
        /// 文件路径,相对于upload目录,可以为url
        /// </summary>
        public string FilePath { get; set; } = null!;
        /// <summary>
        /// 文件md5值
        /// </summary>
        public string FileMd5 { get; set; } = null!;
        public string FileSha1 { get; set; } = null!;
        /// <summary>
        /// 文件后缀名,不包括点
        /// </summary>
        public string Suffix { get; set; } = null!;
        /// <summary>
        /// 其它详细信息,JSON格式
        /// </summary>
        public string? More { get; set; }
    }
}
