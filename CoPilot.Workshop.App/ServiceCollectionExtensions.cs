
using Microsoft.Extensions.DependencyInjection;

namespace CoPilot.Workshop.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            return services;
        }
    }
}

