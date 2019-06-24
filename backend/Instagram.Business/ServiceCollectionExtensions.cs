using Instagram.Business.Interfaces;
using Instagram.Business.Mappers;
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

            services.AddSingleton(AutomapperConfiguration.Configure().CreateMapper());
        }
    }
}
