using backend.AnimeNexus.API.Features.Anime.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Interfaces;
using backend.AnimeNexus.API.Domain.DTO.Request;
using backend.AnimeNexus.API.Features.Anime.DTO;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeList;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetRandomAnime;

namespace backend.AnimeNexus.API.Features.Anime.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IJikanApiClient _jikanApiClient;
        private readonly ILogger<AnimeService> _logger;

        public AnimeService(IJikanApiClient jikanApiClient, ILogger<AnimeService> logger)
        {
            _jikanApiClient = jikanApiClient ?? throw new ArgumentNullException(nameof(jikanApiClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<AnimeListResponse?> GetAnimeByGenreAsync(string genre, GetAnimeByGenreQueryParameters parameters)
        {
            _logger.LogInformation("Fetching anime by genre ID: {GenreId}", parameters);
            var queryParams = new AnimeSearchQueryParameters
            {
                Unapproved = false,
                Genres = genre,
                Page = parameters.Page,
                Limit = parameters.Limit,
                OrderBy = parameters.AnimeSearchOrderBy,
                Sort = parameters.SortDirection,
            };
            return await _jikanApiClient.GetAnime(queryParams);
        }

        public async Task<AnimeResponse?> GetAnimeByIdAsync(int malId)
        {
            if (malId > int.MaxValue || malId < int.MinValue)
            {
                _logger.LogWarning("Provided MAL ID {MalId} is out of range for Jikan API.", malId);
                return null;
            }

            _logger.LogInformation("Fetching anime by MAL ID: {MalId}", malId);
            return await _jikanApiClient.GetAnimeDataFull(malId);
        }

        public async Task<AnimeListResponse?> GetAnimeByOrderAsync(AnimeSearchOrderBy order, GetAnimebByOrderParameters parameters)
        {
            _logger.LogInformation("Fetching anime ordered by popularity");
            var queryParams = new AnimeSearchQueryParameters
            {
                Unapproved = false,
                Page = parameters.Page,
                Limit = parameters.Limit,
                OrderBy = order,
                Sort = parameters.SortDirection,
            };

            return await _jikanApiClient.GetAnime(queryParams);
        }

        public async Task<AnimeListResponse?> GetAnimeByStatusAsync(AnimeSearchStatus status, GetAnimeByStatusParameters parameters)
        {
            _logger.LogInformation("Fetching anime by status: {Status}", status);

            var queryParams = new AnimeSearchQueryParameters
            {
                Status = status,
                Unapproved = false,
                Page = parameters.Page,
                Limit = parameters.Limit,
                OrderBy = parameters.AnimeSearchOrderBy,
                Sort = parameters.SortDirection,
            };

            return await _jikanApiClient.GetAnime(queryParams);
        }

        public async Task<AnimeListResponse?> GetAnimeByStudioAsync(int producerId, GetAnimeByStudioRequest queryParameters)
        {
            _logger.LogInformation("Searching anime with query with studio ID: {studio}", producerId);

            var queryParams = new AnimeSearchQueryParameters
            {
                Producers = producerId.ToString(),
                Page = queryParameters.Page,
                Limit = queryParameters.Limit,
                OrderBy = queryParameters.AnimeSearchOrderBy,
                Sort = queryParameters.SortDirection,
                Status = queryParameters.AnimeSearchStatus,
            };

            var animeList = await _jikanApiClient.GetAnime(queryParams);

            return animeList;
        }

        public async Task<AnimeListResponse?> GetAnimeList(AnimeSearchQueryParameters queryParameters)
        {

            return await _jikanApiClient.GetAnime(queryParameters);
        }

        public async Task<RecommendationResponse?> GetAnimeRecommendationsAsync(int? page = null)
        {
            _logger.LogInformation("Getting anime with recommendations");

            return await _jikanApiClient.GetAnimeRecommendations(page);
        }

        public async Task<RandomAnimeList?> GetRandomAnimeListAsync(int count)
        {
            _logger.LogInformation("Getting a list of {Count} random animes", count);

            var tasks = new List<Task<RandomAnimeResponse?>>(count);

            for (int i = 0; i < count; i++)
            {
                tasks.Add(_jikanApiClient.GetRandomAnime());
            }

            var results = await Task.WhenAll(tasks);

            var animes = results.Where(anime => anime != null).ToList();

            _logger.LogInformation("Successfully retrieved {RetrievedCount} random animes out of {RequestedCount} requests", animes.Count, count);

            return new RandomAnimeList()
            {
                Data = animes!,
            };
        }

        public async Task<AnimeListResponse?> SearchAnimeAsync(string animeName, SearchAnimeParameters parameters)
        {
            _logger.LogInformation("Searching anime with query: {Query}", animeName);

            var queryParams = new AnimeSearchQueryParameters
            {
                Q = animeName,
                Unapproved = false,
                Page = parameters.Page,
                Limit = parameters.Limit,
                OrderBy = parameters.AnimeSearchOrderBy,
                Sort = parameters.SortDirection,
            };

            return await _jikanApiClient.GetAnime(queryParams);
        }

    }
}