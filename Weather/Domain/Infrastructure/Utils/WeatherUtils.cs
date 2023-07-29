using Domain.Common;

namespace Infrastructure.Utils
{
	public static class WeatherUtils
	{
		public static IEnumerable<DayAvgTemperature> CreateDailyAvgTemperature(
			Hourly hourly)
		{
			Dictionary<DateTime, List<decimal>> dailyTemperatures = new();
			var count = hourly.Time.Count;

            for (int i = 0; i < count; i++)
			{
				var day = hourly.Time[i].Date;
				decimal temperature = hourly.Temperature_2m[i];
				if (!dailyTemperatures.ContainsKey(day))
				{
                    dailyTemperatures[day] = new();
                }
                dailyTemperatures[day].Add(temperature);
            }
			IEnumerable<DayAvgTemperature> dailyAvgTemperature = dailyTemperatures
				.Select(x => new DayAvgTemperature(day: x.Key, avgTemperature: x.Value.Average()));

            return dailyAvgTemperature;
		}
	}
}
