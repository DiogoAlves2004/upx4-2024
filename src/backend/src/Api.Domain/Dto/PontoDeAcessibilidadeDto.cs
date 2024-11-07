using System.ComponentModel.DataAnnotations;

namespace Infra.UPX4.Domain.Dto
{
    public class PontoDeAcessibilidadeDto
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string descricaopontodeacessibilidade { get; set; }

        [Required]
        public string cordx { get; set; }

        [Required]
        public string cordy { get; set; }

        [Required]
        public Guid idusuariocriador { get; set; }

        [Required]
        public Guid idicone { get; set; }

    }
}
