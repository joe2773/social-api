using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Entities;

namespace Domain.Services.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> GetCommentById(int id);
        Task CreateComment(Comment comment);
        Task UpdateComment(Comment comment);
        Task DeleteComment(int commentId);
    }
}
