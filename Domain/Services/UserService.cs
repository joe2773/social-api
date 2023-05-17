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
            var user = await _userRepository.GetUserById(id);
            if(user == null){
                throw new NotFoundException($"User with id {id} not found");
            }
            return user;
        }

        public async Task<User> GetUserByUsername(string username){
            var user = await _userRepository.GetUserByUsername(username);
            if(user == null){
                throw new NotFoundException($"User with name {username} not found");
            }
            return user;
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
            User existingUser = await _userRepository.GetUserByUsername(user.Name);
            if(existingUser != null){
                throw new DomainException($"Cannot create user with username {user.Name} as a user with this name already exists");
            }
            await _userRepository.CreateUser(user);
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _userRepository.GetUserByUsername(user.Name);
            if(existingUser != null && (existingUser.Name == user.Name && existingUser.Id != user.Id)){
                throw new DomainException($"Cannot update user to have username {user.Name} as a different user with this name already exists");
            }
            ValidationResult validationResult = _userValidator.Validate(user);
            if(!validationResult.IsValid){
                throw new ValidationException($"Error updating user: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }

            await _userRepository.UpdateUser(user);
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
