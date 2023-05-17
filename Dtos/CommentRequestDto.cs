namespace Dtos{
    public class CommentRequestDto {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }
    }
}