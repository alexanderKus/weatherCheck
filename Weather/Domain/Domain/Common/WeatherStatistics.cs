namespace Domain.Common
{
	public class WeatherStatistics
    {
		private readonly ExternalApiResponse _externalApiResponse;

        public decimal Latitude => _externalApiResponse.Latitude;
        public decimal Longitude => _externalApiResponse.Latitude;
        public decimal GenerationTime_Ms => _externalApiResponse.GenerationTime_Ms;
        public decimal UtcOffSetSeconds => _externalApiResponse.UtcOffSetSeconds;
        public string Timezone => _externalApiResponse.Timezone;
        public string Timezone_Abbreviation => _externalApiResponse.Timezone_Abbreviation;
        public decimal Elevation => _externalApiResponse.Elevation;
        public HourlyUnits Hourly_Units => _externalApiResponse.Hourly_Units;
        public Hourly Hourly => _externalApiResponse.Hourly;
        public IEnumerable<DayAvgTemperature> DailyAvgTemperature { get; }

		public WeatherStatistics(ExternalApiResponse externalApiResponse)
        {
			_externalApiResponse = externalApiResponse;
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
                .Select(x => new DayAvgTemperature(day: x.Key, avgTemperature: x.Value.Average()));

            return dailyAvgTemperature;
        }
    }
}
