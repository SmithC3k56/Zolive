using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using zolive_api.Models.Buyer;
using zolive_api.Services.Interface;
using zolive_api.src;
using zolive_db;
using zolive_db.Models;

namespace zolive_unit_test.Buyer
{
    public class TestBuyer
    {
        private readonly IUserService _userService;
        private readonly ICommonService _commonService;
        public static readonly newliveContext context = new newliveContext();
        public static readonly CacheManager cacheManager = new CacheManager();
        public static readonly IRedis redis;
        public static Random rnd = new Random();
        public static IConfiguration InitConfiguration()
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        [SetUp]
        public void Setup()
        {
            var config = InitConfiguration();
            ConfigNew.Configuration = config;
        }
        [Test]
        public async Task MainTest()
        {
            //await getHome(45231);
            // await getGoodsVisitRecord("En", 45231, 1);
            //var chh = new checkdataModel() { time = 1645757369, token = "c343a246cea6cecbde1e56943b887481", uid = 45231 };
            //checkSign(chh, "6fe7454d07d07a8b792def14d2aba99f");
            await getRefundList("En", 45231, 1);
        }
        #region getGoodsOrderList
        public async Task<List<GetGoodsOrderListModel>> getGoodsOrderList(string lan, ulong uid, string type, int p)
        {
            await goodsOrderAutoProcess(lan, uid);
            if (p < 1)
            {
                p = 1;
            }
            var pnums = 50;
            var start = (p - 1) * pnums;
            var now = Utils.time();
            var statusCase = -404;
            switch (type)
            {
                case "wait_payment":
                    statusCase = 0;
                    break;
                case "wait_shipment":
                    statusCase = 1;
                    break;
                case "wait_receive":
                    statusCase = 2;
                    break;
                case "wait_evaluate":
                    statusCase = 3;
                    break;
                case "refund":
                    statusCase = 5;
                    break;
            }
            List<CmfShopOrder> list = new List<CmfShopOrder>();
            if (statusCase == -404)
            {
                list = await context.CmfShopOrders.Where(x => x.Uid == (long)uid && x.Isdel != -1 && x.Isdel != 1).Skip(start).Take(pnums).OrderByDescending(x => x.Addtime).ToListAsync();
            }
            else
            {
                list = await context.CmfShopOrders.Where(x => x.Uid == (long)uid && x.Isdel != -1 && x.Isdel != 1 && x.Status == statusCase).Skip(start).Take(pnums).OrderByDescending(x => x.Addtime).ToListAsync();
            }
            var lst = list.Select(x => new
            {
                id = x.Id,
                uid = x.Uid,
                shop_uid = x.ShopUid,
                goodsid = x.Goodsid,
                goods_name = x.GoodsName,
                spec_name = x.SpecName,
                spec_thumb = x.SpecThumb,
                nums = x.Nums,
                price = x.Price,
                total = x.Total,
                status = x.Status,
                is_append_evaluate = x.IsAppendEvaluate,
                refund_status = x.RefundStatus,
                addtime = x.Addtime,
                paytime = x.Paytime
            });
            var shopEffectiveTime = await getShopEffectiveTime();

            var listrslt = new List<GetGoodsOrderListModel>();
            foreach (var x in lst)
            {
                var obj = new GetGoodsOrderListModel()
                {
                    id = x.id,
                    uid = x.uid,
                    shop_uid = x.shop_uid,
                    goodsid = x.goodsid,
                    goods_name = x.goods_name,
                    spec_name = x.spec_name,
                    spec_thumb = x.spec_thumb,
                    nums = x.nums,
                    price = x.price,
                    total = x.total,
                    status = x.status,
                    is_append_evaluate = x.is_append_evaluate,
                    refund_status = x.refund_status,
                    addtime = x.addtime,
                    paytime = x.paytime
                };
                switch (obj.status)
                {
                    case -1:
                        obj.status_name = "交易已关闭";
                        if (lan == "En") obj.status_name = "Transaction closed";
                        if (lan == "Nam") obj.status_name = "Giao dịch đóng";
                        break;
                    case 0:
                        var end = shopEffectiveTime.shop_payment_time * 60 + obj.addtime;
                        var cha = end - now;
                        obj.status_name = "等待买家付款";
                        if (lan == "En") obj.status_name = "Awaiting payment ";
                        if (lan == "Nam") obj.status_name = "Chờ người mua thanh toán ";
                        obj.status_name += Utils.getSeconds(cha, 1);
                        break;
                    case 1:
                        obj.status_name = "买家已付款";
                        if (lan == "En") obj.status_name = "Buyer has paid";
                        if (lan == "Nam") obj.status_name = "Người mua đã thanh toán";
                        break;
                    case 2:
                        obj.status_name = "卖家已发货";
                        if (lan == "En") obj.status_name = "Product has been dispatched";
                        if (lan == "Nam") obj.status_name = "Người bán đã gửi hàng";
                        break;
                    case 3:
                        obj.status_name = "已收货";
                        if (lan == "En") obj.status_name = "Received";
                        if (lan == "Nam") obj.status_name = "Đã nhận hàng";
                        break;
                    case 4:
                        obj.status_name = "已评价";
                        if (lan == "En") obj.status_name = "Reviewed";
                        if (lan == "Nam") obj.status_name = "Đã đánh giá";
                        break;
                    case 5:
                        if (obj.refund_status == 0)
                        {
                            obj.status_name = "申请退款中";
                            if (lan == "En") obj.status_name = "Applying for refund";
                            if (lan == "Nam") obj.status_name = "Đang yêu cầu hoàn tiền";
                        }
                        else if (obj.refund_status == -1)
                        {
                            obj.status_name = "退款失败";
                            if (lan == "En") obj.status_name = "Refund failed";
                            if (lan == "Nam") obj.status_name = "Hoàn tiền thất bại";
                        }
                        else
                        {
                            obj.status_name = "退款成功";
                            if (lan == "En") obj.status_name = "Refund sucessful";
                            if (lan == "Nam") obj.status_name = "Hoàn tiền thành công";
                        }
                        break;
                }
                obj.spec_thumb = Utils.get_upload_path(obj.spec_thumb);
                var shop_info = await _userService.getShop(lan, (ulong)obj.shop_uid);
                obj.shop_name = shop_info.name;
                obj.shop_info = shop_info;
                listrslt.Add(obj);
            }
            return listrslt;
        }

