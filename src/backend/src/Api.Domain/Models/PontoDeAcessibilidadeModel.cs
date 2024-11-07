using System.ComponentModel.DataAnnotations;

namespace Infra.UPX4.Domain.Models
{
    public class PontoDeAcessibilidadeModel
    {
        public Guid Id { get; set; }

        public string? descricaopontodeacessibilidade { get; set; }

        public string cordx { get; set; }

        public string cordy { get; set; }

        public Guid idusuariocriador { get; set; }

        public Guid idicone { get; set; }
    }
}
