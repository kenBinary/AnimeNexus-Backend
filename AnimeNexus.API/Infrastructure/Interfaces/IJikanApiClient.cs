using AnimeNexus.API.Infrastructure.Models.Jikan;
using backend.AnimeNexus.API.Domain.DTO.Request;
using AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations;

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

    }
}