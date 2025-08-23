using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Deep_Dive_Recommender.Spotify;
using Deep_Dive_Recommender.FunctionHelpers;
using Deep_Dive_Recommender.Exceptions;
using Newtonsoft.Json;

namespace Deep_Dive_Recommender
{

    public class DeepDiveRecommender
    {
        private readonly ILogger<DeepDiveRecommender> _logger;

        public DeepDiveRecommender(ILogger<DeepDiveRecommender> logger)
        {
            _logger = logger;
        }

        [Function("DeepDiveRecommender")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            try
            {
                _logger.LogInformation("C# HTTP trigger function processed a request.");
                string token;
                var artistId = DeepDiveHelper.GetArtistIDFromQuery(req);
                //var token = DeepDiveHelper.GetTokenFromQuery(req);
                if (Environment.GetEnvironmentVariable("AZURE_FUNCTION_ENVIRONMENT") == "development")
                    token = Environment.GetEnvironmentVariable("TOKEN");
                else
                    token = DeepDiveHelper.GetTokenFromQuery(req);
                var market = "from_token"; // ensures availability follows the user region

                // 2) Fetch artist albums (album + single), dedupe, sort by release
                var spotify = new SpotifyHandler(token, _logger);
                var albums = await spotify.GetArtistAlbumsAsync(artistId, market, new[] { "album", "single" });

                return FunctionHelper.CreateReturnResponse(JsonConvert.SerializeObject(albums), "ok");
            }
            catch (MissingAuthorizationException ex)
            {
                _logger.LogError(ex.Message);
                return new UnauthorizedObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }

        }
    }
}