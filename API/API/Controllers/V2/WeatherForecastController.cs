using Microsoft.AspNetCore.Mvc;

namespace Template.API.Controllers.V2;

[ApiVersion("2.0")]
[Route("v{version:apiVersion}/api/forecasts")]
[ApiController]
[Produces("application/json")]
[Consumes("application/json")]
public class WeatherForecastController : Controller
{
    private static readonly string[] Summaries = new[]
    {
        "Forecast V2"
    };
    
    
    /// <summary>
    /// Get Forecasts.
    /// </summary>
    /// <returns>A list of forecasts</returns>
    /// <response code="200">Returns a list of forecasts</response>
    /// <response code="500">If an unexpected error occured</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        return Ok(Summaries);
    }
}