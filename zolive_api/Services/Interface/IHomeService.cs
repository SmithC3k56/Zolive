using zolive_api.Models.Dynamic;
using zolive_api.Models.Home;
using zolive_api.Models.User;

namespace zolive_api.Services.Interface
{
    public interface IHomeService
    {
        Task<List<SearchModel>> search(ulong uid, string key, int p);
        Task<GetHotModel> handleLive(string? lan, GetHotModel hot);
        Task<IList<getSlideModel>>getSlide();
        Task<List<GetHotModel>> getHot(string? lan, int p);
        Task<List<GetHotModel>> getClassLive(string? lan, ulong liveclassid, int p);
        Task<UserInfo> getUserInfo(string? lan, ulong uid, int type = 0);
        Task<IList<ProfitModel>> profitList(string lan, bool is_resh, ulong uid, string type, int p);
        Task<IList<ProfitModel>> consumeList(string lan, bool is_resh, ulong uid, string type, int p);
        // Task<string> PrivateKeyA(string host, string stream, int type);
    }
}
