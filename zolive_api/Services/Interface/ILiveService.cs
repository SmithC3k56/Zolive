using zolive_api.Models.Live;
using zolive_db.Models;

namespace zolive_api.Services.Interface
{
    public interface ILiveService
    {
        Task<bool> CheckLivePK(string stream);
        Task<SendBarrageModel> sendBarrage(ulong uid, ulong liveuid, string stream, ulong giftid, int giftcount, string content);
        Task getUserList(string lan, ulong liveuid, string stream, int p = 1);
        Task<int> checkLiveing(ulong uid, string stream);
        Task<CmfJackpot> getJackpotInfo();
        Task<string?> getJackpotSet();
        Task<int> getGuardNums(ulong liveuid);
        Task<ulong> getVotes(ulong liveuid);
        Task<int> stopRoom(ulong uid, string stream);
        Task<int> createRoom(ulong uid, CmfLive data);
        Task<bool> isAuth(ulong uid);
        Task<int> checkBan(ulong uid);
        Task<int> setReport(ulong uid, ulong touid,string content);
        Task<GetAdminListModel> getAdminList(string lan, ulong liveuid);
        Task<CmfAgentCode?> getCode(ulong uid);
        Task<checkLiveResult?> checkLive(string? lan, ulong uid, ulong liveuid, string stream);
        Task<List<CmfReportClassify>> getReportClass();
    }
}
