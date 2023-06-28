using zolive_api.Models.Livemanage;

namespace zolive_api.Services.Interface
{
    public interface ILivemanage
    {
        Task<List<GetRoomListModel>> getRoomList(string lan, ulong uid);
        Task<List<GetRoomListModel>> getShutList(string lan,ulong liveuid);
        Task<List<GetRoomListModel>> getKickList(string lan, ulong liveuid);
    }
}
