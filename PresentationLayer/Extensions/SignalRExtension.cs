namespace PresentationLayer.Extensions
{
    public static class SignalRExtension
    {
        public static IServiceCollection AddSignalRServices(this IServiceCollection services)
        {
            return services;
        }

        public static WebApplication UseSignalRServices(this WebApplication app)
        {
            return app;
        }
    }
}
