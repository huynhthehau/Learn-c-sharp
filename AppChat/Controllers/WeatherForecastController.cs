using DemoAuth.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ww.Controllers;
[Route("[controller]")]
public class WeatherForecastController : BaseController
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
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("test")]
    public ContentResult Index()
    {
        ContentResult v = new ContentResult();
        v.Content = "Hello World";
        return v;
    }

    [HttpGet("Throw")]
    public IActionResult Throw() =>
    throw new Exception("Sample exception.");
    [HttpGet("/error")]
    public IActionResult HandleError() => Problem();
}
