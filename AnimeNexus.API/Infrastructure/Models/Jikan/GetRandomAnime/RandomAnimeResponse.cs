using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan.GetRandomAnime
{
    public class RandomAnimeResponse
    {
        [JsonPropertyName("data")]
        public required AnimeData Data { get; set; }
    }
}
