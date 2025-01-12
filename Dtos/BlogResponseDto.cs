using System.ComponentModel.DataAnnotations;
using BlogSystemAPI.Models;

namespace BlogSystemAPI.Dtos
{
    public class BlogResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}