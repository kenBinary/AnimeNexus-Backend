using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer
{
    public class ProducerImages
    {
        [JsonPropertyName("jpg")]
        public required ProducerJpg Jpg { get; set; }
    }
}
