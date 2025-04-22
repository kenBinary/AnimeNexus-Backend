using System.Text.Json;
using System.Web;
using backend.AnimeNexus.API.Domain.DTO.Request;
using backend.AnimeNexus.API.Infrastructure.Interfaces;
using backend.AnimeNexus.API.Utils;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer;
using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeList;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetRandomAnime;

namespace backend.AnimeNexus.API.Infrastructure.ExternalServices
{
    public class JikanApiClient : IJikanApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<JikanApiClient> _logger;

        private const string JikanApiBaseUrl = "https://api.jikan.moe/v4/";

        public JikanApiClient(IHttpClientFactory httpClientFactory, ILogger<JikanApiClient> logger)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Gets the full details of an anime
        // https://api.jikan.moe/v4/anime/{id} (https://docs.api.jikan.moe/#tag/anime/operation/getAnimeFullById)
        public async Task<AnimeResponse?> GetAnimeDataFull(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid anime ID provided: {AnimeId}", id);
                return null;
            }

            var client = _httpClientFactory.CreateClient();
            var requestUri = $"{JikanApiBaseUrl}anime/{id}/full";

            try
            {
                _logger.LogInformation("Requesting full anime data for ID: {AnimeId} from {RequestUri}", id, requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var animeResponse = await response.Content.ReadFromJsonAsync<AnimeResponse>();

                if (animeResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize response for anime ID: {AnimeId}", id);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved full anime data for ID: {AnimeId}", id);
                }

                return animeResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching anime data for ID: {AnimeId} from {RequestUri}", id, requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for anime ID: {AnimeId} from {RequestUri}", id, requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching anime data for ID: {AnimeId}", id);
                return null;
            }
        }

        // Gets a list of anime
        // https://api.jikan.moe/v4/anime (https://docs.api.jikan.moe/#tag/anime/operation/getAnimeSearch)
        public async Task<AnimeListResponse?> GetAnime(AnimeSearchQueryParameters queryParams)
        {
            var client = _httpClientFactory.CreateClient();
            var queryString = BuildQueryString(queryParams);
            var requestUri = $"{JikanApiBaseUrl}anime{queryString}";

            try
            {
                _logger.LogInformation("Requesting anime list from {RequestUri}", requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var animeListResponse = await response.Content.ReadFromJsonAsync<AnimeListResponse>();

                if (animeListResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize anime list response from {RequestUri}", requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved anime list from {RequestUri}", requestUri);
                }

                return animeListResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching anime list from {RequestUri}", requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for anime list from {RequestUri}", requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching anime list from {RequestUri}", requestUri);
                return null;
            }
        }

        // Gets anime recommendations
        // (https://docs.api.jikan.moe/#tag/recommendations/operation/getRecentAnimeRecommendations)
        public async Task<RecommendationResponse?> GetAnimeRecommendations(int? page = null)
        {
            var client = _httpClientFactory.CreateClient();
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (page.HasValue)
            {
                query["page"] = page.Value.ToString();
            }

            string? queryString = query.ToString();
            var requestUri = $"{JikanApiBaseUrl}recommendations/anime{(string.IsNullOrEmpty(queryString) ? string.Empty : $"?{queryString}")}";

            try
            {
                _logger.LogInformation("Requesting anime recommendations from {RequestUri}", requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var recommendationResponse = await response.Content.ReadFromJsonAsync<RecommendationResponse>();

                if (recommendationResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize recommendation response from {RequestUri}", requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved anime recommendations from {RequestUri}", requestUri);
                }

                return recommendationResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching anime recommendations from {RequestUri}", requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for anime recommendations from {RequestUri}", requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching anime recommendations from {RequestUri}", requestUri);
                return null;
            }
        }

        // see https://docs.api.jikan.moe/#tag/anime/operation/getAnimeSearch for what these parameters mean
        private string BuildQueryString(AnimeSearchQueryParameters queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (queryParams.Unapproved.HasValue && queryParams.Unapproved.Value) query["unapproved"] = null;
            if (queryParams.Page.HasValue) query["page"] = queryParams.Page.Value.ToString();
            if (queryParams.Limit.HasValue) query["limit"] = queryParams.Limit.Value.ToString();
            if (!string.IsNullOrWhiteSpace(queryParams.Q)) query["q"] = queryParams.Q;
            if (queryParams.Type.HasValue) query["type"] = queryParams.Type.Value.GetDescription();
            if (queryParams.Score.HasValue) query["score"] = queryParams.Score.Value.ToString();
            if (queryParams.MinScore.HasValue) query["min_score"] = queryParams.MinScore.Value.ToString();
            if (queryParams.MaxScore.HasValue) query["max_score"] = queryParams.MaxScore.Value.ToString();
            if (queryParams.Status.HasValue) query["status"] = queryParams.Status.Value.GetDescription();
            if (queryParams.Rating.HasValue) query["rating"] = queryParams.Rating.Value.GetDescription();
            if (queryParams.Sfw.HasValue && queryParams.Sfw.Value) query["sfw"] = null;
            if (!string.IsNullOrWhiteSpace(queryParams.Genres)) query["genres"] = queryParams.Genres;
            if (!string.IsNullOrWhiteSpace(queryParams.GenresExclude)) query["genres_exclude"] = queryParams.GenresExclude;
            if (queryParams.OrderBy.HasValue) query["order_by"] = queryParams.OrderBy.Value.GetDescription();
            if (queryParams.Sort.HasValue) query["sort"] = queryParams.Sort.Value.GetDescription();
            if (!string.IsNullOrWhiteSpace(queryParams.Letter)) query["letter"] = queryParams.Letter;
            if (!string.IsNullOrWhiteSpace(queryParams.Producers)) query["producers"] = queryParams.Producers;
            if (!string.IsNullOrWhiteSpace(queryParams.StartDate)) query["start_date"] = queryParams.StartDate;
            if (!string.IsNullOrWhiteSpace(queryParams.EndDate)) query["end_date"] = queryParams.EndDate;

            string? queryString = query.ToString();
            return string.IsNullOrEmpty(queryString) ? string.Empty : $"?{queryString}";
        }

        // Gets a random anime
        // https://api.jikan.moe/v4/random/anime (https://docs.api.jikan.moe/#tag/random/operation/getRandomAnime)
        public async Task<RandomAnimeResponse?> GetRandomAnime()
        {
            var client = _httpClientFactory.CreateClient();
            var requestUri = $"{JikanApiBaseUrl}random/anime";

            try
            {
                _logger.LogInformation("Requesting random anime from {RequestUri}", requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var randomAnimeResponse = await response.Content.ReadFromJsonAsync<RandomAnimeResponse>();

                if (randomAnimeResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize random anime response from {RequestUri}", requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved random anime from {RequestUri}", requestUri);
                }

                return randomAnimeResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching random anime from {RequestUri}", requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for random anime from {RequestUri}", requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching random anime from {RequestUri}", requestUri);
                return null;
            }
        }

        // Gets full producer details by ID
        // https://api.jikan.moe/v4/producers/{id}/full (https://docs.api.jikan.moe/#tag/producers/operation/getProducerFullById)
        public async Task<ProducerDataFullResponse?> GetAnimeProducerById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid producer ID provided: {ProducerId}", id);
                return null;
            }

            var client = _httpClientFactory.CreateClient();
            var requestUri = $"{JikanApiBaseUrl}producers/{id}/full";

            try
            {
                _logger.LogInformation("Requesting full producer data for ID: {ProducerId} from {RequestUri}", id, requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var producerResponse = await response.Content.ReadFromJsonAsync<ProducerDataFullResponse>();

                if (producerResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize response for producer ID: {ProducerId}", id);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved full producer data for ID: {ProducerId}", id);
                }

                return producerResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching producer data for ID: {ProducerId} from {RequestUri}", id, requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for producer ID: {ProducerId} from {RequestUri}", id, requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching producer data for ID: {ProducerId}", id);
                return null;
            }
        }

        // Gets a list of producers
        // https://api.jikan.moe/v4/producers (https://docs.api.jikan.moe/#tag/producers/operation/getProducers)
        public async Task<ProducerListResponse?> GetAnimeProducers(ProducerSearchQueryParameters queryParams)
        {
            var client = _httpClientFactory.CreateClient();
            var queryString = BuildProducerQueryString(queryParams);
            var requestUri = $"{JikanApiBaseUrl}producers{queryString}";

            try
            {
                _logger.LogInformation("Requesting producer list from {RequestUri}", requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var producerListResponse = await response.Content.ReadFromJsonAsync<ProducerListResponse>();

                if (producerListResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize producer list response from {RequestUri}", requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved producer list from {RequestUri}", requestUri);
                }

                return producerListResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching producer list from {RequestUri}", requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for producer list from {RequestUri}", requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching producer list from {RequestUri}", requestUri);
                return null;
            }
        }

        private string BuildProducerQueryString(ProducerSearchQueryParameters queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (queryParams.Page.HasValue) query["page"] = queryParams.Page.Value.ToString();
            if (queryParams.Limit.HasValue) query["limit"] = queryParams.Limit.Value.ToString();
            if (!string.IsNullOrWhiteSpace(queryParams.Q)) query["q"] = queryParams.Q;
            if (queryParams.OrderBy.HasValue) query["order_by"] = queryParams.OrderBy.Value.GetDescription();
            if (queryParams.Sort.HasValue) query["sort"] = queryParams.Sort.Value.GetDescription();
            if (!string.IsNullOrWhiteSpace(queryParams.Letter)) query["letter"] = queryParams.Letter;

            string? queryString = query.ToString();
            return string.IsNullOrEmpty(queryString) ? string.Empty : $"?{queryString}";
        }

        // Gets the current season anime
        // https://api.jikan.moe/v4/seasons/now (https://docs.api.jikan.moe/#tag/seasons/operation/getSeasonNow)
        public async Task<GetCurrentSeasonResponse?> GetCurrentSeason(SeasonQueryParameters queryParameters)
        {
            var client = _httpClientFactory.CreateClient();
            var queryString = BuildSeasonQueryString(queryParameters);
            var requestUri = $"{JikanApiBaseUrl}seasons/now{queryString}";

            try
            {
                _logger.LogInformation("Requesting current season anime from {RequestUri}", requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var currentSeasonResponse = await response.Content.ReadFromJsonAsync<GetCurrentSeasonResponse>();

                if (currentSeasonResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize current season response from {RequestUri}", requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved current season anime from {RequestUri}", requestUri);
                }

                return currentSeasonResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching current season anime from {RequestUri}", requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for current season anime from {RequestUri}", requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching current season anime from {RequestUri}", requestUri);
                return null;
            }
        }

        // Gets anime for a specific season and year
        // https://api.jikan.moe/v4/seasons/{year}/{season} (https://docs.api.jikan.moe/#tag/seasons/operation/getSeason)
        public async Task<GetSeasonResponse?> GetSeason(int year, string season, SeasonQueryParameters queryParameters)
        {
            if (year <= 0)
            {
                _logger.LogWarning("Invalid year provided: {Year}", year);
                return null;
            }

            if (string.IsNullOrWhiteSpace(season))
            {
                _logger.LogWarning("Invalid season provided: {Season}", season);
                return null;
            }

            var client = _httpClientFactory.CreateClient();
            var queryString = BuildSeasonQueryString(queryParameters);
            var requestUri = $"{JikanApiBaseUrl}seasons/{year}/{season.ToLower()}{queryString}";

            try
            {
                _logger.LogInformation("Requesting anime for {Season} {Year} from {RequestUri}", season, year, requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var seasonResponse = await response.Content.ReadFromJsonAsync<GetSeasonResponse>();

                if (seasonResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize season response for {Season} {Year} from {RequestUri}", season, year, requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved anime for {Season} {Year} from {RequestUri}", season, year, requestUri);
                }

                return seasonResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching anime for {Season} {Year} from {RequestUri}", season, year, requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for {Season} {Year} from {RequestUri}", season, year, requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching anime for {Season} {Year}", season, year);
                return null;
            }
        }

        // Gets all available seasons
        // https://api.jikan.moe/v4/seasons (https://docs.api.jikan.moe/#tag/seasons/operation/getSeasonsList)
        public async Task<SeasonListResponse?> GetAvailableSeasons()
        {
            var client = _httpClientFactory.CreateClient();
            var requestUri = $"{JikanApiBaseUrl}seasons";

            try
            {
                _logger.LogInformation("Requesting available seasons from {RequestUri}", requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var seasonListResponse = await response.Content.ReadFromJsonAsync<SeasonListResponse>();

                if (seasonListResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize available seasons response from {RequestUri}", requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved available seasons from {RequestUri}", requestUri);
                }

                return seasonListResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching available seasons from {RequestUri}", requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for available seasons from {RequestUri}", requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching available seasons from {RequestUri}", requestUri);
                return null;
            }
        }

        // Gets upcoming season anime
        // https://api.jikan.moe/v4/seasons/upcoming (https://docs.api.jikan.moe/#tag/seasons/operation/getSeasonUpcoming)
        public async Task<UpcomingSeasonResponse?> GetUpcomingSeason(SeasonQueryParameters queryParameters)
        {
            var client = _httpClientFactory.CreateClient();
            var queryString = BuildSeasonQueryString(queryParameters);
            var requestUri = $"{JikanApiBaseUrl}seasons/upcoming{queryString}";

            try
            {
                _logger.LogInformation("Requesting upcoming season anime from {RequestUri}", requestUri);
                var response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();

                var upcomingSeasonResponse = await response.Content.ReadFromJsonAsync<UpcomingSeasonResponse>();

                if (upcomingSeasonResponse == null)
                {
                    _logger.LogWarning("Failed to deserialize upcoming season response from {RequestUri}", requestUri);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved upcoming season anime from {RequestUri}", requestUri);
                }

                return upcomingSeasonResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP request failed when fetching upcoming season anime from {RequestUri}", requestUri);
                return null;
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to deserialize Jikan API response for upcoming season anime from {RequestUri}", requestUri);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while fetching upcoming season anime from {RequestUri}", requestUri);
                return null;
            }
        }

        private string BuildSeasonQueryString(SeasonQueryParameters queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (queryParams.Page.HasValue) query["page"] = queryParams.Page.Value.ToString();
            if (queryParams.Limit.HasValue) query["limit"] = queryParams.Limit.Value.ToString();
            if (queryParams.Filter.HasValue) query["filter"] = queryParams.Filter.Value.GetDescription();
            if (queryParams.Sfw.HasValue && queryParams.Sfw.Value) query["sfw"] = null;
            if (queryParams.Unapproved.HasValue && queryParams.Unapproved.Value) query["unapproved"] = null;

            string? queryString = query.ToString();
            return string.IsNullOrEmpty(queryString) ? string.Empty : $"?{queryString}";
        }
    }
}