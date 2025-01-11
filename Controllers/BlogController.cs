using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController(IBlogService blogService) : ControllerBase
    {
        private readonly IBlogService _blogService = blogService;

        [HttpGet]
        public async Task<ActionResult> GetBlog(Guid id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlog(Blog entity)
        {
            await _blogService.AddAsync(entity);
            return CreatedAtAction(nameof(GetBlog), new { id = entity.Id }, entity);
        }
    }
}