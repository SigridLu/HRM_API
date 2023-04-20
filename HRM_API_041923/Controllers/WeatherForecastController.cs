using HRM_API_ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using RHRM_API_ApplicationCore.Entities;

namespace HRM_API_041923.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IWeatherService _weahterService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IWeatherService weahterService, ILogger<WeatherForecastController> logger)
    {
        _weahterService = weahterService;
        _logger = logger;
    }

    /*[HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetWeather()
    {
        var weatherForecasts = await _weahterService.GetAllWeathers();
        if (weatherForecasts != null)
            return Ok(weatherForecasts);
        else
            return NotFound("WeatherForecast Info not Found");
    }
    */
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
}

