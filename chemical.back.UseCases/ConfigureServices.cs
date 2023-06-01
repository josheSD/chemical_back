using chemical.back.Interface.UseCases;
using chemical.back.Validator;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace chemical.back.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IUserApplication, UserApplication>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<UserCreateDtoValidator>();
            services.AddTransient<UserUpdateDtoValidator>();
            services.AddTransient<UserRemoveDtoValidator>();

            return services;
        }
    }
}
