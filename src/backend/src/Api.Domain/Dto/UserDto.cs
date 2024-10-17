using System.ComponentModel.DataAnnotations;

namespace Infra.UPX4.Domain.Dto
{
    public class UserDto
    {

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }

    }
}