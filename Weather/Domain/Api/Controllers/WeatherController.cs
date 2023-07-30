using Application.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpPost(Name = "GetWeatherForLocation")]
    public async Task<ActionResult<WeatherStatistics>> GetWeatherForLocation([FromBody]Coordinates coordinates)
    {
        var response = await _weatherService.GetWeatherStatisticsAsync(coordinates);
        return Ok(response);
    }
}
