using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class ImageUrls
{
    [JsonPropertyName("image_url")]
    public required string ImageUrl { get; set; }

    [JsonPropertyName("small_image_url")]
    public required string SmallImageUrl { get; set; }

    [JsonPropertyName("large_image_url")]
    public required string LargeImageUrl { get; set; }
}
