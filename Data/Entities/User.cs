namespace Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Password { get; set;}
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? PasswordHash { get; set; }

        public ICollection<Post>? Posts { get; set; }
        public ICollection<Like>? Likes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}