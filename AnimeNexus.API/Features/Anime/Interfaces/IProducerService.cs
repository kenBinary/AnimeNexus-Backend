using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.AnimeNexus.API.Features.Anime.Interfaces
{
    // https://docs.api.jikan.moe/#tag/producers
    public interface IProducerService
    {
        // get anime by studio
        Task GetAnimeByStudioAsync(int count);
        // get details information of specific anime studio
        Task GetAnimeStudioAsync(string studioId);

    }
}