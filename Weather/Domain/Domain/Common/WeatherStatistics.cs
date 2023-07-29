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
        public IEnumerable<DayAvgTemperature>? DailyAvgTemperature { get; set; }

		public WeatherStatistics(ExternalApiResponse externalApiResponse)
			=> _externalApiResponse = externalApiResponse;
	}
}
