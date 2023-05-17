namespace Dtos{
    public class UserResponseDto {
        public int Id {get; set;}
        public string? Name { get; set; }
        public string? Bio { get; set; }

        public ICollection<PostResponseDto>? Posts { get; set; }
        public ICollection<LikeResponseDto>? Likes { get; set; }
        public ICollection<CommentResponseDto>? Comments { get; set; }
    }
}