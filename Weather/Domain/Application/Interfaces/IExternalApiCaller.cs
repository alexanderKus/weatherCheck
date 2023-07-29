using Domain.Common;

namespace Application.Interfaces
{
	public interface IExternalApiCaller
	{
		Task<ExternalApiResponse> GetResponseAsync(Coordinates coordinates);
	}
}
