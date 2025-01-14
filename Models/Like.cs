using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Models
{
    public class Like
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public Guid BlogId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual User User { get; set; } = null!;
    }
}