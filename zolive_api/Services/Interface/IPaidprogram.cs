using zolive_api.Models.Paidprogram;

namespace zolive_api.Services.Interface
{
    public interface IPaidprogram
    {
        Task<List<PaidProgramModel>> getPaidProgramList(string lan, ulong uid, int p);
        Task<int> getApplyStatus(ulong uid);
        Task<int> apply(ulong uid);
    }
}
