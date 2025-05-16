
namespace PresentationLayer.Extensions
{
    public static class ServiceScopeExtension
    {
        public static IServiceCollection AddWebAPIServiceScoped(this IServiceCollection services)
        {
            //services.AddScoped<ICurrentUserService, CurrentUserService>();
            //services.AddHostedService<SendAdminMailBackgroundService>();
            return services;
        }
    }
}
