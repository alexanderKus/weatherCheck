namespace Domain.Common
{
	public class ExternalApiResponse
	{
		public decimal Latitude { get; init; }
		public decimal Longitude { get; init; }
		public decimal GenerationTime_Ms { get; init; }
		public decimal UtcOffSetSeconds { get; init; }
		public string Timezone { get; init; }
		public string Timezone_Abbreviation { get; init; }
		public decimal Elevation { get; init; }
		public HourlyUnits Hourly_Units { get; init; }
		public Hourly Hourly { get; init; }
    }
}
