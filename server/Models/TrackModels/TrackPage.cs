using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.TrackModels
{
    public sealed class TrackPage
    {
        [JsonPropertyName("items")] public List<SimpleTrackItem>? Items { get; set; }
        [JsonPropertyName("next")] public string? Next { get; set; }
    }
}