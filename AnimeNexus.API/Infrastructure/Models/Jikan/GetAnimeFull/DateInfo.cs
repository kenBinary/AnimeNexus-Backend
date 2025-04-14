using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class DateInfo
{
    [JsonPropertyName("day")]
    public int? Day { get; set; }

    [JsonPropertyName("month")]
    public int? Month { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }
}
