using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Models
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}