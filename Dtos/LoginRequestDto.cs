using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(18)]
        public string Password { get; set; }
    }
}