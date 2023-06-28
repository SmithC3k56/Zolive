using zolive_api.Models;
using zolive_api.Models.Login;

namespace zolive_api.Services.Interface
{
    public interface ILoginService
    {
        Task<int> userFindPass(string user_login, string user_pass);
        Task<baninfoModel> getUserban(string user_login);
        Task<int> userReg(string user_login, string user_pass, string source);
        Task<UserLogin> userLogin(string lan, string user_login, string user_pass);
        Task<bool> isAuth(ulong uid);
    }
}
