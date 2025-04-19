using System.Text.Json.Serialization;
using AnimeNexus.API.Infrastructure.Models.Jikan;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeProducer
{
    public class ProducerListResponse
    {
        [JsonPropertyName("pagination")]
        public required Pagination Pagination { get; set; }

        [JsonPropertyName("data")]
        public required List<ProducerData> Data { get; set; }
    }
}
