using BusinessLogicLayer.Commons;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace BusinessLogicLayer.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, AppConfiguration configuration)
        {
            if (configuration.DatabaseConfig.IsMemoryDB)
            {
                services.AddDbContext<ApplicationDbContext>(option => option.UseInMemoryDatabase("test"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.DatabaseConfig.ConnectionString));


            }
            return services;
        }

        public static IServiceCollection AddSqlServerCacheDatabase(this IServiceCollection services, AppConfiguration configuration)
        {
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = configuration.SqlServerCacheConfig.ConnectionString;
                options.SchemaName = "dbo";
                options.TableName = configuration.SqlServerCacheConfig.InstanceName;
            });

            return services;
        }
    }
}
