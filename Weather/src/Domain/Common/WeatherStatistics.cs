namespace Domain.Common
{
	public class WeatherStatistics
    {

        public IEnumerable<DayAvgTemperature> DailyAvgTemperature { get; }

		public WeatherStatistics(ExternalApiResponse externalApiResponse)
        {
            DailyAvgTemperature = CreateDailyAvgTemperature(externalApiResponse.Hourly);
        }

        private static IEnumerable<DayAvgTemperature> CreateDailyAvgTemperature(
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
                .Select(x => new DayAvgTemperature(Day: x.Key, AvgTemperature: x.Value.Average()));

            return dailyAvgTemperature;
        }
    }
}
