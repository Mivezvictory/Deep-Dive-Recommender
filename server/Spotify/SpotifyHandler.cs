using System.Text.Json;
using Deep_Dive_Recommender.Models.AlbumModels;
using Microsoft.Extensions.Logging;

namespace Deep_Dive_Recommender.Spotify
{
    public sealed class SpotifyHandler
    {
        private readonly string _token;
        private readonly ILogger _logger;

        public SpotifyHandler(string token, ILogger logger)
        {
            _token = token;
            _logger = logger;
        }

        public async Task<List<AlbumSimplified>> GetArtistAlbumsAsync(string artistId, string market, IEnumerable<string> releaseTypeGroups)
        {
            var results = new List<AlbumSimplified>();
            var groups = string.Join(",", releaseTypeGroups);
            var url = $"https://api.spotify.com/v1/artists/{artistId}/albums?include_groups={Uri.EscapeDataString(groups)}&market={Uri.EscapeDataString(market)}&limit=50&offset=0";

            while (!string.IsNullOrEmpty(url))
            {
                var root = await SpotifyHandlerHelper.GetJson<AlbumPage>(url!, _token, "get", _logger);
                if (root?.Items != null)
                {
                    results.AddRange(root.Items.Select(AlbumSimplified.From));
                    url = root.Next;
                }
            }
            foreach (var a in results)
                    a.ComputeParsedDate();
            

            return results;
        }
    }
}