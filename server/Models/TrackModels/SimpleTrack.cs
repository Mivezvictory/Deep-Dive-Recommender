namespace Deep_Dive_Recommender.Models.TrackModels
{
    public sealed class SimpleTrack
    {
        public string? Id { get; set; }
        public string? Uri { get; set; }
        public string? Name { get; set; }

        public static SimpleTrack From(SimpleTrackItem t) => new SimpleTrack
        {
            Id = t.Id,
            Uri = t.Uri,
            Name = t.Name
        };
    }
}