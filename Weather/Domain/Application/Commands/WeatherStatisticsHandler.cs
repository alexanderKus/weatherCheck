using Application.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Commands
{
    public class WeatherStatisticsHandler
        : IRequestHandler<WeatherStatisticsCommand, WeatherStatistics>
	{
        private readonly IWeatherService _weatherService;

        public WeatherStatisticsHandler(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public Task<WeatherStatistics> Handle(WeatherStatisticsCommand request, CancellationToken cancellationToken)
        {
             return _weatherService.GetWeatherStatisticsAsync(request.Coordinates);
        }
    }
}

