using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories;
using Domain.Services.Interfaces;
using FluentValidation.Results;
namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserValidator _userValidator;

        public UserService(IUserRepository userRepository, UserValidator userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null){
                throw new NotFoundException($"User with id {id} not found");
            }
            return await _userRepository.GetUserById(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task CreateUser(User user)
        {
            ValidationResult validationResult = _userValidator.Validate(user);
            if(!validationResult.IsValid){
                throw new ValidationException($"Error creating user: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }
            await _userRepository.CreateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            var userToUpdate = await _userRepository.GetUserById(user.Id);
            if(userToUpdate == null){
                throw new NotFoundException($"User with id {user.Id} not found, failed to update");
            }
            await _userRepository.UpdateUser(userToUpdate);
        }

        public async Task DeleteUser(int userId)
        {
            var userToDelete = await _userRepository.GetUserById(userId);
            if(userToDelete == null){
                throw new NotFoundException($"User with id {userId} not found, failed to delete");
            }
            
            await _userRepository.DeleteUser(userToDelete);
        }
    }
}
