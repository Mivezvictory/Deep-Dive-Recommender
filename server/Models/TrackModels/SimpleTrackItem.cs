//change name to TrackItem
using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.TrackModels
{
    public sealed class SimpleTrackItem
    {
        [JsonPropertyName("id")] public string? Id { get; set; }
        [JsonPropertyName("uri")] public string? Uri { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
    }
}