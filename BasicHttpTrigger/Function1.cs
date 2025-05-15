using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BasicHttpTrigger;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("Function1")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("Processing request...");

        string name = req.Query["name"];

        if (string.IsNullOrEmpty(name))
        {
            return new BadRequestObjectResult("Please provide a name in the query string.");
        }

        return new OkObjectResult($"Hello, {name}! Your Azure Function executed successfully.");
    }
}
