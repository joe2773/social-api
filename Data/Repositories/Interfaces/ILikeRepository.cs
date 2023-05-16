using Data.Entities;
public interface ILikeRepository
{
    Task<Like> GetLikeById(int id);
    Task<List<Like>> GetAllLikes();
    Task CreateLike(Like like);
     Task UpdateLike(Like like);
    Task DeleteLike(Like like);
}
