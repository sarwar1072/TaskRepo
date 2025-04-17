using BlazorApp.Models;

namespace BlazorApp.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginVM model);
        Task<string> Register(RegisterVM model);
        Task Logout();
    }
}
