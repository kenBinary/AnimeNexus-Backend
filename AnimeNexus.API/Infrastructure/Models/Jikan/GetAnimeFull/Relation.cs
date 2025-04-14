using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class Relation
{
    [JsonPropertyName("relation")]
    public required string RelationType { get; set; } // Renamed from "Relation" to avoid conflict

    [JsonPropertyName("entry")]
    public required List<RelationEntry> Entry { get; set; }
}
