using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Dtos
{
    public class CommentRequestDto
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid BlogId { get; set; }
        [Required]
        [MinLength(3)]
        public string Content { get; set; } = string.Empty;
    }
}