using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dtos;
using Data.Entities;
using Domain.Services.Interfaces;

namespace Controllers
{
    [ApiController]
    [ErrorHandling]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            Post post = await _postService.GetPostById(id);
            PostResponseDto postDto = _mapper.Map<PostResponseDto>(post);
            return Ok(postDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostRequestDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto);
            await _postService.CreatePost(post);
            
            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, postDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(PostRequestDto postDto)
        {
            Post post = _mapper.Map<Post>(postDto);
            await _postService.UpdatePost(post);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postService.DeletePost(id);

            return NoContent();
        }
    }
}
