using zolive_api.Models.User;
using zolive_db.Home;
using zolive_db.Models;

namespace zolive_api.Services.Interface
{
    public interface ICommonService
    {
        Task<bool> checkIsDestroyByUid(ulong uid);
        Task<dynamic> getConfigPub();
        Task<dynamic> getConfigPri();
        Task updateToken(ulong uid, string token);
        Task<uint> getLevelAnchor(ulong experience);
        Task<IList<CmfLevelAnchor>> getLevelAnchorList();
        Task<uint> getLevel(ulong experience);
        Task<IList<CmfLevel>> getLevelList();
        Task<IList<Videoclass>> getVideoClass(string lan);
        Task<IList<CmfLiveClass>> getLiveClass(string lan);
        Task<IList<Levelanchor>> getLevelAnchorList1();
        Task<IList<Level>> getLevelList1();
        Task<Guide> getGuide();
        Task<string> PrivateKeyA(string host, string stream, int type);
        Task<int> checkPaidProgramIsPass(ulong uid);
        Task<int> checkShopIsPass(ulong uid);
        Task<BaseInfo> getInfo(ulong uid);
        Task<int> getFans(ulong uid);
        Task<Liang> getUserLiang(ulong uid);
        Task<Vip> getUserVip(ulong uid);
        Task<int> getLives(ulong uid);
        Task<int> getFollows(ulong uid);
        Task<string> isBlack(ulong uid, ulong touid);
        Task<sbyte> ifStep(ulong uid, ulong videoid);
        Task<sbyte> ifLike(ulong uid, ulong videoid);
        Task<sbyte> isAttention(ulong uid, ulong touid);
    }
}
