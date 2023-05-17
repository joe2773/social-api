namespace Dtos{
    public class CommentResponseDto {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }

        public PostResponseDto? Post { get; set; }
        public UserResponseDto? User { get; set; }
    }
}