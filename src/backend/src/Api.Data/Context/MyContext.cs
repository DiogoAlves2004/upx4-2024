
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserEntityMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity{
                    Id = Guid.NewGuid(),
                    Password = "adm123",
                    Name = "Adm",
                    Email = "adm@mail.com",
                    CreateAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }

    }
}