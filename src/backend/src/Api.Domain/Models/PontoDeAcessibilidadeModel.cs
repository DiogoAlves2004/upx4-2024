namespace Infra.UPX4.Domain.Models
{
    public class PontoDeAcessibilidadeModel
    {
        public Guid Id { get; set; }

        public string? descricaopontodeacessibilidade { get; set; }

        public double cordx { get; set; }

        public double cordy { get; set; }

        public Guid idusuariocriador { get; set; }

        public string icone { get; set; }
    }
}
