using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Deep_Dive_Recommender.Exceptions;

namespace Deep_Dive_Recommender
{

    public class SpotifyAuth
    {
        private readonly ILogger<SpotifyAuth> _logger;

        public SpotifyAuth(ILogger<SpotifyAuth> logger)
        {
            _logger = logger;
        }

        [Function("SpotifyAuth")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "spotify-auth")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            try
            {
                //constants
                String? SPOTIFY_REDIRECT_URI = Environment.GetEnvironmentVariable("SPOTIFY_REDIRECT_URI");
                String? SCOPES = Environment.GetEnvironmentVariable("SCOPES");

                var cliendID = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
                if (string.IsNullOrEmpty(SPOTIFY_REDIRECT_URI) || string.IsNullOrEmpty(SCOPES))
                    throw new EnvironmentVariableNullException("Please ensure a value is provided for the Environment Variables SPOTIFY_REDIRECT_URI/SCOPES");

                var redirectUri = Uri.EscapeDataString(SPOTIFY_REDIRECT_URI);
                var scopes = Uri.EscapeDataString(SCOPES);

                var authUrl = $"https://accounts.spotify.com/authorize" +
                            $"?response_type=code" +
                            $"&client_id={cliendID}" +
                            $"&scope={scopes}" +
                            $"&redirect_uri={redirectUri}";

                //var response = req.CreateResponse(HttpStatusCode.Redirect);
                return new RedirectResult(authUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}