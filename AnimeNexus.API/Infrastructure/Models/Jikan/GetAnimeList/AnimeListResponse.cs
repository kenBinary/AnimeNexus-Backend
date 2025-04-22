using System.Text.Json.Serialization;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeList
{
    public class AnimeListResponse
    {
        [JsonPropertyName("pagination")]
        public required Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public required List<AnimeData> Data { get; set; }
    }
}
