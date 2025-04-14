using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class Theme
{
    [JsonPropertyName("openings")]
    public required List<string> Openings { get; set; }

    [JsonPropertyName("endings")]
    public required List<string> Endings { get; set; }
}
