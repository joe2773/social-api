using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Domain.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> GetPostById(int id);
        Task<List<Post>> GetAllPosts();
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task DeletePost(int postId);
    }
}
