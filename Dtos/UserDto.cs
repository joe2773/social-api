namespace Dtos{
    public class UserRequestDto {
        public int Id {get; set;}
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? Password {get; set;}
        public string? PasswordHash { get; set; }

        public ICollection<PostDto>? Posts { get; set; }
        public ICollection<LikeDto>? Likes { get; set; }
        public ICollection<CommentDto>? Comments { get; set; }
    }
}