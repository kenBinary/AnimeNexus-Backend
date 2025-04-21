using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason
{
    public class SeasonListResponse
    {
        [JsonPropertyName("pagination")]
        public PaginationInfo Pagination { get; set; } = null!;

        [JsonPropertyName("data")]
        public List<SeasonYearInfo> Data { get; set; } = [];
    }

    public class PaginationInfo
    {
        [JsonPropertyName("last_visible_page")]
        public int LastVisiblePage { get; set; }

        [JsonPropertyName("has_next_page")]
        public bool HasNextPage { get; set; }
    }

    public class SeasonYearInfo
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("seasons")]
        public List<string> Seasons { get; set; } = [];
    }
}