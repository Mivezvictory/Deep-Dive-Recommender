using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Deep_Dive_Recommender.FunctionHelpers;
using Deep_Dive_Recommender.Exceptions;
using Deep_Dive_Recommender.Models;


namespace Deep_Dive_Recommender;

public class SpotifyCallback
{
    private readonly ILogger<SpotifyCallback> _logger;
    private static readonly HttpClient _http = new HttpClient();

    public SpotifyCallback(ILogger<SpotifyCallback> logger)
    {
        _logger = logger;
    }

    [Function("spotify-callback")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        ActionResult returnObj;
        try
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var code = FunctionErrorHelpers.Errorhandler(req);//makes sure no errors where thrown by Spotify during the auth process

            //retrieve env variables
            var clientId = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
            var clientSecret = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_SECRET");
            var redirectUrl = Environment.GetEnvironmentVariable("SPOTIFY_REDIRECT_URI");
            var clientAppUrl = Environment.GetEnvironmentVariable("CLIENT_APP_URL") ?? "https://localhost:5173"; // front-end base

            //Exchange code -> tokens
            var form = $"grant_type=authorization_code&code={Uri.EscapeDataString(code)}&redirect_uri={Uri.EscapeDataString(redirectUrl)}";
            var reqMsg = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token");
            reqMsg.Content = new StringContent(form, Encoding.UTF8, "application/x-www-form-urlencoded");
            var basic = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            reqMsg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", basic);

            var tokenResp = await _http.SendAsync(reqMsg);//get token
            var body = await tokenResp.Content.ReadAsStringAsync();
            if (!tokenResp.IsSuccessStatusCode)
            {
                _logger.LogError("Spotify token exchange failed: {Status} {Body}", tokenResp.StatusCode, body);
                return new BadRequestObjectResult("Failed to exchange authorization code.");
            }

            var tokens = JsonSerializer.Deserialize<TokenResponse>(body,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (tokens is null || string.IsNullOrEmpty(tokens.AccessToken))
            {
                _logger.LogError("Token JSON missing access_token. Raw body: {Body}", body);
                return new BadRequestObjectResult("Invalid token response from Spotify.");
                // TODO: persist tokens (userId, access, refresh, expires) in Cosmos DB
            }

            var state = req.Query["state"];
            var dest = FunctionHelper.CombineUrl(clientAppUrl, string.IsNullOrWhiteSpace(state) ? "" : state);

            var redirect = $"{dest}?token={Uri.EscapeDataString(tokens.AccessToken)}";
            return new RedirectResult(redirect, permanent: false);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            returnObj = FunctionReturnHelpers.CreateReturnResponse(ex.Message, "badrequest");
            return returnObj;
        }
       
    }
}