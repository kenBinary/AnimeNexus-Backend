using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AnimeNexus.API.Infrastructure.Models.Jikan;

public class AnimeDataFull
{
    [JsonPropertyName("mal_id")]
    public int MalId { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("images")]
    public required Images Images { get; set; }

    [JsonPropertyName("trailer")]
    public required Trailer Trailer { get; set; }

    [JsonPropertyName("approved")]
    public bool Approved { get; set; }

    [JsonPropertyName("titles")]
    public required List<TitleEntry> Titles { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("title_english")]
    public string? TitleEnglish { get; set; }

    [JsonPropertyName("title_japanese")]
    public required string TitleJapanese { get; set; }

    [JsonPropertyName("title_synonyms")]
    public required List<string> TitleSynonyms { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("source")]
    public required string Source { get; set; }

    [JsonPropertyName("episodes")]
    public int? Episodes { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("airing")]
    public bool Airing { get; set; }

    [JsonPropertyName("aired")]
    public required Aired Aired { get; set; }

    [JsonPropertyName("duration")]
    public required string Duration { get; set; }

    [JsonPropertyName("rating")]
    public required string Rating { get; set; }

    [JsonPropertyName("score")]
    public double? Score { get; set; }

    [JsonPropertyName("scored_by")]
    public int? ScoredBy { get; set; }

    [JsonPropertyName("rank")]
    public int? Rank { get; set; }

    [JsonPropertyName("popularity")]
    public int? Popularity { get; set; }

    [JsonPropertyName("members")]
    public int? Members { get; set; }

    [JsonPropertyName("favorites")]
    public int? Favorites { get; set; }

    [JsonPropertyName("synopsis")]
    public string? Synopsis { get; set; }

    [JsonPropertyName("background")]
    public string? Background { get; set; }

    [JsonPropertyName("season")]
    public string? Season { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("broadcast")]
    public required Broadcast Broadcast { get; set; }

    [JsonPropertyName("producers")]
    public required List<MalUrl> Producers { get; set; }

    [JsonPropertyName("licensors")]
    public required List<MalUrl> Licensors { get; set; }

    [JsonPropertyName("studios")]
    public required List<MalUrl> Studios { get; set; }

    [JsonPropertyName("genres")]
    public required List<MalUrl> Genres { get; set; }

    [JsonPropertyName("explicit_genres")]
    public required List<MalUrl> ExplicitGenres { get; set; }

    [JsonPropertyName("themes")]
    public required List<MalUrl> Themes { get; set; }

    [JsonPropertyName("demographics")]
    public required List<MalUrl> Demographics { get; set; }

    [JsonPropertyName("relations")]
    public required List<Relation> Relations { get; set; }

    [JsonPropertyName("theme")]
    public required Theme Theme { get; set; }

    [JsonPropertyName("external")]
    public required List<ExternalLink> External { get; set; }

    [JsonPropertyName("streaming")]
    public required List<StreamingLink> Streaming { get; set; }
}
