using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.AudioModels
{
    public sealed class AudioFeatures
    {
        [JsonPropertyName("id")] public string? Id { get; set; }
        [JsonPropertyName("danceability")] public double Danceability { get; set; }
        [JsonPropertyName("energy")] public double Energy { get; set; }
        [JsonPropertyName("valence")] public double Valence { get; set; }
        [JsonPropertyName("acousticness")] public double Acousticness { get; set; }
        [JsonPropertyName("instrumentalness")] public double Instrumentalness { get; set; }
    }
}