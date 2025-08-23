using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.AlbumModels
{
    public sealed class AlbumPage
    {
        [JsonPropertyName("items")]
        public List<AlbumItem>? Items { get; set; }

        [JsonPropertyName("next")] 
        public string? Next { get; set; }
    }
}