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
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public CommentController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            Comment comment = await _commentService.GetCommentById(id);
            CommentRequestDto commentDto = _mapper.Map<CommentRequestDto>(comment);
            return Ok(commentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentRequestDto commentDto)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);
            await _commentService.CreateComment(comment);

            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, commentDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(CommentRequestDto commentDto)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);
            await _commentService.UpdateComment(comment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteComment(id);

            return NoContent();
        }
    }
}
