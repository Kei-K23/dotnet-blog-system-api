using System.ComponentModel.DataAnnotations;

namespace BlogSystemAPI.Dtos
{
    public class CreateBlogDto
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }
    }
}