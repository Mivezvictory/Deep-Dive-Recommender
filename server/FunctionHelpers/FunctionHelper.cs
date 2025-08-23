using Microsoft.AspNetCore.Http;
using Deep_Dive_Recommender.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Deep_Dive_Recommender.FunctionHelpers
{
    public static class FunctionHelper
    {
        //Move Function specific helpers to a specific helper class
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
            return code!;
        }

        public static ActionResult CreateReturnResponse(String returnObj, string statusCode)
        {
            return new ContentResult
            {
                Content = returnObj,
                ContentType = "application/json",
                StatusCode = GetStatusCode(statusCode)
            };
        }

        private static int GetStatusCode(String statusCode)
        {
            return statusCode.ToLower() switch
            {
                "ok" => (int)HttpStatusCode.OK,
                "badrequest" => (int)HttpStatusCode.BadRequest,
                "notfound" => (int)HttpStatusCode.NotFound,
                "redirect" => (int)HttpStatusCode.Redirect,
                "internalservererror" => (int)HttpStatusCode.InternalServerError
            };
        }

    }
}