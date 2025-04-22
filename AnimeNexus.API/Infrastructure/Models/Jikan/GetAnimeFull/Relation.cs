using System.Text.Json.Serialization;

namespace backend.AnimeNexus.API.Infrastructure.Models.Jikan.GetAnimeFull
{
    public class Relation
    {
        [JsonPropertyName("relation")]
        public required string RelationType { get; set; }

        [JsonPropertyName("entry")]
        public required List<RelationEntry> Entry { get; set; }
    }
}
