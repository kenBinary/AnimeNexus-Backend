using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations
{
    public class RecommendationResponse
    {
        [JsonPropertyName("pagination")]
        public required RecommendationPagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public required List<RecommendationData> Data { get; set; }
    }
}
