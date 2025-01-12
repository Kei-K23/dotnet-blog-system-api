using BlogSystemAPI.Models;

namespace BlogSystemAPI.Interfaces
{
    public interface IUserService : IGeneralOperations<User>
    {
        Task<User> GetUserByUsername(string username);
    }
}