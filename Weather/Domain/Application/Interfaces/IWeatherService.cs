using Domain.Common;

namespace Application.Interfaces
{
	public interface IWeatherService
	{
        Task<WeatherStatistics> GetWeatherStatisticsAsync(Coordinates coordinates);
    }
}
