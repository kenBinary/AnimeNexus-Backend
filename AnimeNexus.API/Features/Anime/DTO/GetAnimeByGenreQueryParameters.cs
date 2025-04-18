using System.ComponentModel.DataAnnotations;
using backend.AnimeNexus.API.Domain.DTO.Request;
using backend.AnimeNexus.API.Features.Anime.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Features.Anime.DTO
{
    public class GetAnimeByGenreQueryParameters : IPaginationProperties, ISortingProperties
    {
        [FromQuery(Name = "page")]
        public int? Page { get; set; }

        [FromQuery(Name = "limit")]
        [Range(1, 25, ErrorMessage = "Limit must be between 1 and 25.")]
        public int? Limit { get; set; }

        [FromQuery(Name = "order_by")]
        public AnimeSearchOrderBy? AnimeSearchOrderBy { get; set; }

        [FromQuery(Name = "sort")]
        public SortDirection? SortDirection { get; set; }

    }
}