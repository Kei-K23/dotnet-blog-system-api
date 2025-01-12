using BlogSystemAPI.Models;

namespace BlogSystemAPI.Interfaces
{
    public interface IRefreshTokenService : IGeneralOperations<RefreshToken>
    {
        Task<bool> ValidateRefreshToken(Guid userId, string refreshToken);
        Task<RefreshToken> GetByUserIdAsync(Guid userId);
    }
}