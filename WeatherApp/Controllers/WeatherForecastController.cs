using Microsoft.AspNetCore.Mvc;
using WeatherApp.Data;

namespace WeatherApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost(Name = "PostWeatherForecast")]
    public IActionResult Post(WeatherForecast forecast)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        _context.Weathers.Add(forecast);
        _context.SaveChanges();
        return Ok(forecast);
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok(_context.Weathers.ToList());
    }
}
