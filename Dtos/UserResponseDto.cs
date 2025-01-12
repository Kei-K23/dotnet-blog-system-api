using System.ComponentModel.DataAnnotations;
using BlogSystemAPI.Models;

namespace BlogSystemAPI.Dtos
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<BlogResponseDto> Blogs { get; set; } = [];
    }
}