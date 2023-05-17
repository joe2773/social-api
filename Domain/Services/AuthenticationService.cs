using Domain.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
namespace Domain.Services {

    public class AuthenticationService : Interfaces.IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService){
            _userService = userService;
        }
        public async Task<bool> Authenticate(string username, string password){
            var user = await _userService.GetUserByUsername(username);
            if(user.Password == password){
                return true;
            }
            return false;
        }

        public async Task Login(string username, string password)
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
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

        }
    }
}