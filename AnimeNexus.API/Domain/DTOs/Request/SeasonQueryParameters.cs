using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace backend.AnimeNexus.API.Domain.DTOs.Request
{
    public enum AnimeSearchFilter
    {
        [Description("tv")]
        Tv,

        [Description("movie")]
        Movie,

        [Description("ova")]
        Ova,

        [Description("special")]
        Special,

        [Description("ona")]
        Ona,

        [Description("music")]
        Music
    }

    public class SeasonQueryParameters
    {

        [FromQuery(Name = "filter")]
        public AnimeSearchFilter? Filter { get; set; }

        [FromQuery(Name = "sfw")]
        public bool? Sfw { get; set; }

        [FromQuery(Name = "unapproved")]
        public bool? Unapproved { get; set; }

        [FromQuery(Name = "continuing")]
        public bool? Continuing { get; set; }

        [FromQuery(Name = "page")]
        public int? Page { get; set; }

        [FromQuery(Name = "limit")]
        [Range(1, 25, ErrorMessage = "Limit must be between 1 and 25")]
        public int? Limit { get; set; }
    }
}