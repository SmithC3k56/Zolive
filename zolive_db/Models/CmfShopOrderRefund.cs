using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopOrderRefund
    {
        public long Id { get; set; }
        /// <summary>
        /// 买家id
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public long Orderid { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long Goodsid { get; set; }
        /// <summary>
        /// 商家ID
        /// </summary>
        public long ShopUid { get; set; }
        /// <summary>
        /// 退款原因
        /// </summary>
        public string Reason { get; set; } = null!;
        /// <summary>
        /// 退款说明
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// 退款图片（废弃）
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 退款类型 0 仅退款 1退货退款
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public int Edittime { get; set; }
        /// <summary>
        /// 店铺处理时间
        /// </summary>
        public int ShopProcessTime { get; set; }
        /// <summary>
        /// 店铺处理结果 -1 拒绝 0 处理中 1 同意
        /// </summary>
        public short ShopResult { get; set; }
        /// <summary>
        /// 店铺驳回次数
        /// </summary>
        public bool ShopProcessNum { get; set; }
        /// <summary>
        /// 平台处理时间
        /// </summary>
        public int PlatformProcessTime { get; set; }
        /// <summary>
        /// 平台处理结果 -1 拒绝 0 处理中 1 同意
        /// </summary>
        public bool PlatformResult { get; set; }
        /// <summary>
        /// 平台处理账号
        /// </summary>
        public string Admin { get; set; } = null!;
        /// <summary>
        /// 平台账号ip
        /// </summary>
        public long Ip { get; set; }
        /// <summary>
        /// 退款处理状态 0 处理中 -1 买家已取消 1 已完成 
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 是否平台介入 0 否 1 是
        /// </summary>
        public bool IsPlatformInterpose { get; set; }
        /// <summary>
        /// 系统自动处理时间
        /// </summary>
        public long SystemProcessTime { get; set; }
        /// <summary>
        /// 申请平台介入的理由
        /// </summary>
        public string PlatformInterposeReason { get; set; } = null!;
        /// <summary>
        /// 申请平台介入的详细原因
        /// </summary>
        public string PlatformInterposeDesc { get; set; } = null!;
        /// <summary>
        /// 申请平台介入的图片举证
        /// </summary>
        public string PlatformInterposeThumb { get; set; } = null!;
    }
}
