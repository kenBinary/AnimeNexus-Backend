using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull
{
    public class AnimeResponse
    {
        [JsonPropertyName("data")]
        public required AnimeDataFull Data { get; set; }

    }
}
