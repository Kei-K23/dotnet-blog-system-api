using AutoMapper;
using BlogSystemAPI.Dtos;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController(IBlogService blogService, IMapper mapper) : ControllerBase
    {
        private readonly IBlogService _blogService = blogService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBlog(Guid id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBlogs()
        {
            var blogs = await _blogService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBlog(BlogRequestDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blog = _mapper.Map<Blog>(blogDto);
            await _blogService.AddAsync(blog);

            return CreatedAtAction(nameof(CreateBlog), new { id = blog.Id }, blog);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlog(Guid id, BlogRequestDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBlog = await _blogService.GetByIdAsync(id);
            if (existingBlog == null) return NotFound();


            _mapper.Map(blogDto, existingBlog);
            existingBlog.UpdatedAt = DateTime.UtcNow;

            await _blogService.UpdateAsync(existingBlog);

            return CreatedAtAction(nameof(UpdateBlog), new { id = existingBlog.Id }, existingBlog);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBlog(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isBlogExist = await _blogService.GetByIdAsync(id);
            if (isBlogExist == null) return NotFound();

            await _blogService.DeleteAsync(id);

            return NoContent();
        }
    }
}