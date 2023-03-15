using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LuggageFinder.Application.Interfaces;

namespace LuggageFinder.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<LuggageFinderDbContext>(options => 
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ILuggageFinderDbContext>(provider => provider.GetService<LuggageFinderDbContext>());

            return services;
        }
    }
}
