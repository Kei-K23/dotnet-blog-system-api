using BlogSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogSystemAPI.Services
{
    public class BlogService(DbContext context) : GeneralOperations<Blog>(context)
    {
        private readonly DbContext _context = context;

        // Implement other service methods
    }
}