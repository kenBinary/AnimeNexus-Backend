using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class ExternalLink
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }
}
