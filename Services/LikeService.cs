using BlogSystemAPI.Data;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Services
{
    public class LikeService(AppDbContext context) : ILikeService
    {
        private readonly AppDbContext _context = context;

        public IEnumerable<Like> GetAllLikesByUserId(Guid userId)
        {
            var likes = _context.Likes.Where(l => l.UserId == userId).OrderByDescending(l => l.CreatedAt).ToList();
            return likes;
        }

        public async Task ToggleLike(Guid userId, Guid blogId)
        {
            var result = await _context.Likes.AsNoTracking().FirstOrDefaultAsync(l =>
                l.UserId == userId && l.BlogId == blogId
            );

            if (result != null)
            {
                // Delete like
                _context.Likes.Remove(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Create like
                var newLike = new Like
                {
                    BlogId = blogId,
                    UserId = userId,
                };
                await _context.Likes.AddAsync(newLike);
                await _context.SaveChangesAsync();
            }
        }
    }
}