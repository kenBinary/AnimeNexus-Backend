using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer
{
    public class ProducerTitle
    {
        [JsonPropertyName("type")]
        public required string Type { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }
    }
}
