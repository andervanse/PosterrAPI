using Microsoft.AspNetCore.Mvc;
using Posterr.Application.DTOs;
using Posterr.Application.Interfaces;

namespace Posterr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostAppService _postAppService;

        public PostsController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationDto pagination)
        {
            var response = await _postAppService.GetPagedAsync(pagination);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePostDto post)
        {
            var response = await _postAppService.AddPostAsync(post);

            if (response.Success)
                return CreatedAtAction(nameof(GetById), new { postId = response?.Data?.Id }, response?.Data);

            return BadRequest(response);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid postId)
        {
            var response = await _postAppService.GetByIdAsync(postId);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
