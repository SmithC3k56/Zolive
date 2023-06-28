using zolive_api.Models.Buyer;
using zolive_api.Models.User;
using zolive_db.Models;

namespace zolive_api.Services.Interface
{
    public interface IBuyerService
    {
        Task<BalanceModel> getUserShopBalance(ulong uid);
        Task<List<AddressListModel>> addressList(ulong uid);
        Task<CmfShopGoodsClass> getGoodsClassInfo(int classid);
        Task<handleGoodsModel> handleGoods(string lan, CmfShopGood goodsinfo);
        Task<ModelNewList> getGoodsVisitRecord(string lan, ulong uid, int p);
        Task<List<CmfUserGoodsVisit>> getGoodsVisitRecord1(ulong uid, int p);
        Task<GetHomeModel> getHome(ulong uid);
        Task<getShopApplyInfoModel> getShopApplyInfo(ulong uid);
        Task<List<getRefundListModel>> getRefundList(string lan, ulong uid, int p);
        //
        Task<int> setUserBalance(ulong uid, int type, decimal balance);
        Task changeShopGoodsSaleNums(ulong goodsid, int type, int nums);
        Task changeShopSaleNums(ulong uid, int type, int nums);
        Task<CmfShopOrderRefund> getShopOrderRefundInfo(string lan, long id);
        Task goodsOrderAutoProcess(string lan, ulong uid);
        Task<short> changeShopGoodsSpecNum(ulong goodsid, long spec_id, long nums, long type);
        Task<List<GetGoodsOrderListModel>> getGoodsOrderList(string lan, ulong uid, string type, int p);
    }
}
