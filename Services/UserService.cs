using BlogSystemAPI.Data;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Services
{
    public class UserService(AppDbContext context) : GeneralOperations<User>(context), IUserService
    {
        private readonly AppDbContext _context = context;

        public async Task<User> GetUserByUsername(string username)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}