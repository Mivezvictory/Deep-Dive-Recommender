using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Deep_Dive_Recommender;

public class DeepDiveRecommender
{
    private readonly ILogger<DeepDiveRecommender> _logger;

    public DeepDiveRecommender(ILogger<DeepDiveRecommender> logger)
    {
        _logger = logger;
    }

    [Function("DeepDiveRecommender")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}