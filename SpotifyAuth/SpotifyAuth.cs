using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SpotifyWebApp;

public class SpotifyAuth
{
    private readonly ILogger<SpotifyAuth> _logger;

    public SpotifyAuth(ILogger<SpotifyAuth> logger)
    {
        _logger = logger;
    }

    [Function("SpotifyAuth")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}