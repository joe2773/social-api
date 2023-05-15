using Data.Entities;
public interface IPostRepository
{
    Task<Post> GetPostById(int id);
    Task<List<Post>> GetAllPosts();
    Task CreatePost(Post post);
    Task UpdatePost(Post post);
    Task DeletePost(Post post);
}
