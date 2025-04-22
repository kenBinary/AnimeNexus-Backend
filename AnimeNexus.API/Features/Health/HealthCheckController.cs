using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Features.Health
{
    [ApiController]
    [Route("api/health")]
    public class HealthChecks : ControllerBase
    {

        [HttpGet("")]
        public IActionResult CheckHealth()
        {
            return Ok("API is up an running");
        }

    }
}