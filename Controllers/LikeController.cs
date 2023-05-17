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
    [Route("api/likes")]
    public class LikeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILikeService _likeService;

        public LikeController(IMapper mapper, ILikeService likeService)
        {
            _mapper = mapper;
            _likeService = likeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLikeById(int id)
        {
            Like like = await _likeService.GetLikeById(id);
            LikeRequestDto likeDto = _mapper.Map<LikeRequestDto>(like);
            return Ok(likeDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLike(LikeRequestDto likeDto)
        {
            Like like = _mapper.Map<Like>(likeDto);
            await _likeService.CreateLike(like);

            return CreatedAtAction(nameof(GetLikeById), new { id = like.Id }, likeDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLike(LikeRequestDto likeDto)
        {
            Like like = _mapper.Map<Like>(likeDto);
            await _likeService.UpdateLike(like);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLike(int id)
        {
            await _likeService.DeleteLike(id);

            return NoContent();
        }
    }
}
