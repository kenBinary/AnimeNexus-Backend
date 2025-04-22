using System.Text.Json.Serialization;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations
{
    public class RecommendationEntry
    {
        [JsonPropertyName("mal_id")]
        public int MalId { get; set; }

        [JsonPropertyName("url")]
        public required string Url { get; set; }

        [JsonPropertyName("images")]
        public required Images Images { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }
}
