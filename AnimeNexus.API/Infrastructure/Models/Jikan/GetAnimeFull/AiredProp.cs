using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class AiredProp
{
    [JsonPropertyName("from")]
    public required DateInfo From { get; set; }

    [JsonPropertyName("to")]
    public required DateInfo To { get; set; }
}
