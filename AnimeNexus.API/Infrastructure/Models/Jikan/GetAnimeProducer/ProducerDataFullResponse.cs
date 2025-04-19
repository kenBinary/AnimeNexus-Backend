using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer
{
    public class ProducerDataFullResponse
    {
        [JsonPropertyName("data")]
        public required ProducerDataFull ProducerDataFull { get; set; }
    }
}