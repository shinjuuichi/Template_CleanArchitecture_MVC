using BusinessLogicLayer.Commons;
using PresentationLayer.Extensions;

namespace PresentationLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIServices(this IServiceCollection services, AppConfiguration configuration)
        {
            services.AddDefaultAPIServices();
            services.AddMiddlewareServices();
            services.AddSecurityServices(configuration);
            services.AddWebAPIServiceScoped();
            services.AddSignalRServices();
            return services;
        }

        public static WebApplication UseWebAPIServices(this WebApplication app)
        {
            app.UseDefaultAPIServices();
            app.UseMiddlewareServices();
            app.UseSecurityServices();
            app.UseSignalRServices();
            return app;
        }
    }
}
