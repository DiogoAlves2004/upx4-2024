using Infra.UPX4.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infra.UPX4.Ioc.DependencyInjection
{
    public class DataBaseDependencies
    {
        public static void Inject(IServiceCollection serviceCollection)
        {
            // String de conexão para o PostgreSQL
            string connectionString = "Host=localhost;Port=5432;Database=upx4;Username=postgres;Password=postgres";

            // Registrar o contexto usando o provedor Npgsql para PostgreSQL
            serviceCollection.AddDbContext<MyContext>(options =>
                options.UseNpgsql(connectionString));
        }
    }
}
