using Infra.UPX4.Data.Repository;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Interfaces.Services;
using Infra.UPX4.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.UPX4.Ioc.DependencyInjection
{
    public class UsersDependencies
    {
        public static void Inject(IServiceCollection serviceCollection)
        {
            // addSingleton - same
            // addScope - new
            // transient - new
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IUserService, UserService>();

        }

    }
}