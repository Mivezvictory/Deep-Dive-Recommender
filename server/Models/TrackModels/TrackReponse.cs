using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.TrackModels
{
     public sealed class TracksResponse
    {
        [JsonPropertyName("tracks")] public List<TrackFull?>? Tracks { get; set; }
    }
}