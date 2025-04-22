using System.Text.Json.Serialization;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeList;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetRandomAnime
{
    public class RandomAnimeResponse
    {
        [JsonPropertyName("data")]
        public required AnimeData Data { get; set; }
    }
}
