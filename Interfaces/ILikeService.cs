namespace BlogSystemAPI.Interfaces
{
    public interface ILikeService
    {
        Task ToggleLike(Guid userId, Guid blogId);
    }
}