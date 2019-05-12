using Instagram.Business.Interfaces;
using Instagram.Business.Services;
using Instagram.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Instagram.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.ConfigureRepositoryServices();

            services.AddScoped<IUserService, UserService>();
        }
    }
}
