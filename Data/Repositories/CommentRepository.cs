using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Data;

namespace Data.Repositories {
    public class CommentRepository : ICommentRepository
    {
        private readonly SocialDbContext _dbContext;

        public CommentRepository(SocialDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }

        public async Task<List<Comment>> GetCommentsByPostId(int postId)
        {
            return await _dbContext.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByUserId(int userId)
        {
            return await _dbContext.Comments
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task CreateComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            _dbContext.Comments.Update(comment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComment(Comment comment)
        {
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }

}
