using BlogSystemAPI.Models;

namespace BlogSystemAPI.Interfaces
{
    public interface ILikeService
    {
        Task ToggleLike(Guid userId, Guid blogId);

        IEnumerable<Like> GetAllLikesByUserId(Guid userId);
    }
}