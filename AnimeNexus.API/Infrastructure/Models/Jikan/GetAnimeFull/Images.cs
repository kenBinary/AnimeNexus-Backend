using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class Images
{
    [JsonPropertyName("jpg")]
    public required ImageUrls Jpg { get; set; }

    [JsonPropertyName("webp")]
    public required ImageUrls Webp { get; set; }
}
