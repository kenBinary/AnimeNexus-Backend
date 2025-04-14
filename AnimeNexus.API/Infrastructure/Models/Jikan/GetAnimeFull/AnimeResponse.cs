using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class AnimeResponse
{
    [JsonPropertyName("data")]
    public required AnimeDataFull Data { get; set; }

}
