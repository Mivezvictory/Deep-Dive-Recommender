using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SpotifyWebApp;

public class SpotifyCallback
{
    private readonly ILogger<SpotifyCallback> _logger;

    public SpotifyCallback(ILogger<SpotifyCallback> logger)
    {
        _logger = logger;
    }

    [Function("SpotifyCallback")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}