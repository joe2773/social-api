using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dtos;
using Data.Entities;
using Domain.Services.Interfaces;

namespace YourNamespace.Controllers
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
            if (user == null)
            {
                return NotFound();
            }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            User existingUser = await _userService.GetUserById(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            _mapper.Map(userDto, existingUser);
            await _userService.UpdateUser(existingUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            User user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(user);

            return NoContent();
        }
    }
}
