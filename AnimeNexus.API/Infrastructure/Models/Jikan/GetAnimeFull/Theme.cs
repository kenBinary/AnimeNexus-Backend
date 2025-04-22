using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull
{
    public class Theme
    {
        [JsonPropertyName("openings")]
        public required List<string> Openings { get; set; }

        [JsonPropertyName("endings")]
        public required List<string> Endings { get; set; }
    }
}
