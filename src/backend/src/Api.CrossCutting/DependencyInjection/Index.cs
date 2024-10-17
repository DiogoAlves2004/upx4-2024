using Infra.UPX4.Data.Repository;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Security;
using Microsoft.Extensions.DependencyInjection;


namespace Infra.UPX4.Ioc.DependencyInjection
{
    public class InjectAllDependencies
    {
        public static void Configure(IServiceCollection serviceCollection, TokenConfiguration? tokenConfiguration)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            DataBaseDependencies.Inject(serviceCollection);
            UsersDependencies.Inject(serviceCollection);
            AuthorizationDependencies.Inject(serviceCollection, tokenConfiguration);
            AutoMapperDependencies.Inject(serviceCollection);
        }

    }
}