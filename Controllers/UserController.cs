using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Dtos;
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
            UserResponseDto userDto = _mapper.Map<UserResponseDto>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRequestDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            await _userService.CreateUser(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userDto);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserRequestDto userDto)
        {
            var username = User?.Identity?.Name;
            if(username != userDto.Name){
                return Unauthorized($"Cannot update user with name {username} as you are not logged in as that user");
            }
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
