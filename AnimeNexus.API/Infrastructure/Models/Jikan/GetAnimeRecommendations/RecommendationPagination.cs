using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations
{
    public class RecommendationPagination
    {
        [JsonPropertyName("last_visible_page")]
        public int LastVisiblePage { get; set; }

        [JsonPropertyName("has_next_page")]
        public bool HasNextPage { get; set; }
    }
}
