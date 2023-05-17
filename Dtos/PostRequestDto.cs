namespace Dtos{
    public class PostRequestDto{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}