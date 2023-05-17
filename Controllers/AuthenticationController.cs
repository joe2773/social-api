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
            try{
                await _authenticationService.Login(username,password);
            }
            catch(AuthenticationException ex){
                return Unauthorized(ex.Message);
            }
            catch(NotFoundException ex){
                return NotFound(ex.Message);
            }
            
            return Ok();
            // Perform authentication logic to validate the user's credentials
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
