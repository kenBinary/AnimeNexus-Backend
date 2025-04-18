using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.AnimeNexus.API.Features.Anime.Interfaces
{
    // https://docs.api.jikan.moe/#tag/seasons
    public interface ISeasonService
    {
        // get anime by season
        Task GetAnimeBySeasonAsync();
        // get anime of current season
        Task GetAnimeByCurrentSeason();
        // get a list of seasons
        Task GetAnimeSeasons();
        // get upcoming season
        Task GetUpcomingSeason();

    }
}