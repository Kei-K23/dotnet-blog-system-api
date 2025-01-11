using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Models
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
    }
}