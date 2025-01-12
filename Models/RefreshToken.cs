using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Models
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}