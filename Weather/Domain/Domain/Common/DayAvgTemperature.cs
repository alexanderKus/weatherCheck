namespace Domain.Common
{
	public class DayAvgTemperature
	{
		public DateTime Day { get; init; }
		public decimal AvgTemperature { get; init; }

		public DayAvgTemperature(DateTime day, decimal avgTemperature)
			=> (Day, AvgTemperature) = (day, avgTemperature);
	}
}
