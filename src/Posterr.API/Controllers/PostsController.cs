using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Posterr.Application.DTOs;

namespace Posterr.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationDto pagination)
        {
            return Ok();
        }
    }
}
