using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull
{
    public class StreamingLink
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("url")]
        public required string Url { get; set; }
    }
}
