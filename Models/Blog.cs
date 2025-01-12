using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystemAPI.Models
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5)]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}