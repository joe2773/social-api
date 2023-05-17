using Data.Entities;
public interface IUserRepository
{
    Task<User> GetUserById(int id);

    Task<User> GetUserByUsername(string username);
    Task<List<User>> GetAllUsers();
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
}
