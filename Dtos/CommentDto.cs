namespace Dtos{
    public class CommentDto {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }

        public PostDto? Post { get; set; }
        public UserRequestDto? User { get; set; }
    }
}