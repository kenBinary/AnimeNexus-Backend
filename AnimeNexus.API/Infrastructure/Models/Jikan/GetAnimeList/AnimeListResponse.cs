using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan
{
    public class AnimeListResponse
    {
        [JsonPropertyName("pagination")]
        public required Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public required List<AnimeData> Data { get; set; }
    }
}
