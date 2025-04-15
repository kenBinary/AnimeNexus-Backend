using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan
{
    public class PaginationItems
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }
    }
}
