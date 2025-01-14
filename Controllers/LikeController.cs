using BlogSystemAPI.Dtos;
using BlogSystemAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController(ILikeService likeService) : ControllerBase
    {
        private readonly ILikeService _likeService = likeService;

        [HttpGet("users/{userId}")]
        public IActionResult GetAllLikesByUserId(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var likes = _likeService.GetAllLikesByUserId(userId);

            return Ok(likes);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleLike(LikeRequestDto likeRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _likeService.ToggleLike(likeRequestDto.UserId, likeRequestDto.BlogId);

            return NoContent();
        }
    }
}