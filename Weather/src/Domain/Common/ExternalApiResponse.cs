namespace Domain.Common
{
	public record ExternalApiResponse(
		decimal Latitude,
		decimal Longitude,
		decimal GenerationTime_Ms,
		decimal UtcOffSetSeconds,
		string Timezone,
		string Timezone_Abbreviation,
		decimal Elevation ,
		HourlyUnits Hourly_Units,
		Hourly Hourly);
}
