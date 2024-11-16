using Infra.UPX4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.UPX4.Data.Mapping
{
    public class PontoDeAcessibilidadeEntityMap : IEntityTypeConfiguration<PontoDeAcessibilidadeEntity>
    {
        public void Configure(EntityTypeBuilder<PontoDeAcessibilidadeEntity> builder)
        {

            builder.ToTable("pontodeacessibilidade");
            builder.HasKey(p => p.Id);

            builder.Property(u => u.descricaopontodeacessibilidade).IsRequired().HasMaxLength(150);
            builder.Property(u => u.idusuariocriador).IsRequired();


        }

    }
}