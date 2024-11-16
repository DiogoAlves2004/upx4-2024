using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.UPX4.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // String de conexão para PostgreSQL
            var connectionString = "Host=localhost;Port=5432;Database=upx4;Username=postgres;Password=postgres";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            // Configurar o provedor do PostgreSQL
            optionsBuilder.UseNpgsql(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
    }
}
