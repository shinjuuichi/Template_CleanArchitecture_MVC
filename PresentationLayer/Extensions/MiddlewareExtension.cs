
using PresentationLayer.Middlewares;

namespace PresentationLayer.Extensions
{
    public static class MiddlewareExtension
    {
        public static IServiceCollection AddMiddlewareServices(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlingMiddleware>();
            return services;
        }

        public static WebApplication UseMiddlewareServices(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Not found page
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?statusCode={0}");
            return app;
        }
    }
}
