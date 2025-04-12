using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.AnimeNexus.API.Features.Health
{
    [ApiController]
    [Route("api/health")]
    public class HealthChecks : ControllerBase
    {

        [HttpGet("health")]
        public ActionResult<string> CheckHealth()
        {
            return Ok("API is up an running");
        }

    }
}