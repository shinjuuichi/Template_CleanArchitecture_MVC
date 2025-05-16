using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using DataAccessLayer.Data;
using DataAccessLayer.Models.EntityAbstractions;
using Microsoft.Extensions.Caching.Distributed;

namespace DataAccessLayer.Implements.Base
{
    public class CachedRepository<T>(ApplicationDbContext _dbContext, IDistributedCache _cache)
               : GenericRepository<T>(_dbContext) where T : Entity
    {
        private readonly string CacheKey = $"{typeof(T).Name}Cache";
        private readonly JsonSerializerOptions CachedJsonOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public override async Task<List<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            string[]? includes = null)
        {
            var entityCache = await _cache.GetStringAsync(CacheKey);
            if (entityCache != null)
            {
                return JsonSerializer.Deserialize<List<T>>(entityCache, CachedJsonOptions) ?? [];
            }

            var entities = await base.GetAllAsync(filter, includes);
            await _cache.SetStringAsync(CacheKey, JsonSerializer.Serialize(entities, CachedJsonOptions));
            return entities;
        }

        public override async Task<T> AddAsync(T entity)
        {
            this.DeleteCache();
            return await base.AddAsync(entity);
        }

        public override async Task AddRangeAsync(List<T> entities)
        {
            this.DeleteCache();
            await base.AddRangeAsync(entities);
        }

        public override void Remove(T entity)
        {
            this.DeleteCache();
            base.Remove(entity);
        }

        public override T Update(T entity)
        {
            this.DeleteCache();
            return base.Update(entity);
        }

        public override void UpdateRange(List<T> entities)
        {
            this.DeleteCache();
            base.UpdateRange(entities);
        }

        private void DeleteCache() => _cache.Remove(CacheKey);
    }
}
