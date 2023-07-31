namespace Domain.Common
{
	public record Hourly(IList<DateTime> Time, IList<decimal> Temperature_2m);
}
