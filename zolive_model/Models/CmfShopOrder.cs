using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopOrder
    {
        /// <summary>
        /// 订单ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 购买者ID
        /// </summary>
        public long Uid { get; set; }
        /// <summary>
        /// 卖家用户ID
        /// </summary>
        public long ShopUid { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public long Goodsid { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; } = null!;
        /// <summary>
        /// 商品规格ID
        /// </summary>
        public int SpecId { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecName { get; set; } = null!;
        /// <summary>
        /// 规格封面
        /// </summary>
        public string SpecThumb { get; set; } = null!;
        /// <summary>
        /// 购买数量
        /// </summary>
        public int Nums { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 商品总价（包含邮费）
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// 购买者姓名
        /// </summary>
        public string Username { get; set; } = null!;
        /// <summary>
        /// 购买者联系电话
        /// </summary>
        public string Phone { get; set; } = null!;
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; } = null!;
        /// <summary>
        /// 国家代号
        /// </summary>
        public int CountryCode { get; set; }
        /// <summary>
        /// 购买者省份
        /// </summary>
        public string Province { get; set; } = null!;
        /// <summary>
        /// 购买者市
        /// </summary>
        public string City { get; set; } = null!;
        /// <summary>
        /// 购买者地区
        /// </summary>
        public string Area { get; set; } = null!;
        /// <summary>
        /// 购买者详细地址
        /// </summary>
        public string Address { get; set; } = null!;
        /// <summary>
        /// 邮费
        /// </summary>
        public decimal Postage { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string Orderno { get; set; } = null!;
        /// <summary>
        /// 订单类型 1 支付宝 2 微信 3 余额
        /// </summary>
        public bool Type { get; set; }
        /// <summary>
        /// 三方订单号
        /// </summary>
        public string TradeNo { get; set; } = null!;
        /// <summary>
        /// 订单状态  -1 已关闭  0 待付款 1 待发货 2 待收货 3 待评价 4 已评价 5 退款
        /// </summary>
        public sbyte Status { get; set; }
        /// <summary>
        /// 订单添加时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 订单取消时间
        /// </summary>
        public int CancelTime { get; set; }
        /// <summary>
        /// 订单付款时间
        /// </summary>
        public int Paytime { get; set; }
        /// <summary>
        /// 订单发货时间
        /// </summary>
        public int ShipmentTime { get; set; }
        /// <summary>
        /// 订单收货时间
        /// </summary>
        public int ReceiveTime { get; set; }
        /// <summary>
        /// 订单评价时间
        /// </summary>
        public int EvaluateTime { get; set; }
        /// <summary>
        /// 订单结算时间（款项打给卖家）
        /// </summary>
        public int SettlementTime { get; set; }
        /// <summary>
        /// 是否可追加评价
        /// </summary>
        public bool? IsAppendEvaluate { get; set; }
        /// <summary>
        /// 订单抽成比例
        /// </summary>
        public int OrderPercent { get; set; }
        /// <summary>
        /// 订单发起退款时间
        /// </summary>
        public int RefundStarttime { get; set; }
        /// <summary>
        /// 订单退款处理结束时间
        /// </summary>
        public int RefundEndtime { get; set; }
        /// <summary>
        /// 退款处理结果 -2取消申请 -1 失败 0 处理中 1 成功 
        /// </summary>
        public bool RefundStatus { get; set; }
        /// <summary>
        /// 退款时卖家处理结果 0 未处理 -1 拒绝 1 同意
        /// </summary>
        public bool RefundShopResult { get; set; }
        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string ExpressName { get; set; } = null!;
        /// <summary>
        /// 物流公司电话
        /// </summary>
        public string ExpressPhone { get; set; } = null!;
        /// <summary>
        /// 物流公司图标
        /// </summary>
        public string ExpressThumb { get; set; } = null!;
        /// <summary>
        /// 快递公司对应三方平台的编码
        /// </summary>
        public string ExpressCode { get; set; } = null!;
        /// <summary>
        /// 物流单号
        /// </summary>
        public string ExpressNumber { get; set; } = null!;
        /// <summary>
        /// 订单是否删除 0 否 -1 买家删除 -2 卖家删除 1 买家卖家都删除
        /// </summary>
        public bool Isdel { get; set; }
        /// <summary>
        /// 买家留言内容
        /// </summary>
        public string Message { get; set; } = null!;
    }
}
