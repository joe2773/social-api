using Data.Entities;
namespace Domain.Services.Interfaces {
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
    }

}
