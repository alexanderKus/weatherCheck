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
                string responseBody = await _client.GetStringAsync(
                    $"https://api.open-meteo.com/v1/forecast?latitude={coordinates.Latitude}&longitude={coordinates.Longitude}&hourly=temperature_2m");
                return JsonConvert.DeserializeObject<ExternalApiResponse>(responseBody)!;
            }
            catch
            {
                throw new ExternalApiCallerException();
            }
        }
    }
}
