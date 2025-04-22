using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common
{
    public class TitleEntry
    {
        [JsonPropertyName("type")]
        public required string Type { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }
}
