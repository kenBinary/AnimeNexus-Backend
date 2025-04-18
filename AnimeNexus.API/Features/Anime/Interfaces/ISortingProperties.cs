using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.AnimeNexus.API.Domain.DTO.Request;

namespace backend.AnimeNexus.API.Features.Anime.Interfaces
{
    public interface ISortingProperties
    {
        public AnimeSearchOrderBy? AnimeSearchOrderBy { get; set; }
        public SortDirection? SortDirection { get; set; }
    }
}