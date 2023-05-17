namespace Dtos{
    public class UserRequestDto {
        public int Id {get; set;}
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? Password {get; set;}
        public string? PasswordHash { get; set; }
    }
}