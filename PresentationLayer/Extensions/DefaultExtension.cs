using PresentationLayer.Filters;

namespace PresentationLayer.Extensions
{
    public static class DefaultExtension
    {
        public static IServiceCollection AddDefaultAPIServices(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });


            return services;
        }

        public static WebApplication UseDefaultAPIServices(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseHttpsRedirection();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
