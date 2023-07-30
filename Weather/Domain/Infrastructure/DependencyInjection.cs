using Application.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<IExternalApiCaller, ExternalApiCaller>();
			services.AddScoped<IWeatherService, WeatherService>();
			return services;
		}
	}
}

