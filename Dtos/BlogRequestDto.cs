using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Dtos
{
    public class BlogRequestDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}