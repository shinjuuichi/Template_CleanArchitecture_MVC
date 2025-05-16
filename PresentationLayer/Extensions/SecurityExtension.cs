using System.Text;
using BusinessLogicLayer.Commons;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;

namespace PresentationLayer
{
    public static class SecurityExtension
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, AppConfiguration configuration)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                      .AddCookie(options =>
                      {
                          options.LoginPath = "/Auth/Login";
                          options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                          options.SlidingExpiration = true;
                          options.Cookie.HttpOnly = true;
                          options.Cookie.IsEssential = true;
                      });

            return services;
        }

        public static WebApplication UseSecurityServices(this WebApplication app)
        {
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}
