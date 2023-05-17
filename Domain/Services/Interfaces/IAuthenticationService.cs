namespace Domain.Services.Interfaces{

    public interface  IAuthenticationService{
        public Task<bool> Authenticate(string username, string password);
        public Task Login(string username, string password);
    }
}