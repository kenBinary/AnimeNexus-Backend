using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common
{
    public class ImageUrls
    {
        [JsonPropertyName("image_url")]
        public required string ImageUrl { get; set; }

        [JsonPropertyName("small_image_url")]
        public required string SmallImageUrl { get; set; }

        [JsonPropertyName("large_image_url")]
        public required string LargeImageUrl { get; set; }
    }
}
