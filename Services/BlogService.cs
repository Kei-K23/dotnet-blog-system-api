using BlogSystemAPI.Data;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;

namespace BlogSystemAPI.Services
{
    public class BlogService(AppDbContext context) : GeneralOperations<Blog>(context), IBlogService
    {
        private readonly AppDbContext _context = context;
        // Implement other service methods
    }
}