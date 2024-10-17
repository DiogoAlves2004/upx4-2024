using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Infra.UPX4.Domain.Dto
{
    public class LoginDto
    {
        [Required]
        [DefaultValue("adm123")]
        public required string Password { get; set; }

        [Required]
        [EmailAddress]
        [DefaultValue("adm@mail.com")]
        public required string Email { get; set; }
    }
}