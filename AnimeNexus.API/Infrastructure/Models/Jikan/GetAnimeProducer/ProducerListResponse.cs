using System.Text.Json.Serialization;
using backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common;

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
