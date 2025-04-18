using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeRecommendations
{
    public class RecommendationData
    {
        [JsonPropertyName("mal_id")]
        public required string MalId { get; set; }

        [JsonPropertyName("entry")]
        public required List<RecommendationEntry> Entry { get; set; }

        [JsonPropertyName("content")]
        public required string Content { get; set; }

        [JsonPropertyName("date")]
        public DateTimeOffset Date { get; set; }

        [JsonPropertyName("user")]
        public required RecommendationUser User { get; set; }
    }
}
