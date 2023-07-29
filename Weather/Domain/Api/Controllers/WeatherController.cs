using Application.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly ILogger<WeatherController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherController(
        ILogger<WeatherController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeather")]
    public async Task<ActionResult> Get()
    {
        try
        {
            Coordinates coordinates = new(12.6M, 14.3M);
            var response = await _weatherService.GetWeatherStatisticsAsync(coordinates);
            return Ok(response);
        }
        catch
        {
            return Problem();
        }
    }
}
