namespace Infra.UPX4.Domain.Entities
{
    public class PontoDeAcessibilidadeEntity : BaseEntity
    {
        public required string descricaopontodeacessibilidade { get; set; }

        public required double cordx { get; set; }

        public required double cordy { get; set; }

        public required string idusuariocriador { get; set; }

        public required string idicone { get; set; }
    }
}