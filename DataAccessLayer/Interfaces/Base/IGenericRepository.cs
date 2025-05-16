using DataAccessLayer.Models.EntityAbstractions;
using System.Linq.Expressions;


namespace DataAccessLayer.Interfaces.Base
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string[]? includes = null);
        Task<List<T>> GetAllWithDeletedAsync(string[]? includes = null);
        Task<T?> GetByIdAsync(int id, string[]? includes = null);

        Task<bool> IsExistById(int id);

        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);

        void Remove(T entity);

        T Update(T entity);
        void UpdateRange(List<T> entities);
    }
}
