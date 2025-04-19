using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer
{
    public class ProducerDataFull : ProducerData
    {

        [JsonPropertyName("external")]
        public required List<ProducerExternalLink> External { get; set; }
    }
}