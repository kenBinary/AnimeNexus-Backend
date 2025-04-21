using System.Text.Json.Serialization;
using AnimeNexus.API.Infrastructure.Models.Jikan;


namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason
{
    public class GetSeasonResponse
    {
        [JsonPropertyName("pagination")]
        public required Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public required List<AnimeData> Data { get; set; }

        [JsonPropertyName("links")]
        public PaginationLinks? Links { get; set; }

        [JsonPropertyName("meta")]
        public PaginationMeta? Meta { get; set; }
    }


    public class PaginationLinks
    {
        [JsonPropertyName("first")]
        public required string First { get; set; }

        [JsonPropertyName("last")]
        public required string Last { get; set; }

        [JsonPropertyName("prev")]
        public string? Prev { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }
    }

    public class PaginationMeta
    {
        [JsonPropertyName("current_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("last_page")]
        public int LastPage { get; set; }

        [JsonPropertyName("links")]
        public List<PaginationLink> Links { get; set; } = [];

        [JsonPropertyName("path")]
        public required string Path { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class PaginationLink
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("label")]
        public required string Label { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }
    }
}