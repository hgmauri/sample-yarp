using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Sample.Yarp.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController(ILogger<ClientController> logger) : ControllerBase
{
	[HttpGet]
    public Task<IActionResult> Get()
    {
        logger.LogInformation("Endpoint Get successful. (from ILogger)");
        Log.Information("Endpoint Get successful. (from Serilog)");

        return Task.FromResult<IActionResult>(Ok());
    }
}
