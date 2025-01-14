using AutoMapper;
using BlogSystemAPI.Dtos;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystemAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController(IUserService userService, IMapper mapper) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user != null) return NotFound();
            return Ok(user);
        }

        [HttpGet("{id}/blogs")]
        public async Task<IActionResult> GetBlogsByUserId(Guid id)
        {
            var users = await _userService.GetBlogsByUserId(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userRequestDto.Password);

            var newUser = _mapper.Map<User>(userRequestDto);
            newUser.PasswordHash = hashedPassword;

            await _userService.AddAsync(newUser);

            return CreatedAtAction(nameof(CreateUser), new { id = newUser.Id }, new
            {
                newUser.Id,
                newUser.Username,
                newUser.DisplayName,
                newUser.CreatedAt,
                newUser.UpdatedAt,
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existUser = await _userService.GetByIdAsync(id);
            if (existUser == null) return NotFound();

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userRequestDto.Password);

            _mapper.Map(userRequestDto, existUser);

            existUser.PasswordHash = hashedPassword;
            existUser.UpdatedAt = DateTime.UtcNow;

            await _userService.UpdateAsync(existUser);

            return CreatedAtAction(nameof(UpdateUser), new { id = existUser.Id }, new
            {
                existUser.Id,
                existUser.Username,
                existUser.DisplayName,
                existUser.CreatedAt,
                existUser.UpdatedAt,
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUserExist = await _userService.GetByIdAsync(id);
            if (isUserExist == null) return NotFound();

            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}