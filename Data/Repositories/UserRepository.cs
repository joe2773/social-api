using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories {
    public class UserRepository : IUserRepository
    {
        private readonly SocialDbContext _dbContext;

        public UserRepository(SocialDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsername(string username){
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Name == username);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
