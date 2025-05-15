
using CoPilot.Workshop.App.Products;
using CoPilot.Workshop.App.Products.GetAll;
using Microsoft.Extensions.DependencyInjection;
using static CoPilot.Workshop.App.Products.Create.CreateProductCommand;

namespace CoPilot.Workshop.App
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<CreateProductHandler>();
            services.AddScoped<GetAllProductsHandler>();
            return services;
        }
    }
}

