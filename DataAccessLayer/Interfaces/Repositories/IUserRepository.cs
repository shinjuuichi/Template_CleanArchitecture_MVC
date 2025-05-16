using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsEmailExistAsync(string email);
        Task<User?> GetByEmailAsync(string email);
    }
}
