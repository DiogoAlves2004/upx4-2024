using Infra.UPX4.Data.Mapping;
using Infra.UPX4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Infra.UPX4.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PontoDeAcessibilidadeEntity> PontosDeAcessibilidade { get; set; }



        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserEntityMap().Configure);
   

         


            modelBuilder.Entity<PontoDeAcessibilidadeEntity>(new PontoDeAcessibilidadeEntityMap().Configure);
        



        }

    }
}