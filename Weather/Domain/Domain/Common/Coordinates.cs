namespace Domain.Common
{
	public class Coordinates
	{
		public decimal Longitude { get; set; }
		public decimal Latitude { get; set; }

		public Coordinates(decimal longitude, decimal latitude)
			=> (Longitude, Latitude) = (longitude, latitude);
    }
}
