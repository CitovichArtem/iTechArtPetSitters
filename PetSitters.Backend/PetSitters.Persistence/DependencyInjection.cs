using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PetSitters.Application.Interfaces;


namespace PetSitters.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence (this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ServicesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IServicesDbContext>(provider =>
                provider.GetService<ServicesDbContext>());
            return services;
        }
    }
}