        public async Task goodsOrderAutoProcess(string lan, ulong uid)
        {
            var list = await context.CmfShopOrders.Where(x => x.Uid == (long)uid && x.Isdel != -1 && x.Isdel != -2 && x.Isdel != 1 && x.Status != -1).OrderByDescending(x => x.Addtime).ToListAsync();

            var now = Utils.time();
            var effective_time = await getShopEffectiveTime();

            foreach (var v in list)
            {
                if (v.Status == 0)
                {
                    var pay_end = v.Addtime + effective_time.shop_payment_time * 60;
                    if (pay_end <= now)
                    {
                        #region changeShopOrderStatus
                        CmfShopOrder res = await context.CmfShopOrders.Where(x => x.Id == v.Id).FirstOrDefaultAsync() ?? new CmfShopOrder();
                        res.Status = -1;
                        res.CancelTime = now;
                        context.CmfShopOrders.Update(res);
                        await context.SaveChangesAsync();
                        #endregion
                        #region changeShopGoodsSpecNum
                        await changeShopGoodsSpecNum((ulong)v.Goodsid, v.SpecId, v.Nums, 1);
                        #endregion


                        var title = "你购买的“" + v.GoodsName + "”订单由于超时未付款,已自动关闭";
                        var title_nam = "Bạn mua “" + v.GoodsName + "” do quá thời gian xử thanh toán, đơn tự động đóng";
                        var title_en = "Your purchase“" + v.GoodsName + "” has not been paid. Order has been closed.";
                        CmfShopOrderMessage data1 = new CmfShopOrderMessage()
                        {
                            Uid = v.Uid,
                            Orderid = v.Id,
                            Title = title,
                            Addtime = now,
                            Type = 0,
                            TitleNam = title_nam,
                            TitleEn = title_en
                        };
                        await context.CmfShopOrderMessages.AddAsync(data1);
                        await context.SaveChangesAsync();
                        await jMessageIM(title, (ulong)v.Uid, "goodsorder_admin");
                    }
                }
                if (v.Status == 1)
                {
                    decimal shipment_end = 0;
                    if (v.RefundStatus == 0)
                    {
                        shipment_end = v.Paytime + effective_time.shop_shipment_time * 60 * 60 * 24;
                    }
                    else
                    {
                        shipment_end = v.RefundEndtime + effective_time.shop_shipment_time * 60 * 60 * 24;
                    }
                    if (shipment_end <= now)
                    {
                        #region changeShopOrderStatus
                        var shopOrder = await context.CmfShopOrders.Where(x => x.Id == v.Id).FirstOrDefaultAsync();
                        if (shopOrder != null)
                        {
                            shopOrder.Status = -1;
                            shopOrder.CancelTime = now;
                            context.CmfShopOrders.Update(shopOrder);
                            await context.SaveChangesAsync();
                        }
                        #endregion
                        #region setUserBalance
                        await setUserBalance((ulong)v.Uid, 1, v.Total);
                        #endregion
                        #region addBalanceRecord
                        CmfUserBalanceRecord obj = new CmfUserBalanceRecord()
                        {
                            Uid = v.Uid,
                            Touid = v.ShopUid,
                            Balance = v.Total,
                            Type = 1,
                            Action = 3,
                            Orderid = v.Id,
                            Addtime = now
                        };
                        await context.CmfUserBalanceRecords.AddAsync(obj);
                        await context.SaveChangesAsync();
                        #endregion

                        var obj_shop_apply = await context.CmfShopApplies.Where(x => x.Uid == v.ShopUid).FirstOrDefaultAsync();
                        if (obj_shop_apply != null)
                        {
                            obj_shop_apply.ShipmentOverdueNum += 1;
                            context.CmfShopApplies.Update(obj_shop_apply);
                            await context.SaveChangesAsync();
                        }



                        await changeShopGoodsSaleNums((ulong)v.Goodsid, 0, v.Nums);
                        await changeShopSaleNums((ulong)v.ShopUid, 0, v.Nums);

                        var title = "你购买的“" + v.GoodsName + "”订单由于卖家超时未发货已自动关闭,货款已退还到余额账户中";
                        var title_en = "Your purchase “" + v.GoodsName + "” has not been dispatched within the time limit, full refund has been credited";
                        var title_nam = "Bạn mua“" + v.GoodsName + "”do người bán quá thời gian không gửi hàng, tiền hàng đã hoàn về tài khoản của bạn";

                        #region addShopGoodsOrderMessage
                        var data2 = new CmfShopOrderMessage()
                        {
                            Uid = v.Uid,
                            Orderid = v.Id,
                            Title = title,
                            Addtime = now,
                            Type = 0,
                            TitleEn = title_en,
                            TitleNam = title_nam
                        };

                        await context.CmfShopOrderMessages.AddAsync(data2);
                        await context.SaveChangesAsync();
                        #endregion


                        await jMessageIM(title, (ulong)v.Uid, "goodsorder_admin");



                    }

                }

                if (v.Status == 2)
                {
                    decimal receive_end = 0;
                    if (v.RefundStatus == 0)
                    {
                        receive_end = v.ShipmentTime + effective_time.shop_receive_time * 60 * 60 * 24;
                    }
                    else
                    {
                        receive_end = v.RefundEndtime + effective_time.shop_receive_time * 60 * 60 * 24;
                    }

                    if (receive_end <= now)
                    {
                        #region changeShopOrderStatus
                        var shopOrder = await context.CmfShopOrders.Where(x => x.Id == v.Id).FirstOrDefaultAsync();
                        if (shopOrder != null)
                        {
                            shopOrder.Status = 3;
                            shopOrder.ReceiveTime = now;
                            context.CmfShopOrders.Update(shopOrder);
                            await context.SaveChangesAsync();
                        }
                        #endregion
                        var title = "你购买的“" + v.GoodsName + "”订单已自动确认收货";
                        var title_nam = "Bạn mua “" + v.GoodsName + "” đã tự động xác nhận nhận hàng";
                        var title_en = "Your purchase “" + v.GoodsName + "” has been automatically confirmed receipt";
                        #region addShopGoodsOrderMessage
                        CmfShopOrderMessage data1 = new CmfShopOrderMessage()
                        {
                            Uid = v.Uid,
                            Orderid = v.Id,
                            Title = title,
                            Addtime = now,
                            Type = 0,
                            TitleNam = title_nam,
                            TitleEn = title_en
                        };
                        await context.CmfShopOrderMessages.AddAsync(data1);
                        await context.SaveChangesAsync();
                        #endregion
                        await jMessageIM(title, (ulong)v.Uid, "goodsorder_admin");

                    }
                }
                if (v.Status == 3 || v.Status == 4 && v.SettlementTime == 0)
                {
                    decimal settlement_end = 0;
                    if (v.RefundStatus == 0)
                    {
                        settlement_end = v.ReceiveTime + effective_time.shop_settlement_time * 60 * 60 * 24;
                    }
                    else
                    {
                        settlement_end = v.RefundEndtime + effective_time.shop_settlement_time * 60 * 60 * 24;
                    }
                    if (settlement_end < now)
                    {
                        var balance = v.Total;
                        if (v.OrderPercent > 0)
                        {
                            balance = v.Total * (100 - v.OrderPercent / 100);
                            balance = Math.Round(balance, 2);
                        }

                        await setUserBalance((ulong)v.ShopUid, 1, balance);

                        #region changeShopOrderStatus
                        var shopOrder = await context.CmfShopOrders.Where(x => x.Id == v.Id).FirstOrDefaultAsync();
                        if (shopOrder != null)
                        {
                            shopOrder.SettlementTime = now;
                            context.CmfShopOrders.Update(shopOrder);
                            await context.SaveChangesAsync();
                        }
                        #endregion

                        #region addBalanceRecord
                        var UserBalanceRecord = new CmfUserBalanceRecord()
                        {
                            Uid = v.ShopUid,
                            Touid = v.Uid,
                            Balance = balance,
                            Type = 1,
                            Action = 2,
                            Orderid = v.Id,
                            Addtime = now
                        };

                        await context.CmfUserBalanceRecords.AddAsync(UserBalanceRecord);
                        await context.SaveChangesAsync();
                        #endregion

                        var title = "买家购买的“" + v.GoodsName + "”订单已自动结算到你的账户";
                        var title_nam = "Nguời mua “" + v.GoodsName + "” đơn hàng tự động thanh toán vào tài khoản của bạn";
                        var title_en = "Someone purchased “" + v.GoodsName + "” Order has been credited to your account.";
                        #region addShopGoodsOrderMessage
                        var data2 = new CmfShopOrderMessage()
                        {
                            Uid = v.ShopUid,
                            Orderid = v.Id,
                            Title = title,
                            Addtime = now,
                            Type = 1,
                            TitleEn = title_en,
                            TitleNam = title_nam
                        };
                        await context.CmfShopOrderMessages.AddAsync(data2);
                        await context.SaveChangesAsync();
                        #endregion
                        await jMessageIM(title, (ulong)v.ShopUid, "goodsorder_admin");
                    }

                }
                if (v.Status == 5 && v.RefundStatus == 0)
                {
                    var refund_info = await getShopOrderRefundInfo(lan, v.Id);
                    if (refund_info.IsPlatformInterpose == false && refund_info.ShopResult == 0)
                    {
                        var refund_end = refund_info.Addtime + effective_time.shop_refund_time * 60 * 60 * 24;
                        if (refund_end <= now)
                        {
                            #region changeShopOrderStatus
                            var shopOrder = await context.CmfShopOrders.Where(x => x.Id == v.Id).FirstOrDefaultAsync();
                            if (shopOrder != null)
                            {
                                shopOrder.RefundStatus = 1;
                                shopOrder.RefundEndtime = now;
                                context.CmfShopOrders.Update(shopOrder);
                                await context.SaveChangesAsync();
                            }
                            #endregion
                            #region changeGoodsOrderRefund
                            var shopOrderRefund = await context.CmfShopOrderRefunds.Where(x => x.Uid == (long)uid).FirstOrDefaultAsync();
                            if (shopOrderRefund != null)
                            {
                                shopOrderRefund.SystemProcessTime = now;
                                shopOrderRefund.Status = true;
                                context.CmfShopOrderRefunds.Update(shopOrderRefund);
                                await context.SaveChangesAsync();
                            }
                            #endregion

                            await setUserBalance((ulong)v.Uid, 1, v.Total);
                            #region addBalanceRecord
                            var data1 = new CmfUserBalanceRecord()
                            {
                                Uid = v.Uid,
                                Touid = v.ShopUid,
                                Balance = v.Total,
                                Type = 1,
                                Action = 4,
                                Orderid = v.Id,
                                Addtime = now
                            };
                            await context.CmfUserBalanceRecords.AddAsync(data1);
                            await context.SaveChangesAsync();
                            #endregion
                            await changeShopGoodsSaleNums((ulong)v.Goodsid, 0, v.Nums);
                            await changeShopSaleNums((ulong)v.ShopUid, 0, v.Nums);
                            await changeShopGoodsSpecNum((ulong)v.Goodsid, v.SpecId, v.Nums, 1);

                            var title = "你申请的“" + v.GoodsName + "”订单退款卖家超时未处理,已自动退款到你的余额账户中";
                            var title_en = "You applied refund for “" + v.GoodsName + "” ,as it has not been dealt with, full refund has been credited into your account.";
                            var title_nam = "Bạn gửi yêu cầu hoàn tiền “" + v.GoodsName + "” người bán quá thời gian xử lý, tự động hoàn tiền vào tài khoản của bạn";

                            #region addShopGoodsOrderMessage
                            var data2 = new CmfShopOrderMessage()
                            {
                                Uid = v.Uid,
                                Orderid = v.Id,
                                Title = title,
                                Addtime = now,
                                Type = 0,
                                TitleNam = title_nam,
                                TitleEn = title_en
                            };
                            await context.CmfShopOrderMessages.AddAsync(data2);
                            await context.SaveChangesAsync();
                            #endregion
                            await jMessageIM(title, (ulong)v.Uid, "goodsorder_admin");
                        }
                    }
                    if (refund_info.IsPlatformInterpose == false && refund_info.ShopResult == -1)
                    {
                        var finish_endtime = refund_info.ShopProcessTime + effective_time.shop_refund_finish_time * 60 * 60 * 24;
                        if (finish_endtime <= now)
                        {
                            #region changeGoodsOrderRefund
                            var shopOrderRefund = await context.CmfShopOrderRefunds.Where(x => x.Uid == (long)uid).FirstOrDefaultAsync();
                            if (shopOrderRefund != null)
                            {
                                shopOrderRefund.SystemProcessTime = now;
                                shopOrderRefund.Status = true;
                                context.CmfShopOrderRefunds.Update(shopOrderRefund);
                                await context.SaveChangesAsync();
                            }
                            #endregion

                            #region changeShopOrderStatus 
                            var shopOrder = await context.CmfShopOrders.Where(x => x.Id == v.Id).FirstOrDefaultAsync();
                            if (shopOrder != null)
                            {
                                shopOrder.RefundStatus = -1;
                                shopOrder.RefundEndtime = now;

                                if (v.ReceiveTime > 0)
                                {
                                    shopOrder.Status = 3;
                                }
                                else
                                {
                                    if (v.ShipmentTime > 0)
                                    {
                                        shopOrder.Status = 2;
                                    }
                                    else
                                    {
                                        shopOrder.Status = 1;
                                    }
                                }

                                context.CmfShopOrders.Update(shopOrder);
                                await context.SaveChangesAsync();

                                var title = "你购买的“" + v.GoodsName + "”订单退款申请被卖家拒绝后," + effective_time.shop_refund_finish_time + "天内你没有进一步操作,系统自动处理结束";
                                var title_en = "Your refund request for “" + v.GoodsName + "” has been rejected by the seller. As u did not respond in " + effective_time.shop_refund_finish_time + " days, request has been ended.";
                                var title_nam = "Bạn mua “" + v.GoodsName + "”sau bị người bán từ chối đơn hoàn tiền, trong vòng ," + effective_time.shop_refund_finish_time + "ngày bạn không xử lý, hệ thống sẽ tự động xử lý đóng";
                                #region addShopGoodsOrderMessage
                                var data2 = new CmfShopOrderMessage()
                                {
                                    Uid = v.Uid,
                                    Orderid = v.Id,
                                    Title = title,
                                    Addtime = now,
                                    Type = 0,
                                    TitleEn = title_en,
                                    TitleNam = title_nam
                                };
                                await context.CmfShopOrderMessages.AddAsync(data2);
                                await context.SaveChangesAsync();
                                #endregion
                                await jMessageIM(title, (ulong)v.Uid, "goodsorder_admin");
                            }
                            #endregion

                        }
                    }
                }
            }


        }
        public async Task<CmfShopOrderRefund> getShopOrderRefundInfo(string lan, long id)
        {
            var info = await context.CmfShopOrderRefunds.Where(x => x.Orderid == id).FirstOrDefaultAsync();
            if (info != null)
            {
                var op = await context.CmfShopRefundReasons.Where(x => x.Name == info.Reason).FirstOrDefaultAsync();
                if (op != null)
                {
                    if (lan == "Nam")
                    {
                        info.Reason = op.NameNam;
                    }
                    else if (lan == "En")
                    {
                        info.Reason = op.NameEn;
                    }
                }
            }
            else
            {
                info = new CmfShopOrderRefund();
            }
            return info;
        }
        public async Task changeShopSaleNums(ulong uid, int type, int nums)
        {
            var shop = new CmfShopApply();

            if (type == 1)
            {
                shop = await context.CmfShopApplies.Where(x => x.Uid == uid && x.SaleNums >= nums).FirstOrDefaultAsync();
                if (shop != null)
                {
                    shop.SaleNums -= nums;
                    context.CmfShopApplies.Update(shop);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                shop = await context.CmfShopApplies.Where(x => x.Uid == uid).FirstOrDefaultAsync();
                if (shop != null)
                {
                    shop.SaleNums += nums;
                    context.CmfShopApplies.Update(shop);
                    await context.SaveChangesAsync();
                }
            }

        }
        public async Task changeShopGoodsSaleNums(ulong goodsid, int type, int nums)
        {

            var goods = new CmfShopGood();
            if (type == 0)
            {
                goods = await context.CmfShopGoods.Where(x => x.Id == goodsid && x.SaleNums >= nums).FirstOrDefaultAsync();
                if (goods != null)
                {
                    goods.SaleNums -= nums;

                    context.CmfShopGoods.Update(goods);
                    await context.SaveChangesAsync();
                }
            }
            else
            {
                goods = await context.CmfShopGoods.Where(x => x.Id == goodsid).FirstOrDefaultAsync();
                if (goods != null)
                {
                    goods.SaleNums += nums;

                    context.CmfShopGoods.Update(goods);
                    await context.SaveChangesAsync();
                }
            }

        }
        public async Task<int> setUserBalance(ulong uid, int type, decimal balance)
        {
            var res = 0;
            if (type == 0)
            {
                var obj = await context.CmfUsers1.Where(x => x.Id == uid && x.Balance >= balance).FirstOrDefaultAsync();
                if (obj != null)
                {
                    obj.Balance -= balance;
                    obj.BalanceConsumption += balance;

                    context.CmfUsers1.Update(obj);
                    await context.SaveChangesAsync();
                    res = 1;//đoạn này là tự custom để bt được code sẽ thực hiện đoạn này
                }

            }
            else if (type == 1)
            {
                var obj = await context.CmfUsers1.Where(x => x.Id == uid).FirstOrDefaultAsync();
                if (obj != null)
                {
                    obj.Balance += balance;
                    obj.BalanceTotal += balance;
                    context.CmfUsers1.Update(obj);
                    await context.SaveChangesAsync();
                    res = 2;
                }
            }
            return res;
        }
        // [Test]
        // public async Task MainTest22()
        // {
        //     await jMessageIM("Hello, this is title", 45219, "goodsorder_admin");
        // }

        public async Task jMessageIM(string test, ulong uid, string adminName)
        {
            var configPri = await _commonService.getConfigPri();
            var appKey = configPri.jpush_key;
            var masterSecret = configPri.jpush_secret;
            if (!string.IsNullOrEmpty(appKey.ToString()) && !string.IsNullOrEmpty(masterSecret.ToString()))
            {
                var nickname = "";
                switch (adminName)
                {
                    case "goodsorder_admin":
                        nickname = "Quản lý đơn hàng";
                        break;
                    default:
                        nickname = "";
                        break;
                }

                var regInfo = new
                {
                    username = adminName,
                    password = adminName,
                    nickname = nickname
                };

                var response = await register(regInfo);
                var Error = response["error"];
                var ErrorCode = (int)(response["error"]["code"]);
                if (Error == null || ErrorCode == 899001)
                {
                    var from = new
                    {
                        id = adminName,
                        type = "admin"
                    };
                    var msg = new
                    {
                        text = test
                    };
                    var notification = new
                    {
                        notifiable = false
                    };
                    var target = new
                    {
                        id = "" + uid,
                        type = "single"
                    };
                    await sendText(1, from, msg, target, notification, new int[0]);

                }
            }
        }

        #region Class Message
        public async Task<JObject> send(sendTextModel options)
        {
            var uri = "https://api.im.jpush.cn/v1/messages";
            var body = options;
            var Cbody = JsonConvert.SerializeObject(body);
            HttpContent c = new StringContent(Cbody, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync("https://api.im.jpush.cn/v1/admins", c);
            var dataFromServer = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(dataFromServer);
            return json;

        }
        public async Task<JObject> sendText(int version, dynamic from, dynamic target, dynamic msg, dynamic notification, dynamic options)
        {
            var buildMsg = buildMessage(version, from, target, notification, options);

            var opts = new sendTextModel()
            {
                msg_type = "text",
                msg_body = new msg_bodyModel()
                {
                    text = msg.text.ToString()
                },
                version = buildMsg.version,
                target_type = buildMsg.target_type,
                from_type = buildMsg.from_type,
                target_id = buildMsg.target_id,
                from_id = buildMsg.from_id,
                from_name = buildMsg.from_name,
                target_name = buildMsg.target_name,
                no_offline = buildMsg.no_offline,
                target_appkey = buildMsg.target_appkey,
                title = buildMsg.title,
                notification = buildMsg.notification,
                no_notification = buildMsg.no_notification
            };
            var rs = await send(opts);
            return rs;
        }
        public buildMessageModel buildMessage(int version, dynamic from, dynamic target, dynamic notification, dynamic options)
        {
            var opts = new buildMessageModel()
            {
                version = version,
                target_type = target.type,
                from_type = from.type,
                target_id = target.id,
                from_id = from.id,
            };
            if (from.name != null)
            {
                opts.from_name = from.name.ToString();
            }
            else if (target.name != null)
            {
                opts.target_name = target.name;
            }
            else if (options.offline != null)
            {
                opts.no_offline = !options.offline;
            }
            else if (options.target_appkey != null)
            {
                opts.target_appkey = options.target_appkey;
            }
            else if (notification.notifiable != null)
            {
                opts.no_notification = !(bool)notification.notifiable;
            }
            else if (notification.title != null)
            {
                opts.notification.title = notification.title;
            }
            else if (notification.alert != null)
            {
                opts.notification.alert = notification.alert;
            }
            return opts;
        }

        #endregion
        #region Class Admin
        public async Task<JObject> register(dynamic body)
        {
            var Cbody = JsonConvert.SerializeObject(body);
            HttpContent c = new StringContent(Cbody, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync("https://api.im.jpush.cn/v1/admins", c);
            var dataFromServer = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(dataFromServer);
            return json;
        }
        
        #endregion
        public async Task<short> changeShopGoodsSpecNum(ulong goodsid, long spec_id, long nums, long type)
        {
            var goods_info = await context.CmfShopGoods.Where(x => x.Id == goodsid).FirstOrDefaultAsync();

            if (goods_info == null)
            {
                return 0;
            }

            var spec_arr = JsonConvert.DeserializeObject<List<dynamic>>(goods_info.Specs) ?? new List<dynamic>();

            var specid_arr = spec_arr.ToList().Select(x => x.spec_id).ToArray();

            if (!specid_arr.Contains(spec_id))
            {
                return 0;
            }
            var count = 0;
            foreach (var v in spec_arr)
            {
                if ((long)v.spec_id == spec_id)
                {
                    count++;
                    var spec_num = 0;
                    if (type == 1)
                    {
                        spec_num = v.spec_num + nums;
                    }
                    else
                    {
                        spec_num = v.spec_num - nums;
                    }

                    if (spec_num < 0)
                    {
                        spec_num = 0;
                    }
                    specid_arr[count].spec_num = spec_num;

                }
            }
            var spec_str = JsonConvert.SerializeObject(specid_arr);
            var shopGood = await context.CmfShopGoods.Where(x => x.Id == goodsid).FirstOrDefaultAsync();
            if (shopGood != null)
            {
                shopGood.Specs = spec_str;
                context.CmfShopGoods.Update(shopGood);
                await context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }


            return 1;
        }
        public async Task<getShopEffectiveTimeModel> getShopEffectiveTime()
        {
            var configpri = await _commonService.getConfigPri();
            var shop_payment_time = configpri.shop_payment_time;
            var shop_shipment_time = configpri.shop_shipment_time;
            var shop_receive_time = configpri.shop_receive_time;
            var shop_refund_time = configpri.shop_refund_time;
            var shop_refund_finish_time = configpri.shop_refund_finish_time;
            var shop_receive_refund_time = configpri.shop_receive_refund_time;
            var shop_settlement_time = configpri.shop_settlement_time;

            getShopEffectiveTimeModel data = new getShopEffectiveTimeModel();
            data.shop_payment_time = decimal.Parse(shop_payment_time.Value);
            data.shop_shipment_time = decimal.Parse(shop_shipment_time.Value);
            data.shop_receive_time = decimal.Parse(shop_receive_time.Value);
            data.shop_refund_time = decimal.Parse(shop_refund_time.Value);
            data.shop_refund_finish_time = decimal.Parse(shop_refund_finish_time.Value);
            data.shop_receive_refund_time = decimal.Parse(shop_receive_refund_time.Value);
            data.shop_settlement_time = decimal.Parse(shop_settlement_time.Value);

            return data;
        }

        #endregion
        #region getRefundList
        public async Task<List<getRefundListModel>> getRefundList(string lan, ulong uid, int p)
        {
            if (p < 1) p = 1;
            var pnums = 50;
            var start = (p - 1) * pnums;
            int[] arrnum = { 3, 4, 5, 6 };
            var list = await context.CmfUserBalanceRecords.Where(x => x.Uid == (long)uid && x.Type == 1 && arrnum.Contains(x.Action)).Skip(start).Take(pnums).ToListAsync();
            List<getRefundListModel> rs = new List<getRefundListModel>();
            foreach (var v in list)
            {
                getRefundListModel obj = new getRefundListModel();
                obj.id = v.Id;
                obj.uid = v.Uid;
                obj.touid = v.Touid;
                obj.type = v.Type;
                obj.action = v.Action;
                obj.orderid = v.Orderid;

                obj.addtime = Utils.UnixTimeToDateTime(v.Addtime).ToString("yyyy-MM-dd HH:mm");
                obj.balance = "$" + v.Balance;
                obj.result = "Nhận";
                if (lan == "En") obj.result = "Received";

                rs.Add(obj);
            }
            return rs;
        }
        #endregion
        #region addressList
        public bool checkSign(string[] data, string sign)
        {
            var key = "app.sign_key";
            // var str = "time=" + data.time + "&token=" + data.token + "&uid=" + data.uid + "&";
            var str = key;
            var newsign = Utils.MD5Hash(str);
            if (sign != newsign)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task<List<AddressListModel>> addressList(ulong uid)
        {
            List<AddressListModel> result = new List<AddressListModel>();
            var list = await context.CmfShopAddresses.Where(x => x.Uid == uid).OrderByDescending(x => x.IsDefault).ThenByDescending(x => x.Addtime)
                .Select(g => new
                {
                    id = g.Uid,
                    name = g.Name,
                    country = g.Country,
                    province = g.Province,
                    city = g.City,
                    area = g.Area,
                    address = g.Address,
                    country_code = g.CountryCode,
                    phone = g.Phone,
                    is_default = g.IsDefault,
                    receiver_country = g.ReceiverCountry
                }).ToListAsync();

            if (list.Count > 0)
            {
                foreach (var v in list)
                {
                    AddressListModel obj = new AddressListModel();
                    obj.id = v.id;
                    obj.name = v.name;
                    obj.country = v.country;
                    obj.province = v.province;
                    obj.city = v.city;
                    obj.area = v.area;
                    obj.address = v.address;
                    obj.country_code = v.country_code;
                    obj.phone = v.phone;
                    obj.is_default = v.is_default;
                    obj.receiver_country = v.receiver_country;
                    result.Add(obj);
                }
            }
            return result;
        }
        #endregion
        #region getGoodsVisitRecord
        public async Task<ModelNewList> getGoodsVisitRecord(string lan, ulong uid, int p)
        {
            ModelNewList arrMd = new ModelNewList();
            var list = await getGoodsVisitRecord1(uid, p);
            if (list.Count > 0)
            {

                var time_formats = list.Select(x => x.TimeFormat).ToArray();
                time_formats = time_formats.Distinct().ToArray();
                foreach (var v in time_formats)
                {

                    arrMd.date = v;
                    foreach (var v1 in list)
                    {
                        V1Model objV1 = new V1Model();
                        CmfShopGood goodsinfo = await context.CmfShopGoods.Where(x => x.Id == v1.Goodsid).FirstOrDefaultAsync() ?? new CmfShopGood();
                        var goodinfo = await handleGoods(lan, goodsinfo);
                        objV1.goods_name = goodsinfo.Name;
                        objV1.goods_thumb = goodinfo.thumbs_format[0];
                        objV1.addtime = Utils.UnixTimeToDateTime(goodsinfo.Addtime).ToString("yyyy-MM-dd HH:mm:ss");
                        objV1.goods_status = goodsinfo.Status;
                        objV1.type = goodsinfo.Type;
                        objV1.href = goodsinfo.Href;
                        objV1.original_price = "$" + goodsinfo.OriginalPrice;
                        objV1.time_format = v1.TimeFormat;
                        if (v1.TimeFormat == v)
                        {
                            arrMd.list.Add(objV1);
                        }
                    }

                }
                return arrMd;
            }
            return arrMd;
        }
        public async Task<handleGoodsModel> handleGoods(string lan, CmfShopGood goodsinfo)
        {
            var one_classinfo = await getGoodsClassInfo(goodsinfo.OneClassid);
            var two_classinfo = await getGoodsClassInfo(goodsinfo.TwoClassid);
            var three_classinfo = await getGoodsClassInfo(goodsinfo.ThreeClassid);

            handleGoodsModel goodinfo = new handleGoodsModel();

            goodinfo.one_class_name = String.IsNullOrEmpty(one_classinfo.GcName) ? "分类不存在" : one_classinfo.GcName;
            goodinfo.two_class_name = String.IsNullOrEmpty(two_classinfo.GcName) ? "分类不存在" : two_classinfo.GcName;
            goodinfo.three_class_name = String.IsNullOrEmpty(three_classinfo.GcName) ? "分类不存在" : three_classinfo.GcName;

            goodinfo.hits = goodsinfo.Hits == 0 ? "0" : Utils.NumberFormat(lan, goodsinfo.Hits);
            goodinfo.sale_nums = goodsinfo.SaleNums == 0 ? "0" : Utils.NumberFormat(lan, goodsinfo.SaleNums);
            goodinfo.video_url_format = String.IsNullOrWhiteSpace(goodsinfo.VideoUrl) ? "" : Utils.get_upload_path(goodsinfo.VideoUrl);
            goodinfo.video_thumb_format = String.IsNullOrWhiteSpace(goodsinfo.VideoThumb) ? "" : Utils.get_upload_path(goodsinfo.VideoThumb);

            List<string> thumb_arr = new List<string>();
            if (!String.IsNullOrWhiteSpace(goodsinfo.Thumbs))
            {
                var thum_arr = goodsinfo.Thumbs.Split(",");
                foreach (var v in thum_arr)
                {
                    var newPath = Utils.get_upload_path(v);
                    thumb_arr.Add(newPath);
                }
            }

            goodinfo.thumbs_format = thumb_arr;

            if (goodsinfo.Type == 1)
            {
                goodinfo.specs_format = new List<dynamic>();
            }
            else
            {
                var spec_arr = JsonConvert.DeserializeObject<List<dynamic>>(goodsinfo.Specs) ?? new List<dynamic>();
                foreach (var v in spec_arr)
                {
                    v.thumb = Utils.get_upload_path(v.thumb.ToString());
                    goodinfo.specs_format.Add(v);
                }
            }
            List<string> picture_list = new List<string>();
            if (!String.IsNullOrWhiteSpace(goodsinfo.Pictures))
            {
                var picture_arr = goodsinfo.Pictures.Split(",");
                foreach (var v in picture_arr)
                {
                    var href = Utils.get_upload_path(v);
                    picture_list.Add(href);
                }
            }
            goodinfo.pictures_format = picture_list;
            if (goodsinfo.Postage == 0) goodinfo.postage = "0.0";
            return goodinfo;
        }
        public async Task<CmfShopGoodsClass> getGoodsClassInfo(int classid)
        {
            var info = await context.CmfShopGoodsClasses.Where(x => x.GcId == classid).FirstOrDefaultAsync();
            info = info ?? new CmfShopGoodsClass();
            return info;
        }
        public async Task<List<CmfUserGoodsVisit>> getGoodsVisitRecord1(ulong uid, int p)
        {
            if (p < 1) p = 1;
            var nums = 20;
            var start = (p - 1) * nums;

            var list = await context.CmfUserGoodsVisits.Where(x => x.Uid == (long)uid).Skip(start).Take(nums).OrderByDescending(x => x.Addtime).ToListAsync();
            return list;
        }

        #endregion
        #region getHome
        public async Task<GetHomeModel> getHome(ulong uid)
        {
            var wait_payment = await context.CmfShopOrders.Where(x => x.Isdel == 0 && x.Uid == (long)uid && x.Status == 0).CountAsync();
            var wait_shipment = await context.CmfShopOrders.Where(x => x.Isdel == 0 && x.Uid == (long)uid && x.Status == 1).CountAsync();
            var wait_receive = await context.CmfShopOrders.Where(x => x.Isdel == 0 && x.Uid == (long)uid && x.Status == 2).CountAsync();
            var wait_evaluate = await context.CmfShopOrders.Where(x => x.Isdel == 0 && x.Uid == (long)uid && x.Status == 3).CountAsync();
            var refund = await context.CmfShopOrders.Where(x => x.Isdel == 0 && x.Uid == (long)uid && x.Status == 5 && x.RefundEndtime == 0).CountAsync();
            GetHomeModel rs = new GetHomeModel();
            rs.wait_payment = wait_payment;
            rs.wait_shipment = wait_shipment;
            rs.wait_receive = wait_receive;
            rs.wait_evaluate = wait_evaluate;
            rs.refund = refund;
            return rs;
        }
        public async Task<getShopApplyInfoModel> getShopApplyInfo(ulong uid)
        {
            var res = new getShopApplyInfoModel();
            var infos = await context.CmfShopApplies.Where(x => x.Uid == uid).FirstOrDefaultAsync();

            if (infos == null)
            {
                res.apply_status = -1;
                return res;
            }
            applyInfoModel info = new applyInfoModel();

            info.certificate_format = Utils.get_upload_path(infos.Certificate);
            info.other_format = Utils.get_upload_path(infos.Other);
            info.status = infos.Status;
            var goods_classid = await context.CmfSellerGoodsClasses.Where(x => x.Uid == (long)uid && x.Status == true).Select(x => x.GoodsClassid).ToListAsync();
            info.goods_classid = goods_classid;

            var status = info.status;
            if (status == 0)
            {
                res.apply_status = 0;
            }
            else if (status == 1)
            {
                res.apply_status = 1;
                res.apply_info = info;
            }
            else if (status == 2)
            {
                res.apply_status = 2;
                res.apply_info = info;
            }
            return res;
        }
        #endregion
    }
}
