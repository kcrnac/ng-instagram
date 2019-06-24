using Instagram.Data;
using Instagram.Repository.Implementations;
using Instagram.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Instagram.Repository
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<ApplicationDbContext>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
