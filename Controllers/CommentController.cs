using AutoMapper;
using BlogSystemAPI.Dtos;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController(ICommentService commentService, IMapper mapper) : ControllerBase
    {
        private readonly ICommentService _commentService = commentService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("{id}")]
        public async Task<ActionResult> GetComment(Guid id)
        {
            var comment = await _commentService.GetByIdAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBlogs()
        {
            var blogs = await _commentService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(CommentRequestDto commentRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = _mapper.Map<Comment>(commentRequestDto);
            await _commentService.AddAsync(comment);

            return CreatedAtAction(nameof(CreateComment), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(Guid id, CommentRequestDto commentRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingComment = await _commentService.GetByIdAsync(id);
            if (existingComment == null) return NotFound();

            // Map updated values to the existing entity
            _mapper.Map(commentRequestDto, existingComment);
            existingComment.UpdatedAt = DateTime.UtcNow;

            await _commentService.UpdateAsync(existingComment);

            return CreatedAtAction(nameof(UpdateComment), new { id = existingComment.Id }, existingComment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUpdateComment(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isBlogExist = await _commentService.GetByIdAsync(id);
            if (isBlogExist == null) return NotFound();

            await _commentService.DeleteAsync(id);

            return NoContent();
        }
    }
}