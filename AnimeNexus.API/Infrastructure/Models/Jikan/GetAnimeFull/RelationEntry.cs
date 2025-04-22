using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull
{
    public class RelationEntry
    {
        [JsonPropertyName("mal_id")]
        public int MalId { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("url")]
        public required string Url { get; set; }
    }
}
