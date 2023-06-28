using zolive_api.Models;
using zolive_db.Models;

namespace zolive_api.Services.Interface
{
    public interface IRedService
    {
        Task<ResultBaseInfo> sendRed(string lan, CmfRed data);
        int[] redlist(ulong total, uint nums, int type);
    }
}
