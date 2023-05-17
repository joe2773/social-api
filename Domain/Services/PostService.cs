using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories;
using Domain.Services.Interfaces;
using FluentValidation.Results;

namespace Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly PostValidator _postValidator;
        private readonly IUserService _userService;

        public PostService(IPostRepository postRepository, PostValidator postValidator, IUserService userService)
        {
            _postRepository = postRepository;
            _postValidator = postValidator;
            _userService = userService;
        }
        public async Task<Post> GetPostById(int id)
        {
            var post = await _postRepository.GetPostById(id);
            if (post == null)
            {
                throw new NotFoundException($"Post with id {id} not found");
            }
            return post;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }
        
        public async Task CreatePost(Post post)
        {
            ValidationResult validationResult = _postValidator.Validate(post);
            if (!validationResult.IsValid)
            {
                throw new ValidationException($"Error creating post: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }
            if(await _userService.GetUserById(post.UserId) == null){
                throw new DomainException($"Error creating post: user with id {post.UserId} not found");
            }
            post.DateCreated = DateTime.Now;
            await _postRepository.CreatePost(post);
        }

        public async Task UpdatePost(Post post)
        {
            var postToUpdate = await _postRepository.GetPostById(post.Id);
            if (postToUpdate == null)
            {
                throw new NotFoundException($"Post with id {post.Id} not found, failed to update");
            }
            ValidationResult validationResult = _postValidator.Validate(post);
            if (!validationResult.IsValid)
            {
                throw new ValidationException($"Error updating post: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }
            if(await _userService.GetUserById(post.UserId) == null){
                throw new DomainException($"Error updating post: user with id {post.UserId} not found");
            }
        

            postToUpdate.DateModified = DateTime.Now;
            await _postRepository.UpdatePost(postToUpdate);
        }

        public async Task DeletePost(int postId)
        {
            var postToDelete = await _postRepository.GetPostById(postId);
            if (postToDelete == null)
            {
                throw new NotFoundException($"Post with id {postId} not found, failed to delete");
            }

            await _postRepository.DeletePost(postToDelete);
        }
    }
}
