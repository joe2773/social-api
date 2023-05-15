using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
public class LikeRepository : ILikeRepository
{
    private readonly SocialDbContext _dbContext;

    public LikeRepository(SocialDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Like> GetLikeById(int id)
    {
        return await _dbContext.Likes.FindAsync(id);
    }

    public async Task<List<Like>> GetAllLikes()
    {
        return await _dbContext.Likes.ToListAsync();
    }

    public async Task CreateLike(Like like)
    {
        _dbContext.Likes.Add(like);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteLike(Like like)
    {
        _dbContext.Likes.Remove(like);
        await _dbContext.SaveChangesAsync();
    }
}
