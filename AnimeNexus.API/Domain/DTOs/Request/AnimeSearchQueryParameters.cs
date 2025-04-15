using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.AnimeNexus.API.Domain.DTO.Request

{

    public enum AnimeSearchType
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
        Music,
        [Description("cm")]
        Cm,
        [Description("pv")]
        Pv,
        [Description("tv_special")]
        TvSpecial
    }

    public enum AnimeSearchStatus
    {
        [Description("airing")]
        Airing,
        [Description("complete")]
        Complete,
        [Description("upcoming")]
        Upcoming
    }

    /*
    G - All Ages
    PG - Children
    PG-13 - Teens 13 or older
    R - 17+ (violence & profanity)
    R+ - Mild Nudity
    Rx - Hentai
    */
    public enum AnimeSearchRating
    {
        [Description("g")]
        G,
        [Description("pg")]
        Pg,
        [Description("pg13")]
        Pg13,
        [Description("r17")]
        R17,
        [Description("r")]
        R,
        [Description("rx")]
        Rx
    }

    public enum AnimeSearchOrderBy
    {
        [Description("mal_id")]
        MalId,
        [Description("title")]
        Title,
        [Description("start_date")]
        StartDate,
        [Description("end_date")]
        EndDate,
        [Description("episodes")]
        Episodes,
        [Description("score")]
        Score,
        [Description("scored_by")]
        ScoredBy,
        [Description("rank")]
        Rank,
        [Description("popularity")]
        Popularity,
        [Description("members")]
        Members,
        [Description("favorites")]
        Favorites
    }

    public enum SortDirection
    {
        [Description("desc")]
        Desc,
        [Description("asc")]
        Asc
    }

    public class AnimeSearchQueryParameters
    {
        [FromQuery(Name = "unapproved")]
        public bool? Unapproved { get; set; }

        [FromQuery(Name = "page")]
        public int? Page { get; set; }

        [FromQuery(Name = "limit")]
        public int? Limit { get; set; }

        [FromQuery(Name = "q")]
        public string? Q { get; set; }

        [FromQuery(Name = "type")]
        public AnimeSearchType? Type { get; set; }

        [FromQuery(Name = "score")]
        [Range(1, 9.99, ErrorMessage = "Score must be between 0 and 10.")]
        public double? Score { get; set; }

        [FromQuery(Name = "min_score")]
        [Range(1, 9.99, ErrorMessage = "Minimum score must be between 0 and 10.")]
        public double? MinScore { get; set; }

        [FromQuery(Name = "max_score")]
        [Range(1, 9.99, ErrorMessage = "Maximum score must be between 0 and 10.")]
        public double? MaxScore { get; set; }

        [FromQuery(Name = "status")]
        public AnimeSearchStatus? Status { get; set; }

        [FromQuery(Name = "rating")]
        public AnimeSearchRating? Rating { get; set; }

        [FromQuery(Name = "sfw")]
        public bool? Sfw { get; set; }

        /// <summary>
        /// Filter by comma-separated genre IDs (inclusive).
        /// Bind from query parameter "genres".
        /// </summary>
        [FromQuery(Name = "genres")]
        public string? Genres { get; set; }

        /// <summary>
        /// Exclude by comma-separated genre IDs.
        /// Bind from query parameter "genres_exclude".
        /// </summary>
        [FromQuery(Name = "genres_exclude")]
        public string? GenresExclude { get; set; } // Keep as string

        [FromQuery(Name = "order_by")]
        public AnimeSearchOrderBy? OrderBy { get; set; }

        [FromQuery(Name = "sort")]
        public SortDirection? Sort { get; set; }

        /// <summary>
        /// Filter anime titles starting with a specific letter.
        /// Bind from query parameter "letter".
        /// </summary>
        [FromQuery(Name = "letter")]
        public string? Letter { get; set; }

        /// <summary>
        /// Filter by comma-separated producer IDs.
        /// Bind from query parameter "producers".
        /// </summary>
        [FromQuery(Name = "producers")]
        public string? Producers { get; set; } // Keep as string

        /// <summary>
        /// Filter by start date (YYYY-MM-DD, YYYY-MM, or YYYY).
        /// Bind from query parameter "start_date".
        /// </summary>
        [FromQuery(Name = "start_date")]
        public string? StartDate { get; set; }

        /// <summary>
        /// Filter by end date (YYYY-MM-DD, YYYY-MM, or YYYY).
        /// Bind from query parameter "end_date".
        /// </summary>
        [FromQuery(Name = "end_date")]
        public string? EndDate { get; set; }
    }
}