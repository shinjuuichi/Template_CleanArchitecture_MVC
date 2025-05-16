using BusinessLogicLayer.Commons;
using BusinessLogicLayer.Implements.Services;
using BusinessLogicLayer.Interfaces.Services;
using DataAccessLayer.Commons;
using DataAccessLayer.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.Extensions
{
    public static class ServiceScopeExtension
    {
        public static IServiceCollection AddServiceScoped(this IServiceCollection services)
        {
            //services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
