using Application.Interfaces;
using Domain.Common;
using Infrastructure.Utils;

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
            ExternalApiResponse externalApiResponse = await _externalApiCaller.GetResponseAsync(coordinates)
                ?? throw new Exception("Make this custom exception");
            WeatherStatistics weatherStatictis = new(externalApiResponse)
            {
                DailyAvgTemperature = WeatherUtils.CreateDailyAvgTemperature(externalApiResponse.Hourly)
            };
            return weatherStatictis;
        }
    }
}
