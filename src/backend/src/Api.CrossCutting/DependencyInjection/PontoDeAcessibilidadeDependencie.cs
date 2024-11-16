using Infra.UPX4.Data.Repository;
using Infra.UPX4.Domain.Interfaces.Repositories;
using Infra.UPX4.Domain.Interfaces.Services;
using Infra.UPX4.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.UPX4.Ioc.DependencyInjection
{
    public class PontoDeAcessibilidadeDependencie
    {

        public static void Inject(IServiceCollection serviceCollection)
        {
            // addSingleton - same
            // addScope - new
            // transient - new
            serviceCollection.AddTransient<IPontoDeAcessibilidadeRepository, PontoDeAcessibilidadeRepository>();
            serviceCollection.AddTransient<IPontoDeAcessibilidadeService, PontoDeAcessibilidadeService>();

        }

    }
}
