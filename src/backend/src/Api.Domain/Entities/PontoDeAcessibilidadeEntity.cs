using System.ComponentModel.DataAnnotations;

namespace Infra.UPX4.Domain.Entities
{
    public class PontoDeAcessibilidadeEntity : BaseEntity
    {
        public required string descricaopontodeacessibilidade { get; set; }

        public required string cordx { get; set; }

        public required string cordy { get; set; }

        public required string idusuariocriador { get; set; }

        public required string idicone { get; set; }
    }
}