using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
            CommentResponseDto commentDto = _mapper.Map<CommentResponseDto>(comment);
            return Ok(commentDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateComment(CommentRequestDto commentDto)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);
            await _commentService.CreateComment(comment);

            return CreatedAtAction(nameof(GetCommentById), new { id = comment.Id }, commentDto);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateComment(CommentRequestDto commentDto)
        {
            Comment comment = _mapper.Map<Comment>(commentDto);
            await _commentService.UpdateComment(comment);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteComment(id);

            return NoContent();
        }
    }
}
