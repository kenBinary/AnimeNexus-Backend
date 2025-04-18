using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.AnimeNexus.API.Domain.DTO.Request;
using backend.AnimeNexus.API.Features.Anime.Interfaces;

namespace backend.AnimeNexus.API.Features.Anime.DTO
{
    public class SearchAnimeParameters : IPaginationProperties, ISortingProperties
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public AnimeSearchOrderBy? AnimeSearchOrderBy { get; set; }
        public SortDirection? SortDirection { get; set; }
    }
}