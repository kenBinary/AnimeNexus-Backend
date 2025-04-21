using backend.AnimeNexus.API.Domain.DTOs.Request;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason;

namespace backend.AnimeNexus.API.Features.Season.Interfaces
{
    public interface ISeasonService
    {
        Task<GetCurrentSeasonResponse?> GetCurrentSeason(SeasonQueryParameters queryParameters);

        Task<GetSeasonResponse?> GetSeason(int year, string season, SeasonQueryParameters queryParameters);

        Task<SeasonListResponse?> GetAvailableSeasons();

        Task<UpcomingSeasonResponse?> GetUpcomingSeason(SeasonQueryParameters queryParameters);
    }
}