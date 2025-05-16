using BusinessLogicLayer.Commons;
using BusinessLogicLayer.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, AppConfiguration configuration)
        {
            services.AddServiceScoped();
            services.AddApplicationDbContext(configuration);
            services.AddSqlServerCacheDatabase(configuration);
            services.AddRepositoryScoped();

            return services;
        }
    }
}
