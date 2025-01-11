using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Dtos
{
    public class RequestBlogDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }
    }
}