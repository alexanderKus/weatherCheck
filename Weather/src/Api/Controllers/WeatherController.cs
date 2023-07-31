using Application.Commands;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<WeatherStatistics>> GetWeatherForLocation(
        [FromBody]Coordinates coordinates)
    {
        WeatherStatisticsCommand command = new(coordinates);
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
