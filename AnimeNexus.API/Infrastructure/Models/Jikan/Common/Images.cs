using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common
{
    public class Images
    {
        [JsonPropertyName("jpg")]
        public required ImageUrls Jpg { get; set; }

        [JsonPropertyName("webp")]
        public required ImageUrls Webp { get; set; }
    }
}
