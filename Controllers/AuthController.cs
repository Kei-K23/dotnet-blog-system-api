using System.Security.Claims;
using AutoMapper;
using BlogSystemAPI.Dtos;
using BlogSystemAPI.Helper;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IRefreshTokenService refreshTokenService, IUserService userService, JwtHelper jwtHelper, IMapper mapper) : ControllerBase
    {
        private readonly IRefreshTokenService _refreshTokenService = refreshTokenService;
        private readonly IUserService _userService = userService;
        private readonly JwtHelper _jwtHelper = jwtHelper;
        private readonly IMapper _mapper = mapper;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerRequestDto.Password);

            var newUser = _mapper.Map<User>(registerRequestDto);
            newUser.PasswordHash = hashedPassword;

            await _userService.AddAsync(newUser);

            return CreatedAtAction(nameof(Register), new { id = newUser.Id }, new
            {
                newUser.Id,
                newUser.Username,
                newUser.DisplayName,
                newUser.CreatedAt,
                newUser.UpdatedAt,
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserByUsername(loginRequestDto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequestDto.Password, user.PasswordHash))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Username),
            };

            var token = _jwtHelper.GenerateToken(claims, DateTime.UtcNow.AddMinutes(15));

            var newRefreshTokenKey = Guid.NewGuid().ToString();
            // Check Refresh Token Already Created for this user
            var existingRT = await _refreshTokenService.GetByUserIdAsync(user.Id);
            if (existingRT != null)
            {
                existingRT.Token = newRefreshTokenKey;
                existingRT.ExpiryDate = DateTime.UtcNow.AddDays(7);
                await _refreshTokenService.UpdateAsync(existingRT);
            }
            else
            {
                var newRefreshToken = new RefreshToken
                {
                    UserId = user.Id,
                    Token = newRefreshTokenKey,
                    ExpiryDate = DateTime.UtcNow.AddDays(7),
                };

                await _refreshTokenService.AddAsync(newRefreshToken);
            }

            return Ok(new
            {
                Token = token,
                RefreshToken = newRefreshTokenKey
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequestDto refreshTokenRequestDto)
        {
            if (await _refreshTokenService.ValidateRefreshToken(refreshTokenRequestDto.UserId, refreshTokenRequestDto.Token))
            {
                var user = await _userService.GetByIdAsync(refreshTokenRequestDto.UserId);
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, user.Username),
                };

                var token = _jwtHelper.GenerateToken(claims, DateTime.UtcNow.AddMinutes(15));

                var newRefreshTokenKey = Guid.NewGuid().ToString();

                var existingRT = await _refreshTokenService.GetByUserIdAsync(user.Id);
                existingRT.Token = newRefreshTokenKey;
                existingRT.ExpiryDate = DateTime.UtcNow.AddDays(7);
                await _refreshTokenService.UpdateAsync(existingRT);

                return Ok(new
                {
                    Token = token,
                    RefreshToken = newRefreshTokenKey
                });
            }

            return Unauthorized();
        }
    }
}