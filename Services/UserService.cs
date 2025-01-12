using BlogSystemAPI.Data;
using BlogSystemAPI.Dtos;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Services
{
    public class UserService(AppDbContext context) : GeneralOperations<User>(context), IUserService
    {
        private readonly AppDbContext _context = context;

        public async Task<UserResponseDto> GetBlogsByUserId(Guid id)
        {
            var user = await _context.Users.Include(u => u.Blogs).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;

            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                DisplayName = user.DisplayName,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Blogs = user.Blogs.Select(b => new BlogResponseDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    UserId = b.UserId,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                }).ToList()
            };
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}