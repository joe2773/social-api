using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Domain.Services.Interfaces;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Domain.Services.Interfaces.IAuthenticationService _authenticationService;
        public AuthenticationController( IUserService userService, Domain.Services.Interfaces.IAuthenticationService authenticationService){
            _userService = userService;
            _authenticationService = authenticationService;
        }
        // POST: /api/authentication/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Perform authentication logic to validate the user's credentials
            bool isAuthenticated = Authenticate(username, password);
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
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

                return Ok(); // Return a success response
            }

            // Authentication failed, return an error message or unauthorized response
            return Unauthorized();
        }

        // POST: /api/authentication/logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok(); // Return a success response
        }

        // Perform authentication logic to validate the user's credentials
        private bool Authenticate(string username, string password)
        {
            // Your authentication logic goes here
            // Check the username and password against your user database or any other authentication mechanism

            // Return true if the user is authenticated, false otherwise
            return (username == "admin" && password == "password");
        }
    }
}
