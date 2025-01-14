using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Models
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid BlogId { get; set; }

        [Required]
        [MinLength(3)]
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Blog Blog { get; set; } = null!;
    }
}