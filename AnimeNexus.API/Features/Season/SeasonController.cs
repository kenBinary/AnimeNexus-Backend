using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Features.Season.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason;
using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Features.Season
{
    [ApiController]
    [Route("api/season")]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;
        public SeasonController(ISeasonService seasonService)
        {
            _seasonService = seasonService;
        }

        [HttpGet("current")]
        public async Task<ActionResult<GetCurrentSeasonResponse>> GetCurrentSeason([FromQuery] SeasonQueryParameters queryParameters)
        {
            var result = await _seasonService.GetCurrentSeason(queryParameters);

            if (result == null)
            {
                return NotFound("Current season data could not be retrieved.");
            }

            return result;
        }

        [HttpGet("{year}/{season}")]
        public async Task<ActionResult<GetSeasonResponse>> GetSeason(
            [FromRoute] int year,
            [FromRoute] string season,
            [FromQuery] SeasonQueryParameters queryParameters)
        {
            if (year <= 0)
            {
                return BadRequest("Year must be a positive number.");
            }


            if (string.IsNullOrWhiteSpace(season))
            {
                return BadRequest("Season cannot be empty.");
            }

            var result = await _seasonService.GetSeason(year, season.ToLower(), queryParameters);

            if (result == null)
            {
                return NotFound($"Season {season} {year} data could not be retrieved.");
            }

            return result;
        }

        [HttpGet("available")]
        public async Task<ActionResult<SeasonListResponse>> GetAvailableSeasons()
        {
            var result = await _seasonService.GetAvailableSeasons();

            if (result == null)
            {
                return NotFound("Available seasons data could not be retrieved.");
            }

            return result;
        }

        [HttpGet("upcoming")]
        public async Task<ActionResult<UpcomingSeasonResponse>> GetUpcomingSeason([FromQuery] SeasonQueryParameters queryParameters)
        {
            var result = await _seasonService.GetUpcomingSeason(queryParameters);

            if (result == null)
            {
                return NotFound("Upcoming season data could not be retrieved.");
            }

            return result;
        }
    }
}