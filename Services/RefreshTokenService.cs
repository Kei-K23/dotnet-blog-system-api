using BlogSystemAPI.Data;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Services
{
    public class RefreshTokenService(AppDbContext context) : GeneralOperations<RefreshToken>(context), IRefreshTokenService
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> ValidateRefreshToken(string userId, string refreshToken)
        {
            var result = await _context.RefreshTokens.AsNoTracking().FirstAsync(rt => rt.UserId == userId);
            if (result == null || result.Token != refreshToken || result.ExpiryDate > DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }

        // Implement other service methods
    }
}