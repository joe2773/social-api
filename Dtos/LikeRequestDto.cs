
namespace Dtos{
    public class LikeRequestDto {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}