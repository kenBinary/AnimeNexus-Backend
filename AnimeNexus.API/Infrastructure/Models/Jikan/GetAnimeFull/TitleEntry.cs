using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class TitleEntry
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }
}
