using DataAccessLayer.Data;
using DataAccessLayer.Implements.Base;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implements.Repositories
{
    public class UserRepository(ApplicationDbContext _dbContext) : GenericRepository<User>(_dbContext), IUserRepository
    {
        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await _dbContext.User.AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
