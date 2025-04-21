using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Features.Season
{
    [ApiController]
    [Route("api/season")]
    public class SeasonController : ControllerBase
    {
        private readonly IJikanApiClient _jikanApiClient;
        public SeasonController(IJikanApiClient jikanApiClient)
        {
            _jikanApiClient = jikanApiClient;
        }

        // TODO: remove
        [HttpGet("/{year}/{season}")]
        public async Task<IActionResult> TestEndpoint(int year, string season, SeasonQueryParameters queryParameters)
        {

            var x = await _jikanApiClient.GetSeason(year, season, queryParameters);
            return Ok(x);
        }
    }
}