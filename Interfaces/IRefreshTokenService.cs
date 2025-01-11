using BlogSystemAPI.Models;

namespace BlogSystemAPI.Interfaces
{
    public interface IRefreshTokenService : IGeneralOperations<RefreshToken>
    {
        Task<bool> ValidateRefreshToken(string userId, string refreshToken);
    }
}