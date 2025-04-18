using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeNexus.API.Infrastructure.Models.Jikan.GetRandomAnime;

namespace backend.AnimeNexus.API.Features.Anime.DTO
{
    public class RandomAnimeList
    {
        public List<RandomAnimeResponse> Data { get; set; } = [];
    }
}