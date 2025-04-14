using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class Broadcast
{
    [JsonPropertyName("day")]
    public string? Day { get; set; }

    [JsonPropertyName("time")]
    public string? Time { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    [JsonPropertyName("string")]
    public required string String { get; set; }
}
