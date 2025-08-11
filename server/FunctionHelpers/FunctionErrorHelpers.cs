using Microsoft.AspNetCore.Http;
using Deep_Dive_Recommender.Exceptions;
namespace Deep_Dive_Recommender.FunctionHelpers
{
    public static class FunctionErrorHelpers
    {
        public static String Errorhandler(HttpRequest req)
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