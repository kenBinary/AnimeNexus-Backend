using backend.AnimeNexus.API.Domain.DTO.Request;
using backend.AnimeNexus.API.Features.Anime.DTO;
using backend.AnimeNexus.API.Features.Anime.Interfaces;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeList;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations;
using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Features.Anime
{
    [ApiController]
    [Route("api/anime")]
    public class AnimeController : ControllerBase
    {
        public readonly IAnimeService _animeService;
        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<AnimeListResponse>> GetAnime(AnimeSearchQueryParameters queryParameters)
        {
            var animeList = await _animeService.GetAnimeList(queryParameters);

            if (animeList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(animeList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeResponse>> GetAnimeFull(int id)
        {
            var animeData = await _animeService.GetAnimeByIdAsync(id);

            if (animeData == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(animeData);
        }

        [HttpGet("studio/{studioId}")]
        public async Task<ActionResult<AnimeListResponse>> GetAnimeByStudio(int studioId, [FromQuery] GetAnimeByStudioRequest queryParameters)
        {
            var animeList = await _animeService.GetAnimeByStudioAsync(studioId, queryParameters);

            if (animeList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(animeList);
        }

        [HttpGet("genre/{genre}")]
        public async Task<ActionResult<AnimeListResponse>> TestEndpoint(string genre, [FromQuery] GetAnimeByGenreQueryParameters parameters)
        {
            Dictionary<string, int> availableGenres = new(StringComparer.OrdinalIgnoreCase)
            {
                { "Action", 1 },
                { "Adventure", 2 },
                { "Avant Garde", 5 },
                { "Award Winning", 46 },
                { "Boys Love", 28 },
                { "Comedy", 4 },
                { "Drama", 8 },
                { "Fantasy", 10 },
                { "Girls Love", 26 },
                { "Gourmet", 47 },
                { "Horror", 14 },
                { "Mystery", 7 },
                { "Romance", 22 },
                { "Sci-Fi", 24 },
                { "Slice of Life", 36 },
                { "Sports", 30 },
                { "Supernatural", 37 },
                { "Suspense", 41 },
                { "Ecchi", 9 },
                { "Erotica", 49 },
                { "Hentai", 12 }
            };

            if (!availableGenres.TryGetValue(genre.ToString(), out int value))
            {
                string availableGenreList = string.Join(", ", availableGenres.Keys);
                return BadRequest($"Genre must be one of the following: {availableGenreList}");
            }

            var animeList = await _animeService.GetAnimeByGenreAsync(value.ToString(), parameters);

            if (animeList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(animeList);

        }

        /*
        Mapping for AnimeSearchOrderBy enum values (for reference):
        0: mal_id
        1: title
        2: start_date
        3: end_date
        4: episodes
        5: score
        6: scored_by
        7: rank
        8: popularity
        9: members
        10: favorites
        */
        [HttpGet("top-anime/{order}")]
        public async Task<ActionResult<AnimeListResponse>> GetAnimeByPopularity(AnimeSearchOrderBy order, [FromQuery] GetAnimebByOrderParameters parameters)
        {
            var animeList = await _animeService.GetAnimeByOrderAsync(order, parameters);

            if (animeList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            // removes the first anime because for some reason there is a random anime in the beginning
            animeList.Data.RemoveAt(0);

            return Ok(animeList);
        }

        /*
        0: airing
        1: complete
        2: upcoming
        */
        [HttpGet("status/{status}")]
        public async Task<ActionResult<AnimeListResponse>> GetAnimeByStatus(AnimeSearchStatus status, [FromQuery] GetAnimeByStatusParameters parameters)
        {
            var animeList = await _animeService.GetAnimeByStatusAsync(status, parameters);

            if (animeList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(animeList);
        }

        [HttpGet("search/{animeName}")]
        public async Task<ActionResult<AnimeListResponse>> SearchAnimeByName(string animeName, [FromQuery] SearchAnimeParameters parameters)
        {
            var animeList = await _animeService.SearchAnimeAsync(animeName, parameters);

            if (animeList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(animeList);
        }

        [HttpGet("recommendations")]
        public async Task<ActionResult<RecommendationResponse>> GetAnimeRecommendations([FromQuery] int? page = null)
        {
            var recommendationList = await _animeService.GetAnimeRecommendationsAsync(page);

            if (recommendationList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(recommendationList);
        }

        [HttpGet("random")]
        public async Task<ActionResult<RandomAnimeList>> GetRandomAnimes([FromQuery] int count = 10)
        {
            var recommendationList = await _animeService.GetRandomAnimeListAsync(count);

            if (recommendationList == null)
            {
                return BadRequest("An error occured while trying to request for the resource");
            }

            return Ok(recommendationList);
        }

    }
}
