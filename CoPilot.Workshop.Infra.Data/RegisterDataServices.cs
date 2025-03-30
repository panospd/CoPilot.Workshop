// CoPilot.Workshop.Infra.Data/ServiceCollectionExtensions.cs
using CoPilot.Workshop.Domain;
using CoPilot.Workshop.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoPilot.Workshop.Infra.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();

            // Register other services here

            return services;
        }
    }
}
