using System.Text.Json.Serialization;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeList;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason
{
    public class GetCurrentSeasonResponse
    {
        [JsonPropertyName("pagination")]
        public required Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public required List<AnimeData> Data { get; set; }
    }
}