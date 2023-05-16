using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repositories;
using Domain.Services.Interfaces;
using FluentValidation.Results;

namespace Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly CommentValidator _commentValidator;
        private readonly IUserService _userService;
        private readonly IPostService _postService;

        public CommentService(ICommentRepository commentRepository, CommentValidator commentValidator, IUserService userService, IPostService postService)
        {
            _commentRepository = commentRepository;
            _commentValidator = commentValidator;
            _userService = userService;
            _postService = postService;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetCommentById(id);
            if (comment == null)
            {
                throw new NotFoundException($"Comment with id {id} not found");
            }
            return comment;
        }

        public async Task CreateComment(Comment comment)
        {
            ValidationResult validationResult = _commentValidator.Validate(comment);
            if (!validationResult.IsValid)
            {
                throw new ValidationException($"Error creating comment: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }
            if (await _userService.GetUserById(comment.UserId) == null)
            {
                throw new DomainException($"Error creating comment: user with id {comment.UserId} not found");
            }
            if(await _postService.GetPostById(comment.PostId) == null){
                throw new DomainException($"Error creating comment: post with id {comment.PostId} not found");
            }
            await _commentRepository.CreateComment(comment);
        }

        public async Task UpdateComment(Comment comment)
        {
            var commentToUpdate = await _commentRepository.GetCommentById(comment.Id);
            if (commentToUpdate == null)
            {
                throw new NotFoundException($"Comment with id {comment.Id} not found, failed to update");
            }
            ValidationResult validationResult = _commentValidator.Validate(comment);
            if (!validationResult.IsValid)
            {
                throw new ValidationException($"Error updating comment: {validationResult.Errors.FirstOrDefault().ErrorMessage}");
            }
            if (await _userService.GetUserById(comment.UserId) == null)
            {
                throw new DomainException($"Error updating comment: user with id {comment.UserId} not found");
            }
            if(await _postService.GetPostById(comment.PostId) == null){
                throw new DomainException($"Error updating comment: post with id {comment.PostId} not found");
            }
            await _commentRepository.UpdateComment(commentToUpdate);
        }

        public async Task DeleteComment(int commentId)
        {
            var commentToDelete = await _commentRepository.GetCommentById(commentId);
            if (commentToDelete == null)
            {
                throw new NotFoundException($"Comment with id {commentId} not found, failed to delete");
            }
            await _commentRepository.DeleteComment(commentToDelete);
        }
    }
}
