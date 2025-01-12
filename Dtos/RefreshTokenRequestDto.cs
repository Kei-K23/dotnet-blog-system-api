using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Dtos
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }
        [Required]
        public string Token { get; set; }
    }
}