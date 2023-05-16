using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories;
using Domain.Services.Interfaces;
using FluentValidation.Results;

namespace Domain.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;
        private readonly LikeValidator _likeValidator;
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public LikeService(ILikeRepository likeRepository, LikeValidator likeValidator, IUserService userService, IPostService postService)
        {
            _likeRepository = likeRepository;
            _likeValidator = likeValidator;
            _userService = userService;
            _postService = postService;
        }

        public async Task<Like> GetLikeById(int id)
        {
            var like = await _likeRepository.GetLikeById(id);
            if (like == null)
            {
                throw new NotFoundException($"Like with id {id} not found");
            }
            return like;
        }

        public async Task CreateLike(Like like)
        {
            ValidationResult validationResult = _likeValidator.Validate(like);
            if (!validationResult.IsValid)
            {
                throw new ValidationException($"Error creating like: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }
            if (await _userService.GetUserById(like.UserId) == null)
            {
                throw new DomainException($"Error creating like: user with id {like.UserId} not found");
            }
             if(await _postService.GetPostById(like.PostId) == null){
                throw new DomainException($"Error creating like: post with id {like.PostId} not found");
            }
            await _likeRepository.CreateLike(like);
        }

        public async Task UpdateLike(Like like)
        {
            var likeToUpdate = await _likeRepository.GetLikeById(like.Id);
            if (likeToUpdate == null)
            {
                throw new NotFoundException($"Like with id {like.Id} not found, failed to update");
            }
            ValidationResult validationResult = _likeValidator.Validate(like);
            if (!validationResult.IsValid)
            {
                throw new ValidationException($"Error updating like: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }
            if (await _userService.GetUserById(like.UserId) == null)
            {
                throw new DomainException($"Error updating like: user with id {like.UserId} not found");
            }
            if(await _postService.GetPostById(like.PostId) == null){
                throw new DomainException($"Error updating like: post with id {like.PostId} not found");
            }
            await _likeRepository.UpdateLike(likeToUpdate);
        }

        public async Task DeleteLike(int likeId)
        {
            var likeToDelete = await _likeRepository.GetLikeById(likeId);
            if (likeToDelete == null)
            {
                throw new NotFoundException($"Like with id {likeId} not found, failed to delete");
            }
            await _likeRepository.DeleteLike(likeToDelete);
        }
    }
}
