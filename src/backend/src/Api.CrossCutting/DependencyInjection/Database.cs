using Infra.UPX4.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.UPX4.Ioc.DependencyInjection
{
    public class DataBaseDependencies
    {
        public static void Inject(IServiceCollection serviceCollection)
        {
            string dbPath = @"..\Api.Data\mydatabase.db";
            serviceCollection.AddDbContext<MyContext>(options => options.UseSqlite($"Data Source={dbPath}"));
        }

    }
}