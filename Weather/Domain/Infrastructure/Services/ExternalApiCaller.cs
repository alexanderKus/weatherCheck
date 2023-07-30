using Application.Interfaces;
using Domain.Common;
using Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class ExternalApiCaller : IExternalApiCaller
	{
        private readonly HttpClient _client = new();
        public readonly ILogger<ExternalApiCaller> _logger;

        public ExternalApiCaller(ILogger<ExternalApiCaller> logger)
        {
            _logger = logger;
        }

        public async Task<ExternalApiResponse> GetResponseAsync(Coordinates coordinates)
        {
            try
            {
                _logger.LogInformation("Calling external api");
                string responseBody = await _client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m");
                var response = JsonConvert.DeserializeObject<ExternalApiResponse>(responseBody);
                return response;
            }
            catch
            {
                throw new ExternalApiCallerException();
            }
        }
    }
}
