using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfPaidprogram
    {
        public long Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int Classid { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 封面
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 内容简介
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 个人介绍
        /// </summary>
        public string PersonalDesc { get; set; } = null!;
        /// <summary>
        /// 付费内容价格
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 文件类型 0 单视频 1 多视频
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 视频json串
        /// </summary>
        public string Videos { get; set; } = null!;
        /// <summary>
        /// 购买数量
        /// </summary>
        public long SaleNums { get; set; }
        /// <summary>
        /// 是否审核通过 -1 拒绝 0 审核中 1 通过
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 评价总人数
        /// </summary>
        public long EvaluateNums { get; set; }
        /// <summary>
        /// 评价总分
        /// </summary>
        public long EvaluateTotal { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Edittime { get; set; }
    }
}
