using AnimeNexus.API.Infrastructure.Models.Jikan;
using backend.AnimeNexus.API.Domain.DTO.Request;
using AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations;
using AnimeNexus.API.Infrastructure.Models.Jikan.GetRandomAnime;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer;
using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason;

namespace backend.AnimeNexus.API.Infrastructure.Interfaces
{
    public interface IJikanApiClient
    {
        // https://api.jikan.moe/v4/anime
        Task<AnimeListResponse?> GetAnime(AnimeSearchQueryParameters animeSearchQueryParameters);

        // https://api.jikan.moe/v4/anime/{id}/full
        Task<AnimeResponse?> GetAnimeDataFull(int id);

        // https://api.jikan.moe/v4/recommendations/anime
        Task<RecommendationResponse?> GetAnimeRecommendations(int? page = null);

        // https://api.jikan.moe/v4/random/anime
        Task<RandomAnimeResponse?> GetRandomAnime();

        // https://api.jikan.moe/v4/producers/{id}/full
        Task<ProducerDataFullResponse?> GetAnimeProducerById(int id);

        // https://api.jikan.moe/v4/producers
        Task<ProducerListResponse?> GetAnimeProducers(ProducerSearchQueryParameters queryParameters);

        // https://api.jikan.moe/v4/seasons/now
        Task<GetCurrentSeasonResponse?> GetCurrentSeason(SeasonQueryParameters queryParameters);

        // https://api.jikan.moe/v4/seasons/{year}/{season}
        Task<GetSeasonResponse?> GetSeason(int year, string season, SeasonQueryParameters queryParameters);

        // https://api.jikan.moe/v4/seasons
        Task<SeasonListResponse?> GetAvailableSeasons();

        // https://api.jikan.moe/v4/seasons/upcoming
        Task<UpcomingSeasonResponse?> GetUpcomingSeason(SeasonQueryParameters queryParameters);

    }
}