using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Posterr.Application.DTOs;
using Posterr.Application.Interfaces;

namespace Posterr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto user)
        {
            var response = await _userAppService.SaveAsync(user);

            if (response.Success)
                return CreatedAtAction(nameof(GetById),response);

            return BadRequest(response);
        }

        [HttpPost("follow")]
        public async Task<IActionResult> Put([FromBody] UserFollowerDto userFollowerDto)
        {
            var response = await _userAppService.FollowUserAsync(userFollowerDto);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _userAppService.GetByIdAsync(id);

            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }
    }
}
