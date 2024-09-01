using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace azure_api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 1).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("vikash")]
    public IActionResult Vikash()
    {
        var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;
        // _logger.LogError($"Hi Vikash, Error log {DateTime.Now}");
        // _logger.LogInformation($"Hi Vikash, Info log {DateTime.Now}");

        IDictionary<string, object> user = new Dictionary<string, object>();
        foreach (var item in userClaims?.Claims)
        {
            if (!user.ContainsKey(item.Type))
            {
                user.Add(item.Type, item.Value);
            }
        }

        return Ok(user);
    }
}
