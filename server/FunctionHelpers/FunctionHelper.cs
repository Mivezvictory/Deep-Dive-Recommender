using Microsoft.AspNetCore.Http;
using Deep_Dive_Recommender.Exceptions;
namespace Deep_Dive_Recommender.FunctionHelpers
{
    public static class FunctionHelper
    {
        public static string CombineUrl(string baseUrl, string pathOrRelative)
        {
            if (string.IsNullOrWhiteSpace(pathOrRelative)) return baseUrl;
            if (pathOrRelative.StartsWith("http", StringComparison.OrdinalIgnoreCase)) return pathOrRelative;
            if (!baseUrl.EndsWith("/")) baseUrl += "/";
            if (pathOrRelative.StartsWith("/")) pathOrRelative = pathOrRelative[1..];
            return baseUrl + pathOrRelative;
        }

        /*
        * Accepts a single paramenter, A HttpRequest
        * Retrieves either an error message or an Authorization Code
        * Throws an exception in both cases if Code is missing or if an error message is returned by spotify
        * Returns a Spotify Authorization Code if available
        */
        public static String GetAuthCode(HttpRequest req)
        {

            var error = req.Query["error"];
            if (!string.IsNullOrEmpty(error))
                throw new SpotifyCallbackExceptionException($"Spotify error: {error}");

            var code = req.Query["code"];
            if (string.IsNullOrWhiteSpace(code))
                throw new SpotifyCallbackExceptionException("Missing authorization code.");
            return code;
        }

    }
}