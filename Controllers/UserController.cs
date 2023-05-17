using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dtos;
using Data.Entities;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [ErrorHandling]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User user = await _userService.GetUserById(id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            await _userService.CreateUser(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userDto);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            var userId = User.Identity.Name;
            Console.WriteLine(userId);
            User user = _mapper.Map<User>(userDto);
            await _userService.UpdateUser(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            await _userService.DeleteUser(id);

            return NoContent();
        }
    }
}
