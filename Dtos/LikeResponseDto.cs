
namespace Dtos{
    public class LikeResponseDto {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }

        public PostRequestDto? Post { get; set; }
        public UserResponseDto? User { get; set; }
    }
}