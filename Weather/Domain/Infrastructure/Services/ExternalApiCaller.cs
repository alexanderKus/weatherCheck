using Application.Interfaces;
using Domain.Common;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class ExternalApiCaller : IExternalApiCaller
	{
        private readonly HttpClient _client = new();

        public async Task<ExternalApiResponse> GetResponseAsync(Coordinates coordinates)
        {
            try
            {
                string responseBody = await _client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m");
                var response = JsonConvert.DeserializeObject<ExternalApiResponse>(responseBody);
                return response!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null!;
            }
        }
    }
}
