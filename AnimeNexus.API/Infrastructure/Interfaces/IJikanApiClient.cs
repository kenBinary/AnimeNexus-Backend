using AnimeNexus.API.Infrastructure.Models.Jikan;
using backend.AnimeNexus.API.Domain.DTO.Request;

namespace backend.AnimeNexus.API.Infrastructure.Interfaces
{
    public interface IJikanApiClient
    {
        Task<AnimeListResponse?> GetAnime(AnimeSearchQueryParameters animeSearchQueryParameters);

        Task<AnimeResponse?> GetAnimeDataFull(int id);

    }
}