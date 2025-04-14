using System;
using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class Aired
{
    [JsonPropertyName("from")]
    public DateTime? From { get; set; }

    [JsonPropertyName("to")]
    public DateTime? To { get; set; }

    [JsonPropertyName("prop")]
    public required AiredProp Prop { get; set; }

    [JsonPropertyName("string")]
    public required string String { get; set; }
}
