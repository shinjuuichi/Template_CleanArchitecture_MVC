using DataAccessLayer.Data;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Models.EntityAbstractions;
using Microsoft.Extensions.Caching.Distributed;

namespace DataAccessLayer.Implements.Base
{
    public class UnitOfWork(ApplicationDbContext dbContext,
        IDistributedCache cache,
        IUserRepository userRepository)
            : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        private readonly IDistributedCache _cache = cache;
        private readonly Dictionary<Type, dynamic> _repositories = [];

        public IUserRepository UserRepository => userRepository;

        public IGenericRepository<T> Repository<T>(bool isCached = false) where T : Entity
        {
            var entityType = typeof(T);
            if (_repositories.TryGetValue(entityType, out dynamic? repository))
            {
                return repository;
            }

            var newRepository = isCached
                ? Activator.CreateInstance(typeof(CachedRepository<>).MakeGenericType(typeof(T)), _dbContext, _cache)
                : Activator.CreateInstance(typeof(GenericRepository<>).MakeGenericType(typeof(T)), _dbContext);

            if (newRepository == null)
                throw new NullReferenceException("Repository should not be null");

            _repositories.Add(entityType, newRepository);

            return (IGenericRepository<T>)newRepository;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
