namespace Domain.Common
{
	public class Hourly
	{
		public List<DateTime> Time { get; init; } = new();
		public List<decimal> Temperature_2m { get; init; } = new();
	}
}
