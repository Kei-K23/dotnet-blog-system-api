using BlogSystemAPI.Data;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Services
{
    public class RefreshTokenService(AppDbContext context) : GeneralOperations<RefreshToken>(context), IRefreshTokenService
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> ValidateRefreshToken(Guid userId, string refreshToken)
        {
            var result = await _context.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(rt => rt.UserId == userId);
            if (result == null || result.Token != refreshToken || result.ExpiryDate > DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }

        public async Task<RefreshToken> GetByUserIdAsync(Guid userId)
        {
            return await _context.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(rt => rt.UserId == userId);
        }
    }
}