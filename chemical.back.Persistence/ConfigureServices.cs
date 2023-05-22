using chemical.back.Common;
using chemical.back.Interface.Persistence;
using chemical.back.Persistence.Contexts;
using chemical.back.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace chemical.back.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
