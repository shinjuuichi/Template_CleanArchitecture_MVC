
using DataAccessLayer.Implements.Base;
using DataAccessLayer.Implements.Repositories;
using DataAccessLayer.Interfaces.Base;
using DataAccessLayer.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Extensions
{
    public static class RepositoryScopeExtension
    {
        public static IServiceCollection AddRepositoryScoped(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
