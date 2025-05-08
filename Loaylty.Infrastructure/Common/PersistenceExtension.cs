using Loaylty.Infrastructure.Entities.Users;
using Loyalty.Application.Users.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Loaylty.Infrastructure.Persistence.Common
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LoayltyContext>()
                ;

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

    }
}
