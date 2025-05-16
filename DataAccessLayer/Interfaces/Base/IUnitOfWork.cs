using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.EntityAbstractions;

namespace DataAccessLayer.Interfaces.Base
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IGenericRepository<T> Repository<T>(bool isCached = false) where T : Entity;
        Task<int> SaveChangeAsync();
    }
}
