using zolive_api.Models.Buyer;
using zolive_api.Models.Paidprogram;
using zolive_api.Models.User;
using zolive_api.Models.Video;
using zolive_db.Models;

namespace zolive_api.Services.Interface
{
    public interface IUserService
    {
         Task<GetCdnRecordModel?> getCdnRecord(ulong id);
        Task<IList<HandleGoodsListModel>> getGoodsList(ulong uid, int status,int p);
        Task<InfoBonus> LoginBonus(ulong uid);
        Task<IList<UserInfo>> getFollowsList(string lan, ulong uid, ulong touid, int p);
        Task<IList<UserInfo>> getFansList(string lan, ulong uid, ulong touid, int p);
        Task<int> setUserLabel(ulong uid, ulong touid, string labels);
        Task<CmfLabelUser?> getUserLabel(ulong uid, ulong touid);
        Task<int> setBlack(ulong uid, ulong touid);
        Task<int> setAttent(ulong uid, ulong touid);
        Task<int> updatePass(ulong uid, string oldPass, string newPass);
        Task<IList<GetPerSettingModel>> getPerSetting();
        Task<IList<getChargeRulesModel>> getChargeRules();
        Task<getBalanceModel> getBalance(ulong uid);
        Task<bool> checkName(ulong uid, string name);
        Task<int> sensitiveField(string field);
        Task<bool> userUpdate(ulong uid, string fields);
        Task<IList<LiveRecordModel>> getLiverecord(ulong touid, int p);
        Task<int> countGoods(ulong uid, int status);
        Task<getShopModel?> getShop(string lan, ulong uid);
        Task<IList<VideoModel>> getHomeVideo(string lan, ulong uid, ulong touid, int p);
        Task<IList<CmfLabel>> getImpressionLabel(string lan);
        Task<IList<LabelInfoModel>> getMyLabel(string lan, ulong uid);
        Task<int> getLoginBonus(ulong uid);
        Task<ulong[]> getVideoBlack(ulong uid);
        Task<UserInfo> getUserHome(string lan, ulong uid, ulong touid);
        Task<UserInfo2> getUserInfo2(string? lan, ulong uid, int type = 0);
        Task<IList<UserInfo2>> getGuardList(string lan, ulong touid);
        Task<int> getWeekContribute(ulong uid, long starttime = 0, long endtime = 0);
        Task<GetAuthInfoClass> getAuthInfo(ulong uid);
        Task<IList<CmfCashAccount>> getUserAccountList(ulong uid);
        Task<int> setShopCash(ulong uid, int accountId, ulong money);
        Task<getProfitModel> getProfit(string lan, ulong uid);
    }
}
