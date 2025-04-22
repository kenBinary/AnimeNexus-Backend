using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations
{
    public class RecommendationUser
    {
        [JsonPropertyName("url")]
        public required string Url { get; set; }

        [JsonPropertyName("username")]
        public required string Username { get; set; }
    }
}
