using System.Text.Json.Serialization;
using AnimeNexus.API.Infrastructure.Models.Jikan;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeSeason
{
    public class UpcomingSeasonResponse
    {
        [JsonPropertyName("pagination")]
        public required Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public required List<AnimeData> Data { get; set; }
    }

}