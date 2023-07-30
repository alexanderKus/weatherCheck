using Application.Interfaces;
using Domain.Common;

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
            WeatherStatistics weatherStatictis = new(externalApiResponse);
            return weatherStatictis;
        }
    }
}
