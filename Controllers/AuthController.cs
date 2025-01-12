using BlogSystemAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IRefreshTokenService refreshTokenService) : ControllerBase
    {
        private readonly IRefreshTokenService _refreshTokenService = refreshTokenService;
    }
}