using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Features.Season.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason;

namespace backend.AnimeNexus.API.Features.Season.Services
{
    public class SeasonService : ISeasonService
    {
        private readonly IJikanApiClient _jikanApiClient;
        private readonly ILogger<SeasonService> _logger;

        public SeasonService(IJikanApiClient jikanApiClient, ILogger<SeasonService> logger)
        {
            _jikanApiClient = jikanApiClient ?? throw new ArgumentNullException(nameof(jikanApiClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GetCurrentSeasonResponse?> GetCurrentSeason(SeasonQueryParameters queryParameters)
        {
            _logger.LogInformation("Getting anime from current season");
            return await _jikanApiClient.GetCurrentSeason(queryParameters);
        }

        public async Task<GetSeasonResponse?> GetSeason(int year, string season, SeasonQueryParameters queryParameters)
        {
            _logger.LogInformation("Getting anime from {Season} {Year}", season, year);
            return await _jikanApiClient.GetSeason(year, season, queryParameters);
        }

        public async Task<SeasonListResponse?> GetAvailableSeasons()
        {
            _logger.LogInformation("Getting available anime seasons");
            return await _jikanApiClient.GetAvailableSeasons();
        }

        public async Task<UpcomingSeasonResponse?> GetUpcomingSeason(SeasonQueryParameters queryParameters)
        {
            _logger.LogInformation("Getting anime from upcoming season");
            return await _jikanApiClient.GetUpcomingSeason(queryParameters);
        }
    }
}