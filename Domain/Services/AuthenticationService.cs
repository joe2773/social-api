using Domain.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Domain.Services {

    public class AuthenticationService : Interfaces.IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IUserService userService, IHttpContextAccessor httpContextAccessor){
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> Authenticate(string username, string password){
            var user = await _userService.GetUserByUsername(username);
            return user.Password == password;
        }

        public async Task Login(string username, string password)
        {
          bool isAuthenticated = await Authenticate(username, password);
            if (isAuthenticated)
            {
                // Create the user's claims
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, username)
                    // Add additional claims as needed
                };

                // Create the authentication ticket
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var authenticationProperties = new AuthenticationProperties
                {
                    IsPersistent = true // Set to true if you want persistent authentication
                };

                // Sign in the user
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
            } else {
                throw new AuthenticationException("Username or password is invalid");
            }
            
        }
    }
}