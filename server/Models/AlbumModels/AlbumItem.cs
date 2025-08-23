using System.Text.Json.Serialization;

namespace Deep_Dive_Recommender.Models.AlbumModels
{
    public sealed class AlbumItem
    {
        [JsonPropertyName("id")] public string? Id { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("release_date")] public string? ReleaseDate { get; set; }
        [JsonPropertyName("release_date_precision")] public string? ReleaseDatePrecision { get; set; }
        [JsonPropertyName("album_group")] public string? AlbumGroup { get; set; }
        [JsonPropertyName("album_type")] public string? AlbumType { get; set; }
    }
}