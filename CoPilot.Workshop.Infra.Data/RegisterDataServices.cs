// CoPilot.Workshop.Infra.Data/RegisterDataServices.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoPilot.Workshop.Infra.Data
{
    public static class RegisterDataServicesExtensions
    {
        public static void RegisterDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}
