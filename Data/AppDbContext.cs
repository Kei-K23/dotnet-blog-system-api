using BlogSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
