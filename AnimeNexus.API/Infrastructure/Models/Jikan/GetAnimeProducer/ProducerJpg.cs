using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer
{
    public class ProducerJpg
    {
        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }
    }
}
