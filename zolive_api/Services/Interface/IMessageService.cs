using zolive_api.Models.MsgModel;

namespace zolive_api.Services.Interface
{
    public interface IMessageService
    {
        Task<List<MsgModel>> getList(ulong uid, int p);
    }
}
