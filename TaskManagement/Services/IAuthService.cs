using TaskManagement.Models;

namespace TaskManagement.Services
{
    public interface IAuthService
    {
        bool AuthenticateAsync(LoginUser loginUser);
    }
}
