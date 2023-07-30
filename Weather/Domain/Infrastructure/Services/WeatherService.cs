using Application.Interfaces;
using Domain.Common;
using Domain.Exceptions;
using Infrastructure.Utils;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
	public class WeatherService : IWeatherService
	{
        private readonly IExternalApiCaller _externalApiCaller;

        public WeatherService(IExternalApiCaller externalApiCaller)
		{
            _externalApiCaller = externalApiCaller;
        }

        public async Task<WeatherStatistics> GetWeatherStatisticsAsync(Coordinates coordinates)
        {
            ExternalApiResponse externalApiResponse = await _externalApiCaller.GetResponseAsync(coordinates);
            WeatherStatistics weatherStatictis = new(externalApiResponse)
            {
                DailyAvgTemperature = WeatherUtils.CreateDailyAvgTemperature(externalApiResponse.Hourly)
            };
            return weatherStatictis;
        }
    }
}
