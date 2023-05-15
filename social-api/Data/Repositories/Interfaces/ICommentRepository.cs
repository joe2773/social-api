using Data.Entities;
public interface ICommentRepository
{
    Task<Comment> GetCommentById(int id);
    Task<List<Comment>> GetCommentsByPostId(int postId);
    Task<List<Comment>> GetCommentsByUserId(int userId);
    Task CreateComment(Comment comment);
    Task UpdateComment(Comment comment);
    Task DeleteComment(Comment comment);
}
