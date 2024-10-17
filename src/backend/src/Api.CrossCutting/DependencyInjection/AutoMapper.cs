using Infra.UPX4.Ioc.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.UPX4.Ioc.DependencyInjection
{
    public class AutoMapperDependencies
    {

        public static void Inject(IServiceCollection serviceCollection)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            serviceCollection.AddSingleton(config.CreateMapper());
        }

    }
}