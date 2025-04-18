using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeNexus.API.Infrastructure.Models.Jikan;
using AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations;
using backend.AnimeNexus.API.Domain.DTO.Request;
using backend.AnimeNexus.API.Features.Anime.DTO;

namespace backend.AnimeNexus.API.Features.Anime.Interfaces
{
    public class Pagination
    {

    }
    public interface IAnimeService
    {
        // Pagination : pagination e.g limit and page number
        // Sorting: order by and sort
        // Search Term: q
        // Filters : (type, status, rating, score, min_score, max_score, sfw, genres, genres_exclude, letter, producers, start_date, end_date)

        // Gets the full details of an anime
        Task<AnimeResponse?> GetAnimeByIdAsync(int malId);

        // Get genres in anime
        Task<AnimeListResponse?> GetAnimeByGenreAsync(string genre, GetAnimeByGenreQueryParameters parameters);

        // see `AnimeSearchOrderBy` enum to see available values for order
        Task<AnimeListResponse?> GetAnimeByOrderAsync(AnimeSearchOrderBy order, GetAnimebByOrderParameters parameters);

        // get anime by status (airing or not)
        Task<AnimeListResponse?> GetAnimeByStatusAsync(AnimeSearchStatus status, GetAnimeByStatusParameters parameters);

        // search for anime by name e.g. one punch man, dragon ball, jujutsu kaisen
        Task<AnimeListResponse?> SearchAnimeAsync(string animeName, SearchAnimeParameters parameters);

        // get anime recommendations
        Task<RecommendationResponse?> GetAnimeRecommendationsAsync(int? page = null);

        // get a list of random anime
        Task<RandomAnimeList?> GetRandomAnimeListAsync(int count);

    }
}