using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.Common
{
    public class Aired
    {
        [JsonPropertyName("from")]
        public DateTime? From { get; set; }

        [JsonPropertyName("to")]
        public DateTime? To { get; set; }

        [JsonPropertyName("prop")]
        public required AiredProp Prop { get; set; }

        [JsonPropertyName("string")]
        public required string String { get; set; }
    }
}
