
using CoPilot.Workshop.App.Products;
using CoPilot.Workshop.App.Products.Create;
using Microsoft.Extensions.DependencyInjection;

namespace CoPilot.Workshop.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            services.AddScoped<CreateProductHandler>();
            return services;
        }
    }
}

