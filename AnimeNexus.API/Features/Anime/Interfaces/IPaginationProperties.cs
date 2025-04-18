using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Features.Anime.Interfaces
{
    public interface IPaginationProperties
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
    }
}