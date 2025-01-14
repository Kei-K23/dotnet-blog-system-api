using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Dtos
{
    public class LikeRequestDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid BlogId { get; set; }
    }
}