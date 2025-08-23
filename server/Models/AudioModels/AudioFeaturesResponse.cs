using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.AudioModels
{
    public sealed class AudioFeaturesResponse
    {
        [JsonPropertyName("audio_features")] public List<AudioFeatures?>? AudioFeatures { get; set; }
    }
}