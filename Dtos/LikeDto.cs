
namespace Dtos{
    public class LikeDto {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public PostDto? Post { get; set; }
        public UserRequestDto? User { get; set; }
    }
}