using System.ComponentModel.DataAnnotations;
using backend.AnimeNexus.API.Domain.DTO.Request;
using backend.AnimeNexus.API.Features.Anime.Interfaces;

namespace backend.AnimeNexus.API.Features.Anime.DTO
{
    public class GetAnimebByOrderParameters : IPaginationProperties
    {
        public int? Page { get; set; }

        [Range(1, 25, ErrorMessage = "Limit must be between 1 and 25.")]
        public int? Limit { get; set; }
        public SortDirection? SortDirection { get; set; }
    }
}