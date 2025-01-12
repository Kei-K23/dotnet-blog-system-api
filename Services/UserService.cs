using BlogSystemAPI.Data;
using BlogSystemAPI.Interfaces;
using BlogSystemAPI.Models;

namespace BlogSystemAPI.Services
{
    public class UserService(AppDbContext context) : GeneralOperations<User>(context), IUserService
    {
    }
}