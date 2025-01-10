using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Models
{
    public class Blog
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}