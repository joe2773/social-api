using Data.Entities;
using Microsoft.EntityFrameworkCore;

public class PostRepository : IPostRepository
{
    private readonly SocialDbContext _dbContext;

    public PostRepository(SocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Post> GetPostById(int id)
    {
        return await _dbContext.Posts.FindAsync(id);
    }

    public async Task<List<Post>> GetAllPosts()
    {
        return await _dbContext.Posts.ToListAsync();
    }

    public async Task CreatePost(Post post)
    {
        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePost(Post post)
    {
        _dbContext.Posts.Update(post);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeletePost(Post post)
    {
        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync();
    }
}
