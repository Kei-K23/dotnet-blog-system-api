using BlogSystemAPI.Data;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;

namespace BlogSystemAPI.Services
{
    public class CommentService(AppDbContext context) : GeneralOperations<Comment>(context), ICommentService
    {
    }
}