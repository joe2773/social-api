namespace Dtos{
    public class PostResponseDto{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime DateCreated { get; set; }

        public UserResponseDto? User { get; set; }
        public ICollection<LikeResponseDto>? Likes { get; set; }
        public ICollection<CommentResponseDto>? Comments { get; set; }
    }
}