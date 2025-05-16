using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces.Services
{
    public interface IAuthService
    {
        Task<User> LoginAsync(User loginUser);
        Task RegisterAsync(User user);
    }
}
