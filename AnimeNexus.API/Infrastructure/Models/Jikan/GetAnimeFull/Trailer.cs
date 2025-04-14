using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class Trailer
{
    [JsonPropertyName("youtube_id")]
    public string? YoutubeId { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("embed_url")]
    public string? EmbedUrl { get; set; }

    [JsonPropertyName("images")]
    public required TrailerImages Images { get; set; }
}
