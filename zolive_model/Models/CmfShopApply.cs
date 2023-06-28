using System;
using System.Collections.Generic;

namespace zolive_db.Models
{
    public partial class CmfShopApply
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public uint Uid { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// 封面
        /// </summary>
        public string Thumb { get; set; } = null!;
        /// <summary>
        /// 简介
        /// </summary>
        public string Des { get; set; } = null!;
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string Username { get; set; } = null!;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string Cardno { get; set; } = null!;
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; } = null!;
        /// <summary>
        /// 国家代号
        /// </summary>
        public int CountryCode { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; } = null!;
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; } = null!;
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; } = null!;
        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; } = null!;
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; } = null!;
        /// <summary>
        /// 客服电话
        /// </summary>
        public string ServicePhone { get; set; } = null!;
        /// <summary>
        /// 退货收货人
        /// </summary>
        public string Receiver { get; set; } = null!;
        /// <summary>
        /// 退货人联系电话
        /// </summary>
        public string ReceiverPhone { get; set; } = null!;
        /// <summary>
        /// 退货人省份
        /// </summary>
        public string ReceiverProvince { get; set; } = null!;
        /// <summary>
        /// 退货人市
        /// </summary>
        public string ReceiverCity { get; set; } = null!;
        /// <summary>
        /// 退货人地区
        /// </summary>
        public string ReceiverArea { get; set; } = null!;
        /// <summary>
        /// 退货人详细地址
        /// </summary>
        public string ReceiverAddress { get; set; } = null!;
        /// <summary>
        /// 许可证
        /// </summary>
        public string License { get; set; } = null!;
        /// <summary>
        /// 营业执照
        /// </summary>
        public string Certificate { get; set; } = null!;
        /// <summary>
        /// 其他证件
        /// </summary>
        public string Other { get; set; } = null!;
        /// <summary>
        /// 申请时间
        /// </summary>
        public int Addtime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int Uptime { get; set; }
        /// <summary>
        /// 状态，0审核中1通过2拒绝
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; } = null!;
        /// <summary>
        /// 订单分成比例
        /// </summary>
        public int OrderPercent { get; set; }
        /// <summary>
        /// 店铺总销量
        /// </summary>
        public long SaleNums { get; set; }
        /// <summary>
        /// 店铺商品质量(商品描述)平均分
        /// </summary>
        public float QualityPoints { get; set; }
        /// <summary>
        /// 店铺服务态度平均分
        /// </summary>
        public float ServicePoints { get; set; }
        /// <summary>
        /// 物流服务平均分
        /// </summary>
        public float ExpressPoints { get; set; }
        /// <summary>
        /// 店铺逾期发货次数
        /// </summary>
        public int ShipmentOverdueNum { get; set; }
        public string? Country { get; set; }
        public string? ReceiverCountry { get; set; }
    }
}
