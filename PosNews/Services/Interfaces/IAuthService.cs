using PosNews.Models;

namespace PosNews.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(LoginUser user);
        Task<bool> RegisterUser(LoginUser user);
    }
}