using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common
{
    public class AiredProp
    {
        [JsonPropertyName("from")]
        public required DateInfo From { get; set; }

        [JsonPropertyName("to")]
        public required DateInfo To { get; set; }
    }
}
