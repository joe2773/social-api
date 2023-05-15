namespace Dtos{
    public class PostDto{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public UserDto? User { get; set; }
        public ICollection<LikeDto>? Likes { get; set; }
        public ICollection<CommentDto>? Comments { get; set; }
    }
}