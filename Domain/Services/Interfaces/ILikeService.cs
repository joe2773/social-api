using System.Threading.Tasks;
using Data.Entities;

namespace Domain.Services.Interfaces
{
    public interface ILikeService
    {
        Task<Like> GetLikeById(int id);
        Task CreateLike(Like like);
        Task UpdateLike(Like like);
        Task DeleteLike(int likeId);
    }
}
