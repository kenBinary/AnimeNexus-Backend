using AnimeNexus.API.Infrastructure.Models.Jikan;
using backend.AnimeNexus.API.Domain.DTO.Request;
using AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations;
using AnimeNexus.API.Infrastructure.Models.Jikan.GetRandomAnime;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer;
using backend.AnimeNexus.API.Domain.DTOs.Request;

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

    }
}