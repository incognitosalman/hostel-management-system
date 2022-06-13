using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hostel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        public HostelsController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Hostel: {id}");
        }
    }
}
