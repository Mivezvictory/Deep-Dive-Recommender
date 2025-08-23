using Microsoft.AspNetCore.Http;
using Deep_Dive_Recommender.Exceptions;
namespace Deep_Dive_Recommender.FunctionHelpers
{
    public static class DeepDiveHelper
    {
        public static string GetArtistIDFromQuery(HttpRequest req)
        {
            var artistId = req.Query["artistId"].ToString();
            if (string.IsNullOrWhiteSpace(artistId))
                throw new Exception("Please provide ?artistId=<spotifyArtistId>");
            return artistId;
        }

        public static string GetTokenFromQuery(HttpRequest req)
        {
            var auth = req.Headers["Authorization"].ToString();
            var token = (auth?.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase) == true)
                ? auth.Substring("Bearer ".Length).Trim()
                : null;
            if (string.IsNullOrWhiteSpace(token))
                throw new MissingAuthorizationException("Missing Authorization: Bearer <token>");
            return token;
        }

    }
}
