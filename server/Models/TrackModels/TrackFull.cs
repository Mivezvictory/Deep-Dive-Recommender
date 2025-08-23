using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.TrackModels
{
    public sealed class TrackFull
    {
        [JsonPropertyName("id")]         public string? Id { get; set; }
        [JsonPropertyName("uri")]        public string? Uri { get; set; }
        [JsonPropertyName("popularity")] public int Popularity { get; set; }
    }
}